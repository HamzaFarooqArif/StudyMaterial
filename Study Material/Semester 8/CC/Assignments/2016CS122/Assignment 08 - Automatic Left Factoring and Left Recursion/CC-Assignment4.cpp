#include <iostream>
#include <algorithm>
#include <string>
#include <vector>
#include <fstream>
#include <sstream>
#include <regex>

using namespace std;

enum symbolType {Terminal, NonTerminal};

class csvManager
{
public:
    int maxRows;
    int maxCols;
    vector<vector<string>> fileContent;

    csvManager()
    {
        maxRows = 0;
        maxCols = 0;
    }

    bool read(string filePath)
    {
        ifstream  iFile(filePath);
        bool read = iFile.good();
        string line;
        for (int i = 0; getline(iFile, line); i++)
        {
            if (maxRows < i + 1) maxRows = i + 1;
            stringstream  lineStream(line);
            string        cell;
            vector<string> cellsLine;
            for (int j = 0; getline(lineStream, cell, ','); j++)
            {
                if (maxCols < j + 1) maxCols = j + 1;
                cellsLine.push_back(rectifyString(cell));
            }
            fileContent.push_back(cellsLine);
        }
        iFile.close();
        return read;
    }

    string rectifyString(string str)
    {
        string result = "";
        for (int i = 0; i < str.length(); i++)
        {
            if (validateCharacter(str[i])) result += str[i];
        }
        return result;
    }

    bool validateCharacter(char c)
    {
        if (c > -1 && c < 255) return true;
        return false;
    }

    void addCell(string cell, int row, int col)
    {

        for (int i = 0; i < row + 1; i++)
        {
            if (fileContent.size() < i + 1)
            {
                vector<string> cellsLine;
                fileContent.push_back(cellsLine);
            }
            for (int j = 0; j < col + 1; j++)
            {
                if (fileContent[i].size() < j + 1) fileContent[i].push_back("");
            }
        }

        fileContent[row][col] = cell;
    }

    void refreshDimensions()
    {
        for (int i = 0; i < fileContent.size(); i++)
        {
            if (maxRows < i + 1) maxRows = i + 1;
            for (int j = 0; j < fileContent[i].size(); j++)
            {
                if (maxCols < j + 1) maxCols = j + 1;
            }
        }
    }

    void print()
    {
        for (int i = 0; i < fileContent.size(); i++)
        {
            for (int j = 0; j < fileContent[i].size(); j++)
            {
                cout << i << " " << j << " " << fileContent[i][j] << endl;
            }
        }
    }

    bool writeToFile(string filePath)
    {
        ofstream oFile;
        oFile.open(filePath);
        bool read = oFile.good();
        for (int i = 0; i < fileContent.size(); i++)
        {
            for (int j = 0; j < fileContent[i].size(); j++)
            {
                if (j == 0) oFile << fileContent[i][j];
                else oFile << "," << fileContent[i][j];
            }
            oFile << endl;
        }
        oFile.close();
        return read;
    }
};

class Symbol
{
public:
    string name;
    symbolType type;

    Symbol()
    {
        this->name = "";
        this->type = NonTerminal;
    }

    Symbol(string name, symbolType type)
    {
        this->name = name;
        this->type = type;
    }

    string toString()
    {
        string str = this->name; 
        if (this->type == NonTerminal)
        {    
            transform(str.begin(), str.end(), str.begin(), ::toupper);
        }
        else
        {
            transform(str.begin(), str.end(), str.begin(), ::tolower);
        }
        return str;
    }
};


class GrammerRule
{
public:
    Symbol lhs;
    vector<vector<Symbol>> rhs;

    GrammerRule()
    {
        
    }

    GrammerRule(string lhs)
    {
        this->lhs = Symbol(lhs, NonTerminal);
    }

    GrammerRule FromString(string str)
    {
        string lhs;
        vector<string> rhs;
        string tmpStr;
        int resIdx = 0;

        for (int i = 0; i < str.length(); i++)
        {
            if (!(str[i + 1] == '-' && str[i + 2] == '>')) lhs += str[i];
            else
            {
                resIdx = i + 3;
                break;
            }
        }
        for (int i = resIdx; i < str.length(); i++)
        {
            if (!(str[i] == ' '))
            {
                tmpStr += str[i];
            }
            else
            {
                
                if(tmpStr != "" && tmpStr != " ") rhs.push_back(tmpStr);
                tmpStr = "";
            }
        }
        rhs.push_back(tmpStr);

        
        GrammerRule g1(lhs);
        bool startFlag = false;
        for (int i = 0; i < rhs.size(); i++)
        {
            if (i == 0)
            {
                if (isupper(rhs[i][0]))
                {
                    g1.addAtRight(rhs[i], NonTerminal, true);
                }
                else if (islower(rhs[i][0]))
                {
                    g1.addAtRight(rhs[i], Terminal, true);
                }
            }
            else if (isupper(rhs[i][0]))
            {
                if (startFlag)
                {
                    g1.addAtRight(rhs[i], NonTerminal, true);
                    startFlag = false;
                }
                else g1.addAtRight(rhs[i], NonTerminal);
            }
            else if (islower(rhs[i][0]))
            {
                if (startFlag)
                {
                    g1.addAtRight(rhs[i], Terminal, true);
                    startFlag = false;
                }
                else g1.addAtRight(rhs[i], Terminal);
            }
            else
            {
                startFlag = true;
            }
        }
        return g1;
    }

    void addAtRight(string name, symbolType type, bool beginNew = false)
    {
        Symbol s(name, type);
        if (beginNew == true)
        {
            vector<Symbol> tempVec;
            rhs.push_back(tempVec);
        }
        rhs[rhs.size() - 1].push_back(s);
    }

    string toString()
    {
        string str;
        str += this->lhs.toString() + " -> ";
        for (int i = 0; i < rhs.size(); i++)
        {
            for (int j = 0; j < rhs[i].size(); j++)
            {
                str += rhs[i][j].toString() + " ";
            }
            if (i < (rhs.size() - 1))
            {
                str += "| ";
            }
        }
        return str;
    }

    void print()
    {
        cout << this->toString() << endl;
    }

    bool checkLeftRecursion()
    {
        for (int i = 0; i < rhs.size(); i++)
        {
            if (rhs[i][0].name == lhs.name && rhs[i][0].type == lhs.type) return true;
        }
        return false;
    }

    bool checkLeftFactoring()
    {
        for (int i = 0; i < rhs.size(); i++)
        {
            if (rhs[i][0].type == Terminal)
            {
                for (int j = i + 1; j < rhs.size(); j++)
                {
                    if (rhs[j][0].name == rhs[i][0].name && rhs[i][0].type == Terminal) return true;
                }
            }
        }
        return false;
    }

    vector<GrammerRule> fixLeftRecursion()
    {
        vector<GrammerRule> result;
        
        if (this->checkLeftRecursion() == true)
        {
            Symbol recSymbol(this->lhs.name + "'", this->lhs.type);
            GrammerRule A(lhs.name);
            GrammerRule Adash(recSymbol.name);

            for (int i = 0; i < rhs.size(); i++)
            {
                if (rhs[i][0].name == lhs.name && rhs[i][0].type == lhs.type)
                {
                    for (int j = 1; j < rhs[i].size(); j++)
                    {
                        if (j == 1) Adash.addAtRight(rhs[i][j].name, rhs[i][j].type, true);
                        else
                        {
                            Adash.addAtRight(rhs[i][j].name, rhs[i][j].type);
                        }
                    }
                    Adash.addAtRight(recSymbol.name, recSymbol.type);
                }
                else
                {
                    for (int j = 0; j < rhs[i].size(); j++)
                    {
                        if (j == 0) A.addAtRight(rhs[i][j].name, rhs[i][j].type, true);
                        else
                        {
                            A.addAtRight(rhs[i][j].name, rhs[i][j].type);
                        }
                    }
                    A.addAtRight(recSymbol.name, recSymbol.type);
                    
                }
            }
            Adash.addAtRight("Epsilon", Terminal, true);
            result.push_back(A);
            result.push_back(Adash);
        }
        else
        {
            result.push_back(*this);
        }
        return result;
    }
    vector<GrammerRule> fixLeftFactoring()
    {
        vector<GrammerRule> result;

        if (this->checkLeftFactoring() == true)
        {
            Symbol termSymbol;
            Symbol recSymbol(this->lhs.name + "'", this->lhs.type);
            GrammerRule A(lhs.name);
            GrammerRule Adash(recSymbol.name);

            for (int i = 0; i < rhs.size(); i++)
            {
                if (rhs[i][0].type == Terminal)
                {
                    for (int j = i + 1; j < rhs.size(); j++)
                    {
                        if (rhs[j][0].name == rhs[i][0].name && rhs[i][0].type == Terminal)
                        {
                            termSymbol.name = rhs[j][0].name;
                            termSymbol.type = rhs[j][0].type;
                        }
                    }
                }
            }

            A.addAtRight(termSymbol.name, termSymbol.type, true);
            A.addAtRight(recSymbol.name, recSymbol.type);
            for (int i = 0; i < rhs.size(); i++)
            {
                if (rhs[i][0].name == termSymbol.name && rhs[i][0].type == termSymbol.type)
                {
                    for (int j = 1; j < rhs[i].size(); j++)
                    {
                        if (j == 1) Adash.addAtRight(rhs[i][j].name, rhs[i][j].type, true);
                        else
                        {
                            Adash.addAtRight(rhs[i][j].name, rhs[i][j].type);
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < rhs[i].size(); j++)
                    {
                        if (j == 0) A.addAtRight(rhs[i][j].name, rhs[i][j].type, true);
                        else
                        {
                            A.addAtRight(rhs[i][j].name, rhs[i][j].type);
                        }
                    }
                }
            }
            result.push_back(A);
            result.push_back(Adash);
        }
        else
        {
            result.push_back(*this);
        }
        return result;
    }
    
};

class Grammer
{
public:
    vector<GrammerRule> rules;

    Grammer()
    {

    }
    
    void addRule(string str)
    {
        GrammerRule g;
        g = g.FromString(str);
        rules.push_back(g);
    }

    void print()
    {
        for (int i = 0; i < rules.size(); i++)
        {
            rules[i].print();
        }
    }
};

bool validateCharacter(char c)
{
    if (c > -1 && c < 255) return true;
    return false;
}

void perform(string filePath)
{
    ifstream fin;
    fin.open(filePath);
    vector<string> cells;
    string symbol, cell;
    char abc;
    vector<GrammerRule> result;

    for (int i = 0; fin >> abc; i++)
    {
        //cout << abc;
        //cout << validateCharacter(abc) << endl;
        if (abc == ',')
        {
            cells.push_back(cell);
            cell = "";
        }
        else
        {
            if (validateCharacter(abc))
            {
                cell += abc;
                if (abc != '-') cell += ' ';
            }
        }
    }
    cells.push_back(cell);
    
    for (int i = 0; i < cells.size(); i++)
    {
        GrammerRule g1;
        //cout << cells[i] << endl;
        g1 = g1.FromString(cells[i]);
        //g1.print();
        if (g1.checkLeftRecursion())
        {
            cout << "Left Recursion Case    " << cells[i] << endl;
            cout << ".........Solution........." << endl;
            vector<GrammerRule> result = g1.fixLeftRecursion();
            result[0].print();
            result[1].print();
            cout << ".........................."<<endl;
        }
        else if (g1.checkLeftFactoring())
        {
            cout << "Left Factoring Case    " << cells[i] << endl;
            cout << ".........Solution........." << endl;
            vector<GrammerRule> result = g1.fixLeftFactoring();
            result[0].print();
            result[1].print();
            cout << ".........................." << endl;
        }
        
    }

    fin.close();
}

void performA(string filePath)
{
    csvManager m;
    m.read(filePath);
    
    string oName = filePath.substr(0, filePath.length() - 4) + "_OUT.txt";
    ofstream oFile;
    oFile.open(oName);

    for (int i = 0; i < m.fileContent.size(); i++)
    {
        for (int j = 0; j < m.fileContent[i].size(); j++)
        {
            if (m.fileContent[i][j].length() > 0)
            {
                GrammerRule g1;
                g1 = g1.FromString(m.fileContent[i][j]);
                if (g1.checkLeftRecursion())
                {
                    cout << "Left Recursion Case    " << m.fileContent[i][j] << endl;
                    oFile << "Left Recursion Case    " << m.fileContent[i][j] << endl;
                    cout << ".........Solution........." << endl;
                    oFile << ".........Solution........." << endl;
                    vector<GrammerRule> result = g1.fixLeftRecursion();
                    result[0].print();
                    oFile << result[0].toString();
                    result[1].print();
                    oFile << result[1].toString();
                    cout << ".........................." << endl;
                    oFile << ".........................." << endl;
                }
                else if (g1.checkLeftFactoring())
                {
                    cout << "Left Factoring Case    " << m.fileContent[i][j] << endl;
                    oFile << "Left Factoring Case    " << m.fileContent[i][j] << endl;
                    cout << ".........Solution........." << endl;
                    oFile << ".........Solution........." << endl;
                    vector<GrammerRule> result = g1.fixLeftFactoring();
                    result[0].print();
                    oFile << result[0].toString();
                    result[1].print();
                    oFile << result[1].toString();
                    cout << ".........................." << endl;
                    oFile << ".........................." << endl;
                }
            }
        }
    }
    
    
}

int main()
{
    performA("E:\\git\\CC-Course\\CC-Assignment4 - Left Factoring & Left Recursion\\infile.csv");

}

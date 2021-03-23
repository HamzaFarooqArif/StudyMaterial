#include <iostream>
#include <string>
#include <vector>
#include <fstream>
#include <sstream> 
#include <unordered_map> 

using namespace std;

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

class KeywordHandler
{
public:
    csvManager manager;
    unordered_multimap<string, unsigned long> keywords;
    int capacity;

    KeywordHandler()
    {
        capacity = 5000;
    }
    
    unsigned long hash_function(string str) {
        unsigned long i = 0;
        for (int j = 0; str[j]; j++)
            i += str[j];
        return i % capacity;
    }

    bool insert(string str)
    {
        unsigned long key = hash_function(str);
        keywords.insert({ str, key });
        return true;
    }

    unsigned long getValue(string str)
    {
        for (auto& elm : keywords) 
        {
            if (elm.first == str)
            {
                return elm.second;
            }
        }
        return 0;
    }

    void addPrimitiveKeywords()
    {
        this->insert("abstract");
        this->insert("as");
        this->insert("base");
        this->insert("bool");
        this->insert("break");
        this->insert("byte");
        this->insert("case");
        this->insert("catch");
        this->insert("char");
        this->insert("checked");
        this->insert("class");
        this->insert("const");
        this->insert("continue");
        this->insert("decimal");
        this->insert("default");
        this->insert("delegate");
        this->insert("do");
        this->insert("double");
        this->insert("else");
        this->insert("enum");
        this->insert("event");
        this->insert("explicit");
        this->insert("extern");
        this->insert("false");
        this->insert("finally");
        this->insert("finally");
        this->insert("float");
        this->insert("for");
        this->insert("foreach");
        this->insert("goto");
        this->insert("if");
        this->insert("implicit");
        this->insert("in");
        this->insert("int");
        this->insert("interface");
        this->insert("internal");
        this->insert("is");
        this->insert("lock");
        this->insert("long");
        this->insert("namespace");
        this->insert("new");
        this->insert("null");
        this->insert("object");
        this->insert("operator");
        this->insert("out");
        this->insert("override");
        this->insert("params");
        this->insert("private");
        this->insert("protected");
        this->insert("public");
        this->insert("readonly");
        this->insert("ref");
        this->insert("return");
        this->insert("sbyte");
        this->insert("sealed");
        this->insert("short");
        this->insert("sizeof");
        this->insert("stackalloc");
        this->insert("static");
        this->insert("string");
        this->insert("struct");
        this->insert("switch");
        this->insert("this");
        this->insert("throw");
        this->insert("true");
        this->insert("try");
        this->insert("typeof");
        this->insert("uint");
        this->insert("ulong");
        this->insert("unchecked");
        this->insert("unsafe");
        this->insert("ushort");
        this->insert("using");
        this->insert("using");
        this->insert("virtual");
        this->insert("void");
        this->insert("volatile");
        this->insert("while");
        this->insert("nameof");
        this->insert("join");
        this->insert("global");
        this->insert("group");
        this->insert("value");
        this->insert("var");
        this->insert("set");
    }

    void loadFromFile(string filePath)
    {
        manager.read(filePath);
        for (int i = 0; i < manager.fileContent.size(); i++)
        {
            for (int j = 0; j < manager.fileContent[i].size(); j++)
            {
                this->insert(manager.fileContent[i][j]);
            }
        }
    }

    void getInput()
    {
        while (true)
        {
            string inStr;
            cout << "Enter a Keyword: ";
            cin >> inStr;
            unsigned long value = getValue(inStr);
            if (value != 0)
            {
                cout << "This keyword exists with hashvalue: " << value << endl;
            }
            else
            {
                cout << "This keyword doesn't exist." << endl;
            }
        }
    }
};

int main()
{
   KeywordHandler kh;
   kh.loadFromFile("E:\\git\\CC-Course\\CC-Assignment8 - Keyword Handler using Hashtable\\infile.csv");
   kh.getInput();
}
#include <iostream>
#include <string>
#include <fstream>
#include <sstream>
#include <vector>

using namespace std;
ifstream ifile;
int state = 0;
int seek = 0;

class Token
{
public:
    string name;
    string attribute;

    Token(string name)
    {
        this->name = name;
        this->attribute = "";
    }
};
char nextChar()
{
    char* readChar = new char[1];
    char retChar;
    if (ifile.read(readChar, 1))
    {
        retChar = readChar[0];
        delete[] readChar;
        seek++;
    }
    else
    {
        retChar = EOF;
    }
    return retChar;
}
void retract(int length = 1)
{
    seek -= length;
    ifile.seekg(seek, ifile.beg);
}

class Transition
{
public:
    string character;
    string state;

    Transition(string character, string state)
    {
        this->character = character;
        this->state = state;
    }
};

class TTNode
{
public:
    string number;
    bool isStart;
    bool isFinal;
    string retToken;
    vector<Transition> transitions;

    TTNode(string number, bool isStart, bool isFinal, string retToken)
    {
        this->number = number;
        this->isStart = isStart;
        this->isFinal = isFinal;
        this->retToken = retToken;
    }
};

class TransitionTable
{
public:
    string name;
    vector<TTNode> nodes;
    vector<string> chars;

    TransitionTable(string filePath, string name)
    {
        ifstream fin;
        this->name = name;
        fin.open(filePath);
        vector<string> row;
        string line, word;
        
        for (int i = 0; fin >> line; i++)
        {
            row.clear();
            stringstream s(line);
            while (getline(s, word, ',')) {
                row.push_back(word);
                //cout << word << endl;
            }

            if (i == 0)
            {
                for (int j = 3; j < row.size(); j++)
                {
                    chars.push_back(row[j]);
                }
            }
            else
            {
                TTNode ttnode = generateNode(row);
                nodes.push_back(ttnode);
            }
        }
        fin.close();
    }

    TTNode generateNode(vector<string> row)
    {
        int number = -1;
        bool isStart = false;
        bool isFinal = false;
        string retToken = "";

        if (row[1] == "\"\"\"->\"\"\"") isStart = true;
        else if (row[1] == "\"\"\"*\"\"\"")
        {
            retToken = row[0];
            isFinal = true;
        }
        
        TTNode ttn(row[2], isStart, isFinal, row[0]);
        
        for (int i = 3; i < row.size(); i++)
        {
            if (row[i] != "-1")
            {
                Transition tr(chars[i - 3], row[i]);
                ttn.transitions.push_back(tr);
            }
        }
        return ttn;
    }
    Token getToken()
    {
        int stateLoc = 0;        
        //bool stateChanged = false;
        Token Tok(this->name);
        for (int i = 0; i < nodes.size(); i++)
        {
            if (nodes[i].isStart)
            {
                stateLoc = stoi(nodes[i].number);
            }
        }
        while (true)
        {
            if (nodes[stateLoc].isFinal)
            {
                Tok.attribute = nodes[stateLoc].retToken;
                return Tok;
            }
            char chrc = nextChar();
            if (chrc == EOF) break;
            string chr(1, chrc);
            bool stateChanged = false;
            for (int i = 0; i < nodes[stateLoc].transitions.size(); i++)
            {
                //cout << nodes[i].transitions[j].character << endl;
                if (nodes[stateLoc].transitions[i].character == chr)
                {
                    stateLoc = stoi(nodes[stateLoc].transitions[i].state);
                    stateChanged = true;
                    break;
                }
            }
            if (!stateChanged)
            {
                for (int i = 0; i < nodes[stateLoc].transitions.size(); i++)
                {
                    if (nodes[stateLoc].transitions[i].character == "other")
                    {
                        retract();
                        stateLoc = stoi(nodes[stateLoc].transitions[i].state);
                        break;
                    }
                }
            }
        }
        
        Tok.attribute = "Error";
        return Tok;
    }
};

int main()
{
    ifile.open("E:\\git\\CC-Course\\CC-Assignment3 - Lexical Analyzer from TT\\CC-Assignment3\\infile.txt");
    TransitionTable T("E:\\git\\CC-Course\\CC-Assignment3 - Lexical Analyzer from TT\\CC-Assignment3\\infile.csv", "RELOP");
    cout<<T.getToken().attribute<<endl;
}

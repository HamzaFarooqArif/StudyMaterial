#include <iostream>
#include <string>
#include <fstream>

using namespace std;

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

ifstream ifile;
int state = 0;
int seek = 0;

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

Token getRelop()
{
    Token retToken("RELOP");
    char c = nextChar();
    if (c == EOF) retToken.attribute = "EOF";
    else if (c == '<')
    {
        c = nextChar();
        if (c == '=')
        {
            retToken.attribute = "LE";
        }
        else if (c == '>')
        {
            retToken.attribute = "NE";
        }
        else
        {
            retract();
            retToken.attribute = "LT";
        }
    }
    else if (c == '>')
    {
        c = nextChar();
        if (c == '=')
        {
            retToken.attribute = "GE";
        }
        else
        {
            retract();
            retToken.attribute = "GT";
        }
    }
    else if (c == '=')
    {
        retToken.attribute = "EQ";
    }
    else
    {
        retract();
        retToken.attribute = "Failed";
    }
    return retToken;
}
Token getId()
{
    Token retToken("ID");
    char c = nextChar();
    string idAttr;
    idAttr += c;
    if (c == EOF) retToken.attribute = "EOF";
    if (isdigit(c))
    {
        retract();
        retToken.attribute = "Failed";
        return retToken;
    }
    while (true)
    {
        c = nextChar();
        if (isdigit(c) || isalpha(c))
        {
            idAttr += c;
        }
        else
        {
            retToken.attribute = idAttr;
            break;
        }
    }
    return retToken;
}
Token getNumber()
{
    Token retToken("NUMBER");
    char c = nextChar();
    string idAttr;
    idAttr += c;
    if (c == EOF) retToken.attribute = "EOF";
    if (!isdigit(c))
    {
        retract();
        retToken.attribute = "Failed";
        return retToken;
    }
    while (true)
    {
        c = nextChar();
        if (isdigit(c))
        {
            idAttr += c;
        }
        else if (c == '.')
        {
            idAttr += c;
            while (true)
            {
                c = nextChar();
                if (isdigit(c))
                {
                    idAttr += c;
                }
                else
                {
                    break;
                }
            }
        }
        else
        {
            retToken.attribute = idAttr;
            break;
        }
    }
    return retToken;
}
Token getWs()
{
    Token retToken("WS");
    char c = nextChar();
    string idAttr;
    idAttr += c;
    if (c == EOF) retToken.attribute = "EOF";
    if (!(c == '   ' || c == ' ' || c == '\n' || c == ';'))
    {
        retract();
        retToken.attribute = "Failed";
        return retToken;
    }
    while (true)
    {
        c = nextChar();
        if (c == '   ' || c == ' ' || c == '\n' || c == ';')
        {
            idAttr += c;
        }
        else
        {
            retToken.attribute = idAttr;
            break;
        }
    }
    return retToken;
}

Token getToken()
{
    Token t = getRelop();
    if (t.attribute == "Failed")
    {
        t = getId();
        if (t.attribute == "Failed")
        {
            t = getNumber();
            if (t.attribute == "Failed")
            {
                t = getWs();
            }
        }
    }
    return t;
}
int main()
{
    ifile.open("E:\\git\\CC-Course\\CC-Assignment2 - Lexical Analyzer\\infile.txt");

    while (true)
    {
        Token t = getToken();
        if (t.attribute == "Failed")
        {
            cout << "Failed";
            break;
        }
        else if (t.attribute == "EOF") break;
        else if (t.name != "WS")
        {
            cout << "<" << t.name << ", " << t.attribute << ">";
        }
    }
    cout << endl;
    ifile.close();
    return 0;
}
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
    state = 0;
    char c = EOF;
    bool isFailed = false;
    while (true)
    {
        switch (state)
        {
        case 0:
            c = nextChar();
            if (c == '<') state = 1;
            else if (c == '=')
            {
                state = 5;
                retToken.attribute = "EQ";
                return retToken;
            }
            else if (c == '>') state = 6;
            else
            {
                retract();
                isFailed = true;
            }
            break;
        case 1:
            c = nextChar();
            if (c == '=')
            {
                state = 2;
                retToken.attribute = "LE";
                return retToken;
            }
            else if (c == '>')
            {
                state = 3;
                retToken.attribute = "NE";
                return retToken;
            }
            else
            {
                retract();
                state = 4;
                retToken.attribute = "LT";
                return retToken;
            }
        case 6:
            c = nextChar();
            if (c == '=')
            {
                state = 7;
                retToken.attribute = "GE";
                return retToken;
            }
            else
            {
                retract();
                state = 8;
                retToken.attribute = "GT";
                return retToken;
            }
        default:
            break;
        }
        if (c == EOF)
        {
            retToken.attribute = "EOF";
            break;
        }
        if (isFailed)
        {
            retToken.attribute = "Failed";
            break;
        }
    }
    return retToken;
}
Token getId()
{
    Token retToken("ID");
    state = 9;
    char c = EOF;
    bool isFailed = false;
    string idAttr = "";
    while (true)
    {
        switch (state)
        {
        case 9:
            c = nextChar();
            if (isalpha(c))
            {
                state = 10;
                idAttr += c;
            }
            else
            {
                retract(idAttr.length() + 1);
                isFailed = true;
            }
            break;
        case 10:
            c = nextChar();
            if (isalpha(c) || isdigit(c))
            {
                state = 10;
                idAttr += c;
            }
            else
            {
                retract();
                state = 11;
                if (idAttr.length() == 0) idAttr = "Failed";
                retToken.attribute = idAttr;
                return retToken;
            }
            break;
        default:
            break;
        }
        if (c == EOF)
        {
            retToken.attribute = "EOF";
            break;
        }
        if (isFailed)
        {
            retToken.attribute = "Failed";
            break;
        }
    }
    return retToken;
}
Token getNumber()
{
    Token retToken("NUMBER");
    state = 12;
    char c = EOF;
    bool isFailed = false;
    string idAttr = "";
    while (true)
    {
        switch (state)
        {
        case 12:
            c = nextChar();
            if (isdigit(c))
            {
                state = 13;
                idAttr += c;
            }
            else
            {
                retract(idAttr.length() + 1);
                isFailed = true;
            }
            break;
        case 13:
            c = nextChar();
            if (isdigit(c))
            {
                state = 13;
                idAttr += c;
            }
            else if (c == '.')
            {
                state = 14;
                idAttr += c;
            }
            else if (c == 'E')
            {
                state = 16;
                idAttr += c;
            }
            else
            {
                state = 20;
                retract();
                if (idAttr.length() == 0) idAttr = "Failed";
                retToken.attribute = idAttr;
                return retToken;
            }
            break;
        case 14:
            c = nextChar();
            if (isdigit(c))
            {
                state = 15;
                idAttr += c;
            }
            else
            {
                retract(idAttr.length() + 1);
                isFailed = true;
            }
            break;
        case 15:
            c = nextChar();
            if (isdigit(c))
            {
                state = 15;
                idAttr += c;
            }
            else if (c == 'E')
            {
                state = 16;
                idAttr += c;
            }
            else
            {
                state = 21;
                retract();
                if (idAttr.length() == 0) idAttr = "Failed";
                retToken.attribute = idAttr;
                return retToken;
            }
            break;
        case 16:
            c = nextChar();
            if (isdigit(c))
            {
                state = 18;
                idAttr += c;
            }
            else if (c == '+' || c == '-')
            {
                state = 17;
                idAttr += c;
            }
            else
            {
                retract(idAttr.length() + 1);
                isFailed = true;
            }
            break;
        case 17:
            c = nextChar();
            if (isdigit(c))
            {
                state = 18;
                idAttr += c;
            }
            else
            {
                retract(idAttr.length() + 1);
                isFailed = true;
            }
            break;
        case 18:
            c = nextChar();
            if (isdigit(c))
            {
                state = 18;
                idAttr += c;
            }
            else
            {
                state = 19;
                retract();
                if (idAttr.length() == 0) idAttr = "Failed";
                retToken.attribute = idAttr;
                return retToken;
            }
            break;
        default:
            break;
        }
        if (c == EOF)
        {
            retToken.attribute = "EOF";
            break;
        }
        if (isFailed)
        {
            retToken.attribute = "Failed";
            break;
        }
    }
    return retToken;
}
Token getWs()
{
    Token retToken("WS");
    state = 22;
    char c = EOF;
    bool isFailed = false;
    string idAttr = "";
    while (true)
    {
        switch (state)
        {
        case 22:
            c = nextChar();
            if (c == '   ' || c == ' ' || c == '\n' || c == ';')
            {
                state = 23;
                idAttr += c;
            }
            else
            {
                retract(idAttr.length() + 1);
                isFailed = true;
            }
        case 23:
            c = nextChar();
            if (c == '   ' || c == ' ' || c == '\n' || c == ';')
            {
                state = 23;
                idAttr += c;
            }
            else
            {
                state = 24;
                retract();
                if (idAttr.length() == 0) idAttr = "Failed";
                retToken.attribute = idAttr;
                return retToken;
            }
        default:
            break;
        }
        if (c == EOF)
        {
            retToken.attribute = "EOF";
            break;
        }
        if (isFailed)
        {
            retToken.attribute = "Failed";
            break;
        }
    }
    return retToken;
}

int lineNumber = 1;
bool lineInced = false;
void incLine()
{
    if (lineInced) return;
    else 
    {
        lineNumber++;
        lineInced = true;
    }
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
    ifile.open("E:\\git\\CC-Course\\CC-Assignment7 - Error Handler\\infile.txt");

    while (true)
    {
        Token t = getToken();
        if (t.attribute == "Failed")
        {
            cout << endl;
            cout << "Failed at Line # " << lineNumber;
            break;
        }
        else if (t.attribute == "EOF") break;
        else
        {
            if (t.attribute[0] == '\n') 
            {
                cout << endl;
                incLine();
            }
            else
            {
                cout << "<" << t.name << ", " << t.attribute << ">" << endl;
                lineInced = false;
            }
        }
    }
    cout << endl;
    ifile.close();
    return 0;
}
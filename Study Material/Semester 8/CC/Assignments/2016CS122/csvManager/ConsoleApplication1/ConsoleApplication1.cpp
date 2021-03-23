#include <iostream>
#include <string>
#include <vector>
#include <fstream>
#include <sstream>

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

int main()
{
    csvManager m;
    m.addCell("a", 0, 0);
    m.addCell("b", 1, 1);
    m.addCell("c", 2, 2);
    m.addCell("d", 3, 3);

    m.writeToFile("E:\\infilew.csv");
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file

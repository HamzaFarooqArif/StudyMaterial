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

class FirstndFollow
{
public:
	int count, p;
	int size1 = 100;
	char calc_first[100][100];

	// Stores the final result 
	// of the Follow Sets 
	char calc_follow[100][100];
	int q;

	// Stores the production rules 
	char productions[100][100];
	char f[100], first[100];
	int k;
	char ck;
	int e;


	FirstndFollow()
	{
		p = 0;
		q = 0;
		count = 0;
	}

	void findfollowfirst(char chr, int chr2, int chr3)
	{
		int l;
		if (!(isupper(chr)))
			f[q++] = chr;
		else
		{
			int i = 0, j = 1;
			for (i = 0; i < count; i++)
			{
				if (calc_first[i][0] == chr)
					break;
			}
			while (calc_first[i][j] != '!')
			{
				if (calc_first[i][j] != '#')
				{
					f[q++] = calc_first[i][j];
				}
				else
				{
					if (productions[chr2][chr3] == '\0')
					{
						follow(productions[chr2][0]);
					}
					else
					{
						findfollowfirst(productions[chr2][chr3], chr2, chr3 + 1);
					}
				}
				j++;
			}
		}
	}
	void follow(char c)
	{
		int i;
		int j;
		if (productions[0][0] == c) {
			f[q++] = '$';
		}
		for (i = 0; i < 100; i++)
		{
			for (j = 2; j < 100; j++)
			{
				if (productions[i][j] == c)
				{
					if (productions[i][j + 1] != '\0')
					{
						findfollowfirst(productions[i][j + 1], i, (j + 2));
					}

					if (productions[i][j + 1] == '\0' && c != productions[i][0])
					{
						follow(productions[i][0]);
					}
				}
			}
		}
	}
	void findfirst(char c, int q1, int q2)
	{
		int j;

		if (!(isupper(c))) {
			first[p++] = c;
		}
		for (j = 0; j < count; j++)
		{
			if (productions[j][0] == c)
			{
				if (productions[j][2] == '#')
				{
					if (productions[q1][q2] == '\0')
						first[p++] = '#';
					else if (productions[q1][q2] != '\0'
						&& (q1 != 0 || q2 != 0))
					{
						findfirst(productions[q1][q2], q1, (q2 + 1));
					}
					else
						first[p++] = '#';
				}
				else if (!isupper(productions[j][2]))
				{
					first[p++] = productions[j][2];
				}
				else
				{
					findfirst(productions[j][2], j, 3);
				}
			}
		}
	}

	void addProdcution(string str)
	{
		char* chr = const_cast<char*>(str.c_str());
		strcpy_s(productions[count], chr);
		count++;
	}

	void inputFile(string filePath)
	{
		csvManager m;
		m.read(filePath);

		for (int i = 0; i < m.fileContent.size(); i++)
		{
			for (int j = 0; j < m.fileContent[i].size(); j++)
			{
				if (m.fileContent[i][j].length() > 1)
				{
					addProdcution(m.fileContent[i][j]);
				}
			}
		}
	}

	void perform()
	{
		int jm = 0;
		int km = 0;
		int i, choice;
		char c, ch;

		int kay;
		char done[100];
		char donee[100];
		int ptr = -1;

		for (k = 0; k < count; k++) {
			for (kay = 0; kay < 100; kay++) {
				calc_first[k][kay] = '!';
			}
		}
		int point1 = 0, point2, pointx;

		for (k = 0; k < count; k++)
		{
			c = productions[k][0];
			point2 = 0;
			pointx = 0;

			for (kay = 0; kay <= ptr; kay++)
				if (c == done[kay])
					pointx = 1;

			if (pointx == 1)
				continue;

			findfirst(c, 0, 0);
			ptr += 1;

			done[ptr] = c;
			cout << "First(" << c << ") = {";
			calc_first[point1][point2++] = c;

			for (i = 0 + jm; i < p; i++) {
				int lark = 0, chk = 0;

				for (lark = 0; lark < point2; lark++) {

					if (first[i] == calc_first[point1][lark])
					{
						chk = 1;
						break;
					}
				}
				if (chk == 0)
				{
					if (i == jm) cout << first[i];
					else cout<<", "<< first[i];
					calc_first[point1][point2++] = first[i];
				}
			}
			cout << "}"<<endl;
			jm = p;
			point1++;
		}
		cout << "-----------------------------------------------" << endl;
		ptr = -1;

		for (k = 0; k < count; k++) {
			for (kay = 0; kay < 100; kay++) {
				calc_follow[k][kay] = '!';
			}
		}
		point1 = 0;
		int land = 0;
		for (e = 0; e < count; e++)
		{
			ck = productions[e][0];
			point2 = 0;
			pointx = 0;

			for (kay = 0; kay <= ptr; kay++)
				if (ck == donee[kay])
					pointx = 1;

			if (pointx == 1)
				continue;
			land += 1;

			follow(ck);
			ptr += 1;

			donee[ptr] = ck;
			cout << "Follow(" << ck << ") = {";
			calc_follow[point1][point2++] = ck;

			for (i = 0 + km; i < q; i++) {
				int lark = 0, chk = 0;
				for (lark = 0; lark < point2; lark++)
				{
					if (f[i] == calc_follow[point1][lark])
					{
						chk = 1;
						break;
					}
				}
				if (chk == 0)
				{
					if (i == km) cout << f[i];
					else cout << ", " << f[i];
					calc_follow[point1][point2++] = f[i];
				}
			}
			cout << "}" << endl;
			km = q;
			point1++;
		}
	}

};

int main()
{
	FirstndFollow ff;
	ff.inputFile("E:\\git\\CC-Course\\CC-Assignment6 - First and Follow\\infile.csv");
	ff.perform();
}
#include <iostream>
#include <vector>

using namespace std;

void print(int** arr, int size)
{
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			cout << arr[i][j];
		}
		cout << endl;
	}
}

int findCost(int** arr, int size)
{
	int i = 0;
	int j = 0;
	int temp = arr[0][0];
	while (i < size - 1 && j < size - 1)
	{
		//cout << arr[i][j] << endl;
		if (i + 1 < size && j + 1 < size)
		{
			if (arr[i + 1][j] < arr[i][j + 1])
			{
				temp = temp + arr[i + 1][j];
				i++;
			}
			else
			{
				temp = temp + arr[i][j + 1];
				j++;
			}
		}
		else if (i + 1 < size)
		{
			temp = temp + arr[i + 1][j];
			i++;
		}
		else if (j + 1 < size)
		{
			temp = temp + arr[i][j + 1];
			j++;
		}
	}
	return temp;
}

vector<int> sequence(int** arr, int size, int I, int J)
{
	vector<int> result;
	result.push_back(arr[I][J]);
	while (true)
	{
		//cout << arr[I][J] << endl;
		if(J+1< size && arr[I][J]+1 == arr[I][J+1])
		{
			result.push_back(arr[I][J + 1]);
			J++;
		}
		else if (I + 1< size && arr[I][J] + 1 == arr[I + 1][J]){
			result.push_back(arr[I + 1][J]);
			I++;
		}
		else if (J - 1 >= 0 && arr[I][J] + 1 == arr[I][J - 1]){
			result.push_back(arr[I][J - 1]);
			J--;
		}
		else if (I - 1 >= 0 && arr[I][J] + 1 == arr[I-1][J]){
			result.push_back(arr[I - 1][J]);
			I--;
		}
		else
		{
			break;
		}
	}
	return result;
}

int getSequenceSize(int** arr, int size)
{
	vector<int> result;
	int globalSize = 0;
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			result = sequence(arr, size, i, j);
			if (result.size() > globalSize)
			{
				globalSize = result.size();
			}
		}
	}
	return globalSize;
}

vector<int> getSequence(int** arr, int size, int globalSize)
{
	vector<int> result;
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			result = sequence(arr, size, i, j);
			if (result.size() == globalSize)
			{
				return result;
			}
		}
	}
}


int main()
{
	int size = 5;
	int** arr = new int*[size];
	for (int i = 0; i < size; i++)
	{
		arr[i] = new int[size];
	}

	arr[0][0] = 10;
	arr[0][1] = 13;
	arr[0][2] = 14;
	arr[0][3] = 21;
	arr[0][4] = 23;

	arr[1][0] = 11;
	arr[1][1] = 9;
	arr[1][2] = 22;
	arr[1][3] = 2;
	arr[1][4] = 3;

	arr[2][0] = 12;
	arr[2][1] = 8;
	arr[2][2] = 1;
	arr[2][3] = 5;
	arr[2][4] = 4;

	arr[3][0] = 15;
	arr[3][1] = 24;
	arr[3][2] = 7;
	arr[3][3] = 6;
	arr[3][4] = 20;

	arr[4][0] = 16;
	arr[4][1] = 17;
	arr[4][2] = 18;
	arr[4][3] = 19;
	arr[4][4] = 25;

	//print(arr, size);
	vector <int> result = getSequence(arr, size, getSequenceSize(arr, size));
	for (int i = 0; i < size; i++)
	{
		if(i < size-1) cout << result[i] << "-";
		else cout << result[i];
	}
	cout << endl;
	//cout << findCost(arr, size) << endl;
	system("pause");
	return 0;
}
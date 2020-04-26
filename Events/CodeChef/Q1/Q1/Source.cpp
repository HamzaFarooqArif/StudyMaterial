#include <iostream>

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
	while (i < size-1 && j < size-1)
	{
		cout << arr[i][j] << endl;
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

int main()
{
	int size = 5;
	int** arr = new int*[size];
	for (int i = 0; i < size; i++)
	{
		arr[i] = new int[size];
	}

	arr[0][0] = 4;
	arr[0][1] = 7;
	arr[0][2] = 8;
	arr[0][3] = 6;
	arr[0][4] = 4;

	arr[1][0] = 6;
	arr[1][1] = 7;
	arr[1][2] = 3;
	arr[1][3] = 9;
	arr[1][4] = 2;

	arr[2][0] = 3;
	arr[2][1] = 8;
	arr[2][2] = 1;
	arr[2][3] = 2;
	arr[2][4] = 4;

	arr[3][0] = 7;
	arr[3][1] = 1;
	arr[3][2] = 7;
	arr[3][3] = 3;
	arr[3][4] = 7;

	arr[4][0] = 2;
	arr[4][1] = 9;
	arr[4][2] = 8;
	arr[4][3] = 9;
	arr[4][4] = 3;

	//print(arr, size);

	cout<<findCost(arr, size)<<endl;
	system("pause");
	return 0;
}
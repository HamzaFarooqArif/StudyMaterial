#include <iostream> 
#include <fstream>
#include <thread> 
#include <chrono>

using namespace std;
using namespace std::chrono;

ifstream ifile;
char* buffer0;
char* buffer1;
bool loadBuffer0 = true;
bool loadBuffer1 = true;
int bufferSize = 100000000;
bool eof = false;
int charCount = 0;
bool isPrinted0 = false;
bool isPrinted1 = false;
steady_clock::time_point time1;

void loadBuffer()
{
	while (!eof)
	{
		if (loadBuffer0)
		{
			if (!ifile.read(buffer0, bufferSize))
			{
				eof = true;
			}
			loadBuffer0 = false;
		}
		if (loadBuffer1)
		{
			if (!ifile.read(buffer1, bufferSize))
			{
				eof = true;
			}
			loadBuffer1 = false;
		}
	}
}

void printBuffer(int idx)
{
	char* ptr = buffer0;
	bool proceed = false;
	if (idx == 0)
	{
		if (loadBuffer0)
		{
			if (!isPrinted0)
			{
				cout << "Buffer0 Loading.				T=" << duration_cast<microseconds>(high_resolution_clock::now() - time1).count()<<" microSeconds"<<endl;
				isPrinted0 = true;
			}
		}
		else
		{
			if (isPrinted0)
			{
				cout << "Buffer0 Loaded.					T=" << duration_cast<microseconds>(high_resolution_clock::now() - time1).count() << " microSeconds" << endl;
				isPrinted0 = false;
			}
			ptr = buffer0;
			proceed = true;
			charCount = 0;
		}
	}
	else
	{
		if (loadBuffer1)
		{
			if (!isPrinted1)
			{
				cout << "Buffer1 Loading.				T=" << duration_cast<microseconds>(high_resolution_clock::now() - time1).count() << " microSeconds" << endl;
				isPrinted1 = true;
			}
		}
		else
		{
			if (isPrinted1)
			{
				cout << "Buffer1 Loaded.					T=" << duration_cast<microseconds>(high_resolution_clock::now() - time1).count() << " microSeconds" << endl;
				isPrinted1 = false;
			}
			ptr = buffer1;
			proceed = true;
			charCount = 0;
		}
	}
	if (proceed)
	{
		cout << "Read started from buffer "<<idx<<"			T="<< duration_cast<microseconds>(high_resolution_clock::now() - time1).count() << " microSeconds" << endl;
		while (*ptr != NULL) {
			char el = '\n';
			if (*ptr != el)
			{
				//cout << *ptr;
			}
			ptr++;
			charCount++;
		}
		cout << "Total chars read from buffer"<<idx<<": "<< charCount << "	T=" << duration_cast<microseconds>(high_resolution_clock::now() - time1).count() << " microSeconds" << endl;
		proceed = false;
	}
}

int main()
{
	time1 = high_resolution_clock::now();
	ifile.open("E:\git\CC-Course\CC-Assignment1 - Double Buffer\\ifile.txt");
	buffer0 = new char[bufferSize];
	buffer1 = new char[bufferSize];
	thread t1(loadBuffer);
	while (!eof)
	{
		printBuffer(0);
		loadBuffer0 = true;
		printBuffer(1);
		loadBuffer1 = true;
	}
	t1.join();
	
	return 0;
}
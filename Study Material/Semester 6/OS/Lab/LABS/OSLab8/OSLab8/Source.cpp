#include <iostream>
#include <vector>
#include <string>

using namespace std;

class Process
{
public:
	int id;
	int size;

	Process()
	{
		this->id = -1;
		this->size = 0;
	}

	Process(int id, int size)
	{
		this->id = id;
		this->size = size;
	}
};

class MemoryBlock
{
public:
	int id;
	int size;
	Process* currentProcess;
	MemoryBlock* next;

	MemoryBlock()
	{
		this->id = -1;
		this->size = 0;
		this->currentProcess = NULL;
		this->next = NULL;
	}

	MemoryBlock(int id, int size)
	{
		this->id = id;
		this->size = size;
		this->currentProcess = NULL;
		this->next = NULL;
	}

	MemoryBlock(int id, int size, Process*& p)
	{
		this->id = id;
		this->size = size;
		this->currentProcess = p;
		p = NULL;
		this->next = NULL;
	}

	MemoryBlock(int id, int size, Process*& p, MemoryBlock* m)
	{
		this->id = id;
		this->size = size;
		this->currentProcess = p;
		p = NULL;
		this->next = m;
	}

	bool assignProcess(Process*& p)
	{
		if (this->size >= p->size)
		{
			this->currentProcess = p;
			p = NULL;
			return true;
		}
		return false;
	}
};

class MemoryChunk
{
public:
	MemoryBlock* head;

	MemoryChunk()
	{
		MemoryBlock* m = new MemoryBlock();
		this->head = m;
	}

	MemoryChunk(MemoryBlock* m)
	{
		this->head = m;
	}

	void addBlock(MemoryBlock* m)
	{
		if (this->head == NULL) this->head = m;
		if(this->head->id == -1) this->head = m;
		else
		{
			MemoryBlock* ptr = this->head;
			MemoryBlock* rptr = this->head;
			while (ptr != NULL)
			{
				rptr = ptr;
				ptr = ptr->next;
			}
			rptr->next = m;
		}
	}

	MemoryBlock* getMemoryBlockByProcessId(int pid)
	{
		MemoryBlock* ptr = this->head;
		int actualSize = 0;
		while (ptr != NULL)
		{
			ptr = ptr->next;
			actualSize++;
		}

		for (int i = 0; i < actualSize; i++)
		{
			if (this->getMemoryBlockAtIndex(i)->currentProcess != NULL)
			{
				if (this->getMemoryBlockAtIndex(i)->currentProcess->id == pid)
				{
					return this->getMemoryBlockAtIndex(i);
				}
			}
		}
		return NULL;
	}

	MemoryBlock* getMemoryBlockAtIndex(int idx)
	{
		MemoryBlock* ptr = this->head;
		
		int actualSize = 0;
		while (ptr != NULL)
		{
			ptr = ptr->next;
			actualSize++;
		}

		if (this->head == NULL) return ptr;
		if (idx > actualSize) return ptr;

		ptr = this->head;
		for (int i = 0; i < idx; i++)
		{
			ptr = ptr->next;
		}
		return ptr;
	}

	Process* getProcessById(int id)
	{
		for (int i = 0; i < INT_MAX; i++)
		{
			if (getMemoryBlockAtIndex(i)->currentProcess == NULL) break;
			if (getMemoryBlockAtIndex(i)->currentProcess->id == id) return getMemoryBlockAtIndex(i)->currentProcess;
		}
		return NULL;
	}
	//-----------------------------------------------------------------------------
	//First Fit--------------------------------------------------------------------
	MemoryBlock* getCloseSizeFF(int size)
	{
		MemoryBlock* ptr = this->head;
		MemoryBlock* rptr = this->head;
	
		if (this->head == NULL) return ptr;
	
		while (ptr != NULL)
		{
			if (ptr->size >= size && ptr->currentProcess == NULL) return ptr;
			ptr = ptr->next;
		}
		return ptr;
	}
	
	bool addProcessFF(Process*& p)
	{
		if (p == NULL) return false;
		MemoryBlock* mb = getCloseSizeFF(p->size);
		if (mb != NULL)
		{
			mb->assignProcess(p);
			return true;
		}
		else return false;
	}
	//-----------------------------------------------------------------------------
	//Best Fit---------------------------------------------------------------------
	MemoryBlock* getCloseSizeBF(int size)
	{
		MemoryBlock* ptr = this->head;
		MemoryBlock* rptr = this->head;
		MemoryBlock* tempPtr = NULL;

		if (this->head == NULL) return ptr;

		int diff = INT_MAX;

		while (ptr != NULL)
		{
			if (ptr->size >= size && ((ptr->size - size) < diff) && ptr->currentProcess == NULL)
			{
				diff = ptr->size - size;
				tempPtr = ptr;
			}
			ptr = ptr->next;
		}
		return tempPtr;
	}

	bool addProcessBF(Process*& p)
	{
		if (p == NULL) return false;
		MemoryBlock* mb = getCloseSizeBF(p->size);
		if (mb != NULL)
		{
			mb->assignProcess(p);
			return true;
		}
		else return false;
	}
	//-----------------------------------------------------------------------------
	void print()
	{
		
		MemoryBlock* ptr = this->head;
		MemoryBlock* rptr = this->head;
		while (ptr != NULL)
		{
			cout << " BlockID:" << ptr->id << " BlockSize:" << ptr->size;
			if (ptr->currentProcess != NULL) cout << " ProcessID:" << ptr->currentProcess->id << " ProcessSize:" << ptr->currentProcess->size << endl;
			else cout << " ProcessID:" << "Nil" << " ProcessSize:" << "Nil" << endl;
			ptr = ptr->next;
		}
	}
};

int main()
{
	int totalMemory;
	/*cout << "Enter the total memory available (in Bytes) = ";
	cin >> totalMemory;*/
	totalMemory = 900;

	int blockSize;
	/*cout << "Enter the block size (in Bytes) = ";
	cin >> blockSize;*/
	blockSize = 200;

	int numberOfProcesses;
	/*cout << "Enter the number of processes = ";
	cin >> numberOfProcesses;*/
	numberOfProcesses = 7;

	int* processSize = new int[numberOfProcesses];
	/*for (int i = 0; i < numberOfProcesses; i++)
	{
		cout << "Enter memory required for process "<<i+1<<"(in Bytes) = ";
		cin >> processSize[i];
	}*/
	processSize[0] = 201;
	processSize[1] = 199;
	processSize[2] = 48;
	processSize[3] = 41;
	processSize[4] = 222;
	processSize[5] = 9;
	processSize[6] = 54;

	Process** processArray = new Process*[numberOfProcesses];
	for (int i = 0; i < numberOfProcesses; i++)
	{
		processArray[i] = new Process(i + 1, processSize[i]);
	}

	int blockLength = totalMemory / blockSize;
	MemoryBlock** memoryBlockArray = new MemoryBlock*[blockLength];
	for (int i = 0; i < blockLength; i++)
	{
		memoryBlockArray[i] = new MemoryBlock(i + 1, blockSize);
	}

	MemoryChunk mc;
	for (int i = 0; i < blockLength; i++)
	{
		mc.addBlock(memoryBlockArray[i]);
	}

	for (int i = 0; i < numberOfProcesses; i++)
	{
		mc.addProcessFF(processArray[i]);
	}

	cout << "____________________________________________________________________________" << endl;
	cout << "| Process No. | Memory Required | Block Allocated | Internal Fragmentation |" << endl;
	MemoryBlock* ptr = mc.head;
	int length = 0;
	while (ptr != NULL)
	{
		length++;
		ptr = ptr->next;
	}

	int internalFragmentation = 0;
	
	for (int i = 0; i < numberOfProcesses; i++)
	{
		if (processArray[i] != NULL)
		{
			cout << "|      " << i + 1 << "      |       " << processArray[i]->size << "       |       NO        |            -           |" << endl;
		}
		else
		{
			cout << "|      " << mc.getMemoryBlockByProcessId(i + 1)->currentProcess->id << "      |       " << mc.getMemoryBlockByProcessId(i + 1)->currentProcess->size << "	|       Yes       |	       " << blockSize - mc.getMemoryBlockByProcessId(i + 1)->currentProcess->size << " 	   |" << endl;
			internalFragmentation += blockSize - mc.getMemoryBlockByProcessId(i + 1)->currentProcess->size;
		}
	}

	cout << endl;
	cout << "Total Internal Fragmentation is " << internalFragmentation << endl;
	cout << "Total External Fragmentation is " <<(totalMemory % blockSize)<< endl;

	system("pause");
	return 0;
}

//int main()
//{
//	int totalMemory;
//	cout << "Enter the total memory available (in Bytes) = ";
//	cin >> totalMemory;
//
//	int maxSize = 10000;
//	int* processSize = new int[maxSize];
//	bool continueFlag = true;
//	for (int i = 0; i < maxSize; i++)
//	{
//		string str = "";
//		cout << "Enter memory required for process "<<i+1<<"(in Bytes) = ";
//		cin >> processSize[i];
//		cout << "Do you want to continue(y/n)= ";
//		cin >> str;
//		if (str == "n")
//		{
//			processSize[i + 1] = -1;
//			break;
//		}
//	}
//
//	int numberOfProcesses = 0;
//	for (int i = 0; i < maxSize; i++)
//	{
//		if (processSize[i] == -1) break;
//		else numberOfProcesses++;
//	}
//
//
//	Process** processArray = new Process*[numberOfProcesses];
//	for (int i = 0; i < numberOfProcesses; i++)
//	{
//		processArray[i] = new Process(i + 1, processSize[i]);
//	}
//
//	int accumaltedMemory = 0;
//	MemoryChunk mc;
//	for (int i = 0; i < numberOfProcesses; i++)
//	{
//		if (accumaltedMemory + processSize[i] <= totalMemory)
//		{
//			MemoryBlock* mb = new MemoryBlock(i + 1, processSize[i]);
//			mc.addBlock(mb);
//			accumaltedMemory += processSize[i];
//		}
//		else break;
//	}
//
//	for (int i = 0; i < numberOfProcesses; i++)
//	{
//		mc.addProcessFF(processArray[i]);
//	}
//
//	cout << "___________________________________________________" << endl;
//	cout << "| Process No. | Memory Required | Block Allocated |" << endl;
//	MemoryBlock* ptr = mc.head;
//	int length = 0;
//	while (ptr != NULL)
//	{
//		length++;
//		ptr = ptr->next;
//	}
//
//	for (int i = 0; i < numberOfProcesses; i++)
//	{
//		if (processArray[i] != NULL)
//		{
//			cout << "|      " << i + 1 << "      |       " << processArray[i]->size << "       |       NO        |" << endl;
//		}
//		else
//		{
//			cout << "|      " << mc.getMemoryBlockByProcessId(i + 1)->currentProcess->id << "      |       " << mc.getMemoryBlockByProcessId(i + 1)->currentProcess->size << "	|       Yes       |	       " << endl;// << blockSize - mc.getMemoryBlockByProcessId(i + 1)->currentProcess->size << " 	   |" << endl;
//		}
//	}
//
//	cout << endl;
//	cout << "Total Memory Allocated: " << accumaltedMemory << endl;
//	cout << "Total External Fragmentation: " << totalMemory - accumaltedMemory << endl;
//
//	system("pause");
//	return 0;
//}
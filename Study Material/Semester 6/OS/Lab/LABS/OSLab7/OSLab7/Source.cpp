#include <iostream>
#include <vector>

using namespace std;

class Process
{
public:
	int id;
	int size;
	bool isAdded;

	Process()
	{
		this->id = -1;
		this->size = 0;
		this->isAdded = false;
	}

	Process(int id, int size)
	{
		this->id = id;
		this->size = size;
		this->isAdded = false;
	}
};

class MemoryBlock
{
public:
	int id;
	int size;
	Process currentProcess;
	MemoryBlock* next;

	MemoryBlock()
	{
		Process p;
		this->id = -1;
		this->size = 0;
		this->currentProcess = p;
		this->next = NULL;
	}

	MemoryBlock(int id, int size)
	{
		Process p;
		this->id = id;
		this->size = size;
		this->currentProcess = p;
		this->next = NULL;
	}

	MemoryBlock(int id, int size, Process p)
	{
		this->id = id;
		this->size = size;
		this->currentProcess = p;
		this->next = NULL;
	}

	MemoryBlock(int id, int size, Process p, MemoryBlock* m)
	{
		this->id = id;
		this->size = size;
		this->currentProcess = p;
		this->next = m;
	}

	bool assignProcess(Process p)
	{
		if (this->size >= p.size)
		{
			this->currentProcess = p;
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
		if (m->id == -1) return;
		if (this->head == NULL) this->head = m;
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
	//-----------------------------------------------------------------------------
	//First Fit--------------------------------------------------------------------
	MemoryBlock* getCloseSizeFF(int size)
	{
		MemoryBlock* ptr = this->head;
		MemoryBlock* rptr = this->head;

		if (this->head == NULL) return ptr;
		
		while (ptr != NULL)
		{
			if (ptr->size >= size && ptr->currentProcess.id == -1) return ptr;
			ptr = ptr->next;
		}
		return ptr;
	}

	bool addProcessFF(Process p)
	{
		MemoryBlock* mb = getCloseSizeFF(p.size);
		if (mb != NULL)
		{
			mb->currentProcess = p;
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
			if (ptr->size >= size && ((ptr->size - size) < diff) && ptr->currentProcess.id == -1)
			{
				diff = ptr->size - size;
				tempPtr = ptr;
			}
			ptr = ptr->next;
		}
		return tempPtr;
	}

	bool addProcessBF(Process p)
	{
		MemoryBlock* mb = getCloseSizeBF(p.size);
		if (mb != NULL)
		{
			mb->currentProcess = p;
			return true;
		}
		else return false;
	}
	//-----------------------------------------------------------------------------
	//Worst Fit--------------------------------------------------------------------
	MemoryBlock* getCloseSizeWF(int size)
	{
		MemoryBlock* ptr = this->head;
		MemoryBlock* rptr = this->head;
		MemoryBlock* tempPtr = NULL;

		if (this->head == NULL) return ptr;

		int diff = 0;

		while (ptr != NULL)
		{
			if (ptr->size >= size && ((ptr->size - size) >= diff) && ptr->currentProcess.id == -1)
			{
				diff = ptr->size - size;
				tempPtr = ptr;
			}
			ptr = ptr->next;
		}
		return tempPtr;
	}

	bool addProcessWF(Process p)
	{
		MemoryBlock* mb = getCloseSizeWF(p.size);
		if (mb != NULL)
		{
			mb->currentProcess = p;
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
			if(ptr->currentProcess.id > -1) cout<< " ProcessID:" << ptr->currentProcess.id << " ProcessSize:" << ptr->currentProcess.size << endl;
			else cout << " ProcessID:" << "Nil" << " ProcessSize:" << "Nil" << endl;
			ptr = ptr->next;
		}		
	}
};

int main()
{
	/*Process p1(1, 401);
	Process p2(2, 248);
	Process p3(3, 25);
	Process p4(4, 216);
	Process p5(4, 75);

	MemoryBlock* b1 = new MemoryBlock(1, 500);
	MemoryBlock* b2 = new MemoryBlock(2, 400);
	MemoryBlock* b3 = new MemoryBlock(3, 100);
	MemoryBlock* b4 = new MemoryBlock(4, 300);

	MemoryChunk mc(b1);
	mc.addBlock(b2);
	mc.addBlock(b3);
	mc.addBlock(b4);

	p1.isAdded = mc.addProcessFF(p1);
	p2.isAdded = mc.addProcessFF(p2);
	p4.isAdded = mc.addProcessFF(p4);
	p5.isAdded = mc.addProcessFF(p5);
	p3.isAdded = mc.addProcessFF(p3);

	cout << "Allocated Memory Blocks: " << endl;
	mc.print();

	cout << endl;
	cout << "Starvishing Processes:" << endl;
	if (!p1.isAdded) cout << " ProcessID: " << p1.id << " ProcessSize: " << p1.size<<endl;
	if (!p2.isAdded) cout << " ProcessID: " << p2.id << " ProcessSize: " << p2.size << endl;
	if (!p3.isAdded) cout << " ProcessID: " << p3.id << " ProcessSize: " << p3.size << endl;
	if (!p4.isAdded) cout << " ProcessID: " << p4.id << " ProcessSize: " << p4.size << endl;
	if (!p5.isAdded) cout << " ProcessID: " << p5.id << " ProcessSize: " << p5.size << endl;
*/

	Process p1(1, 401);
	Process p2(2, 248);
	Process p3(3, 25);
	Process p4(4, 216);
	Process p5(5, 75);

	MemoryBlock* b1 = new MemoryBlock(1, 500);
	MemoryBlock* b2 = new MemoryBlock(2, 400);
	MemoryBlock* b3 = new MemoryBlock(3, 100);
	MemoryBlock* b4 = new MemoryBlock(4, 300);

	MemoryChunk mc(b1);
	mc.addBlock(b2);
	mc.addBlock(b3);
	mc.addBlock(b4);

	p1.isAdded = mc.addProcessBF(p1);
	p2.isAdded = mc.addProcessBF(p2);
	p3.isAdded = mc.addProcessBF(p3);
	p4.isAdded = mc.addProcessBF(p4);
	p5.isAdded = mc.addProcessBF(p5);

	cout << "Allocated Memory Blocks: " << endl;
	mc.print();

	cout << endl;
	cout << "Starvishing Processes:" << endl;
	if (!p1.isAdded) cout << " ProcessID: " << p1.id << " ProcessSize: " << p1.size << endl;
	if (!p2.isAdded) cout << " ProcessID: " << p2.id << " ProcessSize: " << p2.size << endl;
	if (!p3.isAdded) cout << " ProcessID: " << p3.id << " ProcessSize: " << p3.size << endl;
	if (!p4.isAdded) cout << " ProcessID: " << p4.id << " ProcessSize: " << p4.size << endl;
	

	/*Process p1(1, 100);
	Process p2(2, 200);
	Process p3(3, 300);
	Process p4(4, 400);
	
	MemoryBlock* b1 = new MemoryBlock(1, 400);
	MemoryBlock* b2 = new MemoryBlock(2, 500);
	MemoryBlock* b3 = new MemoryBlock(3, 600);
	MemoryBlock* b4 = new MemoryBlock(4, 700);

	MemoryChunk mc(b1);
	mc.addBlock(b2);
	mc.addBlock(b3);
	mc.addBlock(b4);

	p1.isAdded = mc.addProcessWF(p1);
	p2.isAdded = mc.addProcessWF(p2);
	p3.isAdded = mc.addProcessWF(p3);
	p4.isAdded = mc.addProcessWF(p4);

	cout << "Allocated Memory Blocks: " << endl;
	mc.print();

	cout << endl;
	cout << "Starvishing Processes:" << endl;
	if (!p1.isAdded) cout << " ProcessID: " << p1.id << " ProcessSize: " << p1.size << endl;
	if (!p2.isAdded) cout << " ProcessID: " << p2.id << " ProcessSize: " << p2.size << endl;
	if (!p3.isAdded) cout << " ProcessID: " << p3.id << " ProcessSize: " << p3.size << endl;
	if (!p4.isAdded) cout << " ProcessID: " << p4.id << " ProcessSize: " << p4.size << endl;

*/



	/*int len;
	cout << "Enter Number of Memory Blocks:";
	cin >> len;
	vector<MemoryBlock*> blocks;
	
	for (int i = 0; i < len; i++)
	{
		int size;
		cout << "Enter size of " << i+1 << "th block:";
		cin >> size;
		MemoryBlock* m = new MemoryBlock(i+1, size);
		if(m->id != -1) blocks.push_back(m);
	}
	
	cout << "Enter Number of Processes:";
	cin >> len;
	vector<Process> processes;
	for (int i = 0; i < len; i++)
	{
		int size;
		cout << "Enter size of " << i + 1 << "th Process:";
		cin >> size;
		Process p(i+1, size);
		processes.push_back(p);
	}

	MemoryChunk mcA;
	int lengthA = blocks.size();
	for(int i = 0; i < lengthA; i++)
	{
		if(blocks[i]->id != -1) mcA.addBlock(blocks[i]);
	}
	
	int lengthB = processes.size();
	for (int i = 0; i < lengthB; i++)
	{
		mcA.addProcessFF(processes[i]);
	}

	mcA.print();
	*/

	system("pause");

	return 0;
}
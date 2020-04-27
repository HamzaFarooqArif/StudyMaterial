#include <iostream>

using namespace std;

class Process
{
public:
	int pid;
	int arrivalTime;
	int burstTime;
	int tempBurstTime;
	int waitingTime;
	int completionTime;

	Process* next;

	Process(int pid, int arrivalTime, int burstTime)
	{
		this->pid = pid;
		this->arrivalTime = arrivalTime;
		this->burstTime = burstTime;
		this->tempBurstTime = burstTime;
		this->waitingTime = 0;
		this->completionTime = 0;
		this->next = NULL;
	}

	void print()
	{
		cout << "arrivalTime: " << this->arrivalTime << endl;
		cout << "burstTime: " << this->burstTime << endl;
		cout << "tempBurstTime: " << this->tempBurstTime << endl;
		cout << "waitingTime: " << this->waitingTime << endl;
		cout << "completionTime: " << this->completionTime << endl;
	}
};

class ReadyQueue
{
public:
	Process* head;
	
	ReadyQueue(Process* p)
	{
		this->head = p;
	}

	void perform(int quantum)
	{
		int currentTime = 0;
		int previousQuantum = 0;
		int length = this->getLength();
		int currentIdx = 0;

		while(!this->isComplete())
		{
			if (this->getProcessAtIndex(currentIdx)->arrivalTime <= currentTime)
			{
				if (this->getProcessAtIndex(currentIdx)->tempBurstTime - (quantum + previousQuantum) >= 0)
				{
					this->getProcessAtIndex(currentIdx)->tempBurstTime -= (quantum + previousQuantum);
					previousQuantum = 0;
					this->updateWaits(currentIdx, currentTime, quantum);
				}
				else
				{
					this->getProcessAtIndex(currentIdx)->completionTime = currentTime + this->getProcessAtIndex(currentIdx)->tempBurstTime;
					previousQuantum = (quantum + previousQuantum) - this->getProcessAtIndex(currentIdx)->tempBurstTime;
					this->getProcessAtIndex(currentIdx)->tempBurstTime = 0;
					this->updateWaits(currentIdx, currentTime, quantum - previousQuantum);	
				}
				if(currentIdx < length - 1) currentIdx++;
				else currentIdx = 0;
			}
			else
			{
				currentIdx = 0;
				previousQuantum = 0;
			}
			currentTime += quantum;
		}
	}

	void updateWaits(int idx, int currentTime, int value)
	{
		if (value < 0) return;
		int length = this->getLength();
		for (int i = 0; i < length; i++)
		{
			if (this->getProcessAtIndex(i)->arrivalTime <= currentTime && this->getProcessAtIndex(i)->tempBurstTime != 0 && i != idx)
			{
				this->getProcessAtIndex(i)->waitingTime += value;
			}
		}
	}

	bool isComplete()
	{
		int length = this->getLength();
		for (int i = 0; i < length; i++)
		{
			if (this->getProcessAtIndex(i)->tempBurstTime != 0) return false;
		}
		return true;
	}

	void sortByArrivalTime(bool ascending = true)
	{
		int i, j;
		int n = this->getLength();

		for (i = 0; i < n - 1; i++)
		{
			for (j = 0; j < n - i - 1; j++)
			{
				if (ascending)
				{
					if ((this->getProcessAtIndex(j)->arrivalTime) > (this->getProcessAtIndex(j + 1)->arrivalTime))
					{
						this->swap(j, j + 1);
					}
				}
				else
				{
					if ((this->getProcessAtIndex(j)->arrivalTime) < (this->getProcessAtIndex(j + 1)->arrivalTime))
					{
						this->swap(j, j + 1);
					}
				}
			}
		}	
	}

	Process* getProcessAtIndex(int i)
	{
		int length = getLength();
		if (i >= length) return NULL;
		Process* ptr = this->head;
		for (int j = 0; j < i; j++)
		{
			ptr = ptr->next;
		}
		return ptr;
	}

	void addProcess(Process* p)
	{
		if (this->head == NULL) this->head = p;
		
		Process* ptr = this->head;
		Process* rptr = this->head;
		while(ptr != NULL)
		{
			rptr = ptr;
			ptr = ptr->next;
		}
		rptr->next = p;
	}

	void swap(Process* p1, Process* p2)
	{
		if (p1 == NULL || p2 == NULL) return;
		if (p1->pid == p2->pid) return;
		

		Process* P1 = this->head;
		Process* rP1 = this->head;
		Process* P2 = this->head;
		Process* rP2 = this->head;

		while (P1 != NULL && P1->pid != p1->pid)
		{
			rP1 = P1;
			P1 = P1->next;
		}
		while (P2 != NULL && P2->pid != p2->pid)
		{
			rP2 = P2;
			P2 = P2->next;
		}

		if (p1->pid == this->head->pid)
		{
			rP2->next = P1;
			Process* temp = P2->next;
			P2->next = P1->next;
			P1->next = temp;
			this->head = P2;
		}
		else if (p2->pid == this->head->pid)
		{
			rP1->next = P2;
			Process* temp = P1->next;
			P1->next = P2->next;
			P2->next = temp;
			this->head = P1;
		}
		else
		{
			rP1->next = P2;
			rP2->next = P1;

			Process* temp = P1->next;
			P1->next = P2->next;
			P2->next = temp;
		}
	}

	int getLength()
	{
		int length = 0;
		Process* ptr = this->head;
		while (ptr != NULL)
		{
			length++;
			ptr = ptr->next;
		}
		return length;
	}

	void swap(int p1, int p2)
	{
		int length = getLength();

		if (p1 < 0 || p2 < 0) return;
		if (p1 >= length || p2 >= length) return;
		if (p1 == p2) return;

		Process* P1 = this->head;
		Process* rP1 = this->head;
		Process* P2 = this->head;
		Process* rP2 = this->head;

		for (int i = 0; i < p1; i++)
		{
			rP1 = P1;
			P1 = P1->next;
		}
		for (int i = 0; i < p2; i++)
		{
			rP2 = P2;
			P2 = P2->next;
		}

		if (p1 == 0)
		{
			rP2->next = P1;
			Process* temp = P2->next;
			P2->next = P1->next;
			P1->next = temp;
			this->head = P2;
		}
		else if (p2 == 0)
		{
			rP1->next = P2;
			Process* temp = P1->next;
			P1->next = P2->next;
			P2->next = temp;
			this->head = P1;
		}
		else
		{
			rP1->next = P2;
			rP2->next = P1;

			Process* temp = P1->next;
			P1->next = P2->next;
			P2->next = temp;
		}
	}

	void print()
	{
		int length = this->getLength();
		cout << "_______________________________________________________________________________________________________" << endl;
		cout << "|  ProcessID    |  ArrivalTime  |  BurstTime    |  WaitingTime  |  TurnaroundTime  |  CompletionTime  |" << endl;
		for (int i = 0; i < length; i++)
		{
			cout << "|	" << this->getProcessAtIndex(i)->pid << "	|";
			cout << "	" << this->getProcessAtIndex(i)->arrivalTime << "	|";
			cout << "	" << this->getProcessAtIndex(i)->burstTime << "	|";
			cout << "	" << this->getProcessAtIndex(i)->waitingTime << "	|";
			cout << "	" << this->getProcessAtIndex(i)->completionTime - this->getProcessAtIndex(i)->arrivalTime << "	   |";
			cout << "	     " << this->getProcessAtIndex(i)->completionTime << "	      |" << endl;
		}

		int averageWT = 0;
		int averageTAT = 0;
		for (int i = 0; i < length; i++)
		{
			averageWT += this->getProcessAtIndex(i)->waitingTime;
		}
		for (int i = 0; i < length; i++)
		{
			averageTAT += this->getProcessAtIndex(i)->completionTime - this->getProcessAtIndex(i)->arrivalTime;
		}
		averageWT /= length;
		averageTAT /= length;

		cout << "Average waiting time = " << averageWT << endl;
		cout << "Average turnaround time = " << averageTAT << endl;
	}

};


int main()
{
	Process* p1 = new Process(1, 2, 5);
	Process* p2 = new Process(2, 1, 3);
	Process* p3 = new Process(3, 0, 2);
	Process* p4 = new Process(4, 4, 7);
	Process* p5 = new Process(5, 9, 9);


	ReadyQueue rq(p1);
	rq.addProcess(p2);
	rq.addProcess(p3);
	rq.addProcess(p4);
	rq.addProcess(p5);

	rq.perform(2);

	rq.print();

	system("pause");
	return 0;
}
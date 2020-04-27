#include <iostream>
#include <vector>
#include <string>
#include <sstream>

using namespace std;

int currentTime = 0;
//Process----------------------------------------------------------------
class Process
{
public:
	int processID;
	int arrivalTime;
	int burstTime;
	int waitTime;
	int completionTime;
	int turnaroundTime;

	Process()
	{
		this->processID = -1;
	}
	Process(int pid, int at, int bt)
	{
		this->processID = pid;
		this->arrivalTime = at;
		this->burstTime = bt;
		this->waitTime = 0;
		this->completionTime = 0;
		this->turnaroundTime = 0;
	}

	string getPID()
	{
		stringstream ss;
		ss << processID;
		string str = ss.str();

		string result = "pid_" + str;

		return result;
	}
};
//ReadyQueue----------------------------------------------------------------
class ReadyQueue
{
public:
	vector<Process> processQueue;

	bool addProcess(Process p)
	{
		for each (Process pr in processQueue)
		{
			if (pr.processID == p.processID) return false;
		}
		processQueue.push_back(p);
		return true;
	}

	Process removeProcess(Process p)
	{
		Process proc;
		
		if (processQueue.size() > 1)
		{
			int idx = 0;
			for each (Process pr in processQueue)
			{
				if (pr.processID == p.processID)
				{
					proc = pr;
					processQueue.erase(processQueue.begin() + idx);
					break;
				}
				idx++;
			}
		}
		else if((processQueue.size() > 0) && (processQueue[0].processID == p.processID))
		{
			proc = processQueue[0];
			processQueue.erase(processQueue.begin());
		}
		return proc;
		
	}

	Process removeProcess(int index)
	{
		Process proc;
		if (index > (processQueue.size() - 1)) return proc;
		if (processQueue.size() > 1)
		{
			int idx = 0;
			for each (Process pr in processQueue)
			{
				if (idx == index)
				{
					proc = pr;
					processQueue.erase(processQueue.begin() + idx);
					break;
				}
				idx++;
			}
		}
		else if((processQueue.size() > 0) && index == 0)
		{
			proc = processQueue[0];
			processQueue.erase(processQueue.begin());
		}
		return proc;
	}

	vector<Process> getAccessibleProcesses()
	{
		vector<Process> result;
		for each (Process pr in processQueue)
		{
			if (pr.arrivalTime <= currentTime)
			{
				result.push_back(pr);
			}
		}
		return result;
	}

	int getLowestArrivalTime()
	{
		vector<Process> processes = getAccessibleProcesses();
		if (processes.size() == 0) return -1;
		int result = processes[0].arrivalTime;
		//int len = 0;
		for each (Process pr in processes)
		{
			if (result > pr.arrivalTime) result = pr.arrivalTime;
			//else if (result == pr.arrivalTime) len++;
		}
		//if (len == processQueue.size()) return -1;
		return result;
	}

	Process extractProcess()
	{
		Process p;
		vector<Process> processes = getAccessibleProcesses();
		vector<Process> equalProcesses;

		if (processes.size() == 0) return p;
		for each (Process pr in processes)
		{
			if (pr.arrivalTime == getLowestArrivalTime())
			{
				equalProcesses.push_back(pr);
			}
		}

		int oldestId = equalProcesses[0].processID;
		for each (Process pr in equalProcesses)
		{
			if (oldestId > pr.processID) oldestId = pr.processID;
		}
		for each (Process pr in equalProcesses)
		{
			if (oldestId == pr.processID) return removeProcess(pr);
		}
	}

	void updateWaits(int seconds)
	{
		for (int i = 0; i < seconds; i++)
		{
			for (int j = 0; j < processQueue.size(); j++)
			{
				if (processQueue[j].arrivalTime <= currentTime) processQueue[j].waitTime++;
			}
		}
	}

	void sort()
	{
		int i, j;
		int n = this->processQueue.size();
		for (i = 0; i < n - 1; i++)
		{
			for (j = 0; j < n - i - 1; j++)
			{
				if (this->processQueue[j].processID > this->processQueue[j + 1].processID)
				{
					Process temp = this->processQueue[j];
					this->processQueue[j] = this->processQueue[j + 1];
					this->processQueue[j + 1] = temp;
				}
			}
		}    
	}

	void takeInput()
	{
		int numberOfProcesses = 0;
		cout << "Enter number of processes: ";
		cin >> numberOfProcesses;
		int i;
		for (i = 0; i < numberOfProcesses; i++)
		{
			int arrivalTime = 0;
			int burstTime = 0;
			cout << "Enter arrival time of process "<< i + 1<<" : ";
			cin >> arrivalTime;
			cout << "Enter burst time of process " << i + 1<< " : ";
			cin >> burstTime;
			Process pr(i, arrivalTime, burstTime);
			this->addProcess(pr);
		}
	}
};
//Calculate----------------------------------------------------------------
class Calculate
{
public:
	ReadyQueue perform(ReadyQueue rq)
	{
		ReadyQueue result;
		currentTime = 0;
		int iter = rq.processQueue.size();
		 
		for (int i = 0; i < iter; i++)
		{
			Process pr;
			while (true)
			{
				pr = rq.extractProcess();
				if(pr.processID == -1) currentTime++;
				else break;
			}
			
			//currentTime = pr.arrivalTime;
			for (int j = 0; j < pr.burstTime; j++)
			{
				rq.updateWaits(1);
				currentTime++;
			}
			pr.completionTime = currentTime;
			pr.turnaroundTime = pr.completionTime - pr.arrivalTime;
			result.addProcess(pr);
		}
		return result;
	}

	void display(ReadyQueue rqs)
	{
		ReadyQueue rq;
		rq = this->perform(rqs);
		rq.sort();
		cout << "==============================================================================" << endl;
		cout <<"ProcessID" <<" | "<<"ArrivalTime"<< " | " << "BurstTime" << " | " << "WaitingTime" <<" | "<< "CompletionTime" << " | " << "TAT" << "     | " << endl;
		
		for each (Process pr in rq.processQueue)
		{
			stringstream ss;
			string result;
			unsigned int iter = 0;

			result = pr.getPID();
			iter = result.length();
			for (int i = 0; i < (10 - iter); i++)
			{
				result += " ";
			}
			cout << result <<"| ";
			result = "";

			ss << pr.arrivalTime;
			result = ss.str();
			iter = result.length();
			for (int i = 0; i < (12 - iter); i++)
			{
				result += " ";
			}
			cout << result << "| ";
			result = "";

			ss.str("");
			ss << pr.burstTime;
			result = ss.str();
			iter = result.length();
			for (int i = 0; i < (10 - iter); i++)
			{
				result += " ";
			}
			cout << result << "| ";
			result = "";

			ss.str("");
			ss << pr.waitTime;
			result = ss.str();
			iter = result.length();
			for (int i = 0; i < (12 - iter); i++)
			{
				result += " ";
			}
			cout << result << "| ";
			result = "";

			ss.str("");
			ss << pr.completionTime;
			result = ss.str();
			iter = result.length();
			for (int i = 0; i < (15 - iter); i++)
			{
				result += " ";
			}
			cout << result << "| ";
			result = "";

			ss.str("");
			ss << pr.turnaroundTime;
			result = ss.str();
			iter = result.length();
			for (int i = 0; i < (8 - iter); i++)
			{
				result += " ";
			}
			cout << result << "| " << endl;
			result = "";
		}
		cout << "==============================================================================" << endl;
	
		float total = 0;

		for each (Process pr in rq.processQueue)
		{
			total += pr.waitTime;
		}
		cout << "Average waiting time = " << total / (rq.processQueue.size()) << endl;

		total = 0;
		for each (Process pr in rq.processQueue)
		{
			total += pr.turnaroundTime;
		}
		cout << "Average turn around time = " << total / (rq.processQueue.size()) << endl;
	}
};

int main()
{
	/*Lab Task 1*/
	/*Process p(0, 0, 4);
	Process p1(1, 0, 3);
	Process p2(2, 0, 2);
	Process p3(3, 0, 1);
	Process p4(4, 0, 3);
	ReadyQueue rq;
	rq.addProcess(p);
	rq.addProcess(p1);
	rq.addProcess(p2);
	rq.addProcess(p3);
	rq.addProcess(p4);
	Calculate c;
	c.display(rq);*/

	/*Lab Task 2*/
	/*Process p(0, 3, 4);
	Process p1(1, 5, 3);
	Process p2(2, 0, 2);
	Process p3(3, 5, 1);
	Process p4(4, 4, 3);
	ReadyQueue rq;
	rq.addProcess(p);
	rq.addProcess(p1);
	rq.addProcess(p2);
	rq.addProcess(p3);
	rq.addProcess(p4);
	Calculate c;
	c.display(rq);*/

	Process p(0, 0, 2);
	Process p1(1, 1, 3);
	Process p2(2, 2, 5);
	Process p3(3, 3, 4);
	Process p4(4, 4, 6);
	ReadyQueue rq;
	rq.addProcess(p);
	rq.addProcess(p1);
	rq.addProcess(p2);
	rq.addProcess(p3);
	rq.addProcess(p4);
	Calculate c;
	c.display(rq);
	
	/*ReadyQueue rq;
	rq.takeInput();
	Calculate c;
	c.display(rq);*/

	system("pause");
	return 0;
}
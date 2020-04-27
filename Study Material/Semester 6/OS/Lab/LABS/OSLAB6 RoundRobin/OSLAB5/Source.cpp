#include <iostream>
using namespace std;

int main()
{
	int arrivalflag, numberofprocess, arrivaltime, bursttime, completiontime, turnarroundtime, waitingtime;



	cout << "###########################################################################" << endl;
	cout << "                   Arrival Time Decision(0 for all or different)                       " << endl;
	cout << "###########################################################################" << endl;
	cout << endl;
	cout << "Enter 1 if you want different arrival time ,0 for same arrival time " << endl;
	cin >> arrivalflag;



	cout << "###########################################################################" << endl;
	cout << "                               Number of Processes                       " << endl;
	cout << "###########################################################################" << endl;
	cout << endl;
	cout << "Enter Number of processes you want to create" << endl;
	cin >> numberofprocess;
	int* burstarray = new int[numberofprocess];
	int* arrivalarray = new int[numberofprocess];




	if (arrivalflag == 1)
	{
		cout << "###########################################################################" << endl;
		cout << "                      Enter Arrival Time for each Process                     " << endl;
		cout << "###########################################################################" << endl;
		cout << endl;
		for (int i = 0; i < numberofprocess; i++)
		{
			cout << "Enter arrival time for process pid_" << i << endl;
			cin >> arrivaltime;
			arrivalarray[i] = arrivaltime;
		}
	}
	else
	{
		for (int i = 0; i < numberofprocess; i++)
		{
			arrivalarray[i] = 0;
		}
	}





	cout << "###########################################################################" << endl;
	cout << "                      Enter Burst Time for each Process                     " << endl;
	cout << "###########################################################################" << endl;
	cout << endl;
	for (int i = 0; i < numberofprocess; i++)
	{
		cout << "Enter burst time for process pid_" << i << endl;
		cin >> bursttime;
		burstarray[i] = bursttime;
	}

	int quantum;
	cout << "###########################################################################" << endl;
	cout << "                       QUANTUM for each processes                          " << endl;
	cout << "###########################################################################" << endl;
	cout << endl;
	cout << "Enter Quantum Time" << endl;
	cin >> quantum;

	int temp = 0;
	// process[0] is pid
	// process[1] is arrivaltime
	// process[2] is bursttime
	// process[3] is completiontime
	// process[4] is newbursttime
	int** process = new int*[numberofprocess];
	for (int i = 0; i < numberofprocess; i++)
	{
		process[i] = new int[6];
	}
	for (int i = 0; i < numberofprocess; i++)
	{
		process[i][0] = i;
		process[i][1] = arrivalarray[i];
		process[i][2] = burstarray[i];
		process[i][3] = 0;
		process[i][4] = 0;
		process[i][5] = 0;
	}


	int t[3] = { 0,0,0 };
	// Sorting Array by Arrival time

	for (int i = 0; i < numberofprocess - 1; i++)
	{
		for (int j = i + 1; j< numberofprocess; j++)
		{
			if (process[i][1] > process[j][1])
			{

				t[0] = process[i][0];
				t[1] = process[i][1];
				t[2] = process[i][2];
				process[i][0] = process[j][0];
				process[i][1] = process[j][1];
				process[i][2] = process[j][2];
				process[j][0] = t[0];
				process[j][1] = t[1];
				process[j][2] = t[2];

			}
		}
	}



	cout << "###########################################################################" << endl;
	cout << "                     Evaluating Times for each Process                     " << endl;
	cout << "###########################################################################" << endl;
	cout << endl;
	float averagewaittime = 0;
	float averageturnarroundtime = 0;
	temp = 0;
	int clock = process[0][1];
	int oldquantum = quantum;
	cout << "Arrival time | ProcessID | BurstTime | CompletionTime | TurnArroundTime | WaitingTime" << endl;
	bool flag = true;
	int index = 0;
	while (flag)
	{
		flag = false;
		for (int i = 0; i < numberofprocess; i++)
		{
			if (process[i][2] != 0)
			{
				flag = true;
			}
		}

		while (quantum != 0)
		{

			if (process[index][2] == 0 && process[index][5] == 0 && process[index][1] <= clock)
			{
				cout << process[index][0] << " " << clock << endl;
				process[index][3] = clock;
				process[index][5] = 1;
				break;
			}
			else if (process[index][2] == 0 && process[index][5] == 1)
			{

				break;
			}
			else if (process[index][1] > clock)
			{
				break;
			}
			else
			{
				clock = clock + 1;
				process[index][2] = process[index][2] - 1;
				quantum = quantum - 1;
				process[index][4] = process[index][4] + 1;
				if (process[index][2] == 0 && process[index][5] == 0)
				{

					process[index][3] = clock;
					process[index][5] = 1;

				}
			}

		}
		quantum = oldquantum;
		index = index + 1;
		if (index == numberofprocess)
		{
			index = 0;
		}

	}

	for (int i = 0; i < numberofprocess; i++)
	{
		arrivaltime = process[i][1];
		bursttime = process[i][4];
		completiontime = process[i][3];
		turnarroundtime = completiontime - arrivaltime;
		waitingtime = turnarroundtime - bursttime;
		cout << arrivaltime << " 	     |" << "pid_" << process[i][0] << "    	 |" << bursttime << "  	     |" << completiontime << " 	      |" << turnarroundtime << "  		|" << waitingtime << endl;
		averagewaittime = averagewaittime + waitingtime;
		averageturnarroundtime = averageturnarroundtime + turnarroundtime;
	}
	averageturnarroundtime = averageturnarroundtime / numberofprocess;
	averagewaittime = averagewaittime / numberofprocess;
	cout << "###########################################################################" << endl;
	cout << "                      Average Wait and Turn arround Time                  " << endl;
	cout << "###########################################################################" << endl;
	cout << endl;

	cout << "Average Turn Arround Time :" << averageturnarroundtime << endl;
	cout << "Average Wait Time :" << averagewaittime << endl;
}
#include <iostream>
#include <fstream>
#include <cstring>
#include "CTest.h"

CTest::CTest(ifstream& infile, int number_of_mcqs)
{
  CName N1((char*)"First", (char*)"Mid", (char*)"Last");
  this->student_name = N1;
  CDate D1;
  this->test_date = D1;
  this->mcqs = new CTestQuestion[number_of_mcqs];
  for(int i = 0; i < number_of_mcqs; i++)
  {
    CTestQuestion Q1;
    this->mcqs[i] = Q1;
    this->mcqs[i].ReadMCQ(infile);
  }
  this->num_of_mcqs = number_of_mcqs;
}
CTest::~CTest()
{
  delete[] this->mcqs;
}
CTest& CTest::GenerateReport()
{
  int score = 0;

  ofstream outfile;
  outfile.open ("Report.txt");

  for(int i = 0; i < num_of_mcqs; i++)
  {
    if(strcmp(this->mcqs[i].GetEnteredAns(), this->mcqs[i].GetMCQ().GetAnswer()) == 0)
    {
      score += 1;
    }
  }

  outfile<<"Name: "<<this->student_name<<endl;
  outfile<<"Date: "<<this->test_date<<endl;
  outfile<<"Score: "<<score<<endl;
  outfile<<endl;

  for(int i = 0; i < num_of_mcqs; i++)
  {
    outfile<<"Question "<< i + 1 << endl;
    this->mcqs[i].WriteMCQ(outfile);
    outfile<<endl;
  }
  return *this;
}
CTest& CTest::runTest()
{
  cin>>this->student_name;
  cin>>this->test_date;
  for(int i = 0; i < num_of_mcqs; i++)
  {
    cout<<endl;
    this->mcqs[i].WriteMCQ();
    cout<<endl;
    this->mcqs[i].SetEnteredAns();
  }
  return *this;
}

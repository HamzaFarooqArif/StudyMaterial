#include <iostream>
#include <fstream>
#include <cstring>
#include <cstdlib>
#include "CMCQ.h"
using namespace std;
CMCQ::CMCQ()
{
  this->Description = new char[1];
  Description = '\0';
  this->Options  = new char* [4];
  for(int i = 0; i < 4; i++)
  {
    this->Options[i] = new char[1];
    this->Options[i][0] = '\0';
  }

  this->Answer = new char[1];
  Answer = '\0';
}
CMCQ::CMCQ(char * des, char * opt1, char * opt2, char * opt3, char *opt4, char * ans)
{
  this->Description = new char[strlen(des) + 1];
  strcpy_s(this->Description, sizeof this->Description, des);

  this->Options  = new char* [4];

  this->Options[0] = new char[strlen(opt1) + 1];
  strcpy_s(this->Options[0], sizeof this->Options[0],  opt1);
  this->Options[1] = new char[strlen(opt2) + 1];
  strcpy_s(this->Options[1], sizeof this->Options[1],  opt2);
  this->Options[2] = new char[strlen(opt3) + 1];
  strcpy_s(this->Options[2], sizeof this->Options[2],  opt3);
  this->Options[3] = new char[strlen(opt4) + 1];
  strcpy_s(this->Options[3], sizeof this->Options[3],  opt4);

  this->Answer = new char[strlen(ans) + 1];
  strcpy_s(this->Answer, sizeof this->Answer, ans);
}
CMCQ::CMCQ(CMCQ& mcq)
{
  this->Description = new char[strlen(mcq.GetDescription()) + 1];
  strcpy_s(this->Description, sizeof this->Description, mcq.GetDescription());
  this->Options = new char*[4];
  for(int i = 0; i < 4; i++)
  {
    this->SetOption(mcq.GetOption(i + 1), i + 1);
  }

  this->Answer = new char[strlen(mcq.GetAnswer()) + 1];
  strcpy_s(this->Answer, sizeof this->Answer, mcq.GetAnswer());
}
CMCQ::~CMCQ()
{
  delete[] this->Description;
  delete[] this->Answer;
}
CMCQ& CMCQ::SetDescription(char* des)
{
  delete[] this->Description;
  this->Description = new char[strlen(des) + 1];
  strcpy_s(this->Description, sizeof this->Description, des);
  return *this;
}
CMCQ& CMCQ::SetOption(char* option, int num)
{
  delete[] this->Options[num - 1];
  this->Options[num - 1] = new char[strlen(option) + 1];
  strcpy_s(this->Options[num - 1], sizeof this->Options[num - 1], option);
  return *this;
}
CMCQ& CMCQ::SetAnswer(char* ans)
{
  delete[] this->Answer;
  this->Answer = new char[strlen(ans) + 1];
  strcpy_s(this->Answer, sizeof this->Answer, ans);
  return *this;
}
char* CMCQ::GetDescription()
{
  return this->Description;
}
char* CMCQ::GetOption(int option)
{
  return this->Options[option - 1];
}
char* CMCQ::GetAnswer()
{
  return this->Answer;
}
istream& operator >>(istream & input, CMCQ & mcq)
{
  int len = 256;
  char* str1 = new char[len];
  cout<< "enter the discription ending with a fullstop '.'";
  cin.getline(str1, len, '.');
  mcq.SetDescription(str1);
  cout << "enter option 1 : ";
  cin.getline(str1, len, '.');
  mcq.SetOption(str1, 1);
  cout << "enter option 2 : ";
  cin.getline(str1, len, '.');
  mcq.SetOption(str1, 2);
  cout << "enter option 3 : ";
  cin.getline(str1, len, '.');
  mcq.SetOption(str1, 3);
  cout << "enter option 4 : ";
  cin.getline(str1, len, '.');
  mcq.SetOption(str1, 4);
  cout << "enter Answer : ";
  cin.getline(str1, len, '.');
  mcq.SetAnswer(str1);
  return input;
}
ostream& operator << (ostream & output, CMCQ &mcq)
{
  output<< mcq.GetDescription()<< endl<< mcq.GetOption(1)<< endl<< mcq.GetOption(2)<< endl<< mcq.GetOption(3)<< endl<< mcq.GetOption(4)<< endl<< mcq.GetAnswer()<< endl;

  return output;
}

ifstream& operator >> (ifstream & infile, CMCQ & mcq)
{
  int len = 256;
  char * str1 = new char [len];
  infile.getline(str1, len, '\n');
  mcq.SetDescription(str1);
  infile.getline(str1, len, '\n');
  mcq.SetOption(str1, 1);
  infile.getline(str1, len, '\n');
  mcq.SetOption(str1, 2);
  infile.getline(str1, len, '\n');
  mcq.SetOption(str1, 3);
  infile.getline(str1, len, '\n');
  mcq.SetOption(str1, 4);
  infile.getline(str1, len, '\n');
  mcq.SetAnswer(str1);
  return infile;
}

ofstream& operator << (ofstream & outfile, CMCQ &mcq)
{

  outfile<< mcq.GetDescription()<< endl<< mcq.GetOption(1)<< endl<< mcq.GetOption(2)<< endl<< mcq.GetOption(3)<< endl<< mcq.GetOption(4)<< endl<< mcq.GetAnswer()<< endl;

  return outfile;
}

CMCQ& CMCQ::print(int num)
{
  cout<<this->GetOption(num)<<endl;
  return *this;
}

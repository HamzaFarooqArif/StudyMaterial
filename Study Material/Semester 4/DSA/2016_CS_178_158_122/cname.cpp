#include <fstream>
#include <cstdlib>
#include <cstring>
#include "cname.h"
#include <iostream>
using namespace std;
char CName::str1[41];
char CName::str2[41];
CName::CName()
{
  this->first = new char[1];
  this->first = '\0';
  this->mid = new char[1];
  this->mid = '\0';
  this->last = new char[1];
  this->last = '\0';
}
CName::CName(char *first, char *mid, char *last)
{
  this->first = new char[strlen(first) + 1];
  strcpy_s(this->first, sizeof this->first, first);
  this->mid = new char[strlen(mid) + 1];
  strcpy_s(this->mid, sizeof this->mid, mid);
  this->last = new char[strlen(last) + 1];
  strcpy_s(this->last, sizeof this->last, last);
}
istream & operator >>(istream &input, CName &name)
{
  delete[] name.first;
  cout<< "\n \a Enter first name: ";
  input>> CName::str1;
  name.first = new char[strlen(CName::str1) + 1];
  strcpy_s(name.first, sizeof name.first, CName::str1);
  delete[] name.mid;
  cout<< "\n \a Enter your mid name:";
  input>> CName::str1;
  name.mid = new char[strlen(CName::str1) + 1];
  strcpy_s(name.mid, sizeof name.mid, CName::str1);
  delete [] name.last;
  cout<< "\n \a Enter your last name:";
  input>> CName::str1;
  name.last = new char[strlen(CName::str1) + 1];
  strcpy_s(name.last, sizeof name.last, CName::str1);
  return input;
}
ostream & operator <<(ostream &output,const CName &name)
{
  output<< name.first<< " "<< name.mid<< " "<< name.last;
  return output;
}
CName& CName::operator =(const CName &src)
{
  delete [] this->first;
  this->first = new char[strlen(src.first) + 1];
  strcpy_s(this->first, sizeof this->first, src.first);
  delete [] this->mid;
  this->mid = new char[strlen(src.mid) + 1];
  strcpy_s(this->mid, sizeof this->mid, src.mid);
  delete [] this->last;
  this->last = new char[strlen(src.last) + 1];
  strcpy_s(this->last, sizeof this->last, src.last);
  return *this;
}
CName::CName(const CName &src)
{
  delete [] this->first;
  this->first = new char[strlen(src.first) + 1];
  strcpy_s(this->first, sizeof this->first, src.first);
  delete [] this->mid;
  this->mid = new char[strlen(src.mid) + 1];
  strcpy_s(this->mid, sizeof this->mid, src.mid);
  delete [] this->last;
  this->last = new char[strlen(src.last) + 1];
  strcpy_s(this->last, sizeof this->last, src.last);
}
CName& CName::setname(const char * first, const char *mid, const char * last)
{
  delete[] this->first;
  this->first = new char[strlen(first) + 1];
  strcpy_s(this->first, sizeof this->first, first);
  delete[] this->mid;
  this->mid = new char[strlen(mid) + 1];
  strcpy_s(this->mid, sizeof this->mid, mid);
  delete[]this->last;
  this->last = new char[strlen(last) + 1];
  strcpy_s(this->last, sizeof this->last, last);
  return *this;
}
char* CName::getfirstname()const
{
  return this->first;
}
char* CName::getmidname()const
{
  return this->mid;
}
char* CName::getlastname()const
{
  return this->last;
}
CName& CName::setfirstname(const char * first)
{
  delete[]this->first;
  this->first = new char[strlen(first) + 1];
  strcpy_s(this->first, sizeof this->first, first);
  return *this;
}
CName& CName::setmidname(const char * mid)
{
  delete[]this->mid;
  this->mid = new char[strlen(mid) + 1];
  strcpy_s(this->mid, sizeof this->mid, mid);
  return *this;
}
CName& CName::setlastname(const char * last)
{
  delete[]this->last;
  this->last = new char[strlen(last) + 1];
  strcpy_s(this->last, sizeof this->last, last);
  return *this;
}




ifstream & operator >>(ifstream &infile, CName &name)
{
  delete[] name.first;
  infile>> CName::str1;
  name.first = new char[strlen(CName::str1) + 1];
  strcpy_s(name.first, sizeof name.first, CName::str1);
  delete[] name.mid;
  infile>> CName::str1;
  name.mid = new char[strlen(CName::str1) + 1];
  strcpy_s(name.mid, sizeof name.mid, CName::str1);
  delete [] name.last;
  infile>> CName::str1;
  name.last = new char[strlen(CName::str1) + 1];
  strcpy_s(name.last, sizeof name.last, CName::str1);
  return infile;
}
ofstream & operator <<(ofstream &outfile,const CName &name)
{
  outfile<< name.first<< " "<< name.mid<< " "<< name.last;
  return outfile;
}

CName& CName::writetofile(ofstream & ofile)
{
  int count;
  count = strlen(this->first);
  ofile.write((char*) & count, sizeof(count));
  ofile.write(this->first, sizeof(count));
  count = strlen(this->mid);
  ofile.write((char*) & count, sizeof(count));
  ofile.write(this->mid, count);
  count = strlen(this->last);
  ofile.write((char*) & count, sizeof(count));
  ofile.write(this->last, count);
  return *this;

}
CName& CName::readfromfile(ifstream& infile)
{
  /*int count;
  delete[] this->first;
  delete[] this->mid;
  delete[] this->last;
  infile.read((char*)count, sizeof(count));
  this->first = new char[count + 1];
  infile.read(this->first, count);
  this->first[count] = '\0';
  infile.read((char*)count, sizeof(count));
  this->mid = new char[count + 1];
  infile.read(this->mid, count);
  this->mid[count] = '\0';
  infile.read((char*)count, sizeof(count));
  this->last = new char[count + 1];
  infile.read(this->last, count);
  this->last[count] = '\0';*/
	return *this;
}
CName::~CName()
{
  delete [] first;
  delete [] mid;
  delete [] last;
}

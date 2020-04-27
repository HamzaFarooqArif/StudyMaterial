#include <iostream>
#include <string.h>
#include "CDate.h"

using namespace std;

int CDate::daysOfMonth[12] = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
char CDate::strOfMonth[12][4] = {"JAN", "FEB", "MAR", "APR",
                                 "MAY", "JUN", "JUL", "AUG", "SEP", "OCT",
                                 "NOV", "DEC"};
char CDate::stringOfMonth[12][10] = {"JANUARY", "FEBRUARY", "MARCH", "APRIL",
                                     "MAY", "JUNE", "JULY", "AUGUST",
                                     "SEPTEMBER", "OCTOBER", "NOVEMBER",
                                     "DECEMBER"};

CDate::CDate()
{
/* Set date members of object default to Pakistan resolution day's date */
  this->day = 14;
  this->month = 8;
  this->year = 1947;
/* Validate before formation of date object */
  Validate();
}

/* Create date object with provided arguments */
CDate::CDate(int d, int m, int y)
{
  this->day = d;
  this->month = m;
  this->year = y;
  Validate();
}

CDate::CDate(const CDate& date)
{
  this->day = date.day;
  this->month = date.month;
  this->year = date.year;
}

CDate::~CDate()
{

}

CDate& CDate::ReadFromKB()
{
  do
  {
    /* Prompt before getting an input from user */
    cout<<"\n\aEnter a date as dd mm yyyy :";
    cin>> this->day>> this->month>> this->year;
    /* Validate before formation of date object */
    Validate();
  }
  while(this->day == -1);
  return *this;
}

CDate& CDate::Print(int opt) /*const*/
{
  /* Third format of printing */
  if(opt == 2)
  {
    cout<< stringOfMonth[this->month - 1]<< " "<<this->day<<
    "," <<this->year <<"\n";
  }
  /* Second format of printing */
  else if(opt == 1)
  {
    cout <<this->day << "-"<< strOfMonth[this->month - 1]<<
    "-"<<this->year <<"\n";
  }
  /* Default format of printing */
  else
  {
    cout<<this->day <<"/" <<this->month <<"/" <<this->year <<"\n";
  }
  return *this;
}

CDate& CDate::SetDay(int d)
{
  this->day = d;
  Validate();
  return *this;
}

CDate& CDate::SetMonth(int m)
{
  this->month = m;
  Validate();
  return *this;
}

CDate& CDate::SetYear(int y)
{
  this->year = y;
  Validate();
  return *this;
}

CDate& CDate::SetDate(int d, int m, int y)
{
  this->day = d;
  this->month = m;
  this->year = y;
  Validate();
  return *this;
}

int CDate::GetDay()
{
  return this->day;
}

int CDate::GetMonth()
{
  return this->month;
}

int CDate::GetYear()
{
  return this->year;
}

char* CDate::ToString() const
{
  char pad[20];
  sprintf_s(pad, sizeof pad, "%d/%d/%d", this->day, this->month, this->year);
  char* str = new char[strlen(pad) + 1];
  strcpy_s(str, sizeof str, pad);
  return str;
}

CDate& CDate::ChangeStrOfMonth(int month_num, char *month_name)
{
  strcpy_s(strOfMonth[month_num - 1], sizeof strOfMonth[month_num - 1], month_name);
  return *this;
}

CDate& CDate::ChangeStringOfMonth(int month_num, char *month_name)
{
  strcpy_s(stringOfMonth[month_num - 1], sizeof stringOfMonth[month_num - 1], month_name);
  return *this;
}

bool CDate::operator < (const CDate date) const
{
  if(this->year < date.year) return true;
  if(this->year > date.year) return false;
  if(this->month < date.month) return true;
  if(this->month > date.month) return false;
  if(this->day < date.day) return true;
  return false;
}

bool CDate::operator > (const CDate date) const
{
  if(this->year > date.year) return true;
  if(this->year < date.year) return false;
  if(this->month > date.month) return true;
  if(this->month < date.month) return false;
  if(this->day > date.day) return true;
  return false;
}

bool CDate::operator <= (const CDate date) const
{
  return !(*this > date);
}

bool CDate::operator >= (const CDate date) const
{
  return !(*this < date);
  //same as above//
  return this->operator < (date);
  //same as above//
  return !operator < (date);
}

bool CDate::operator == (const CDate date) const
{
  if(this->year != date.year) return false;
  if(this->month != date.month) return false;
  if(this->day != date.day) return false;
  return true;
}

bool CDate::operator != (const CDate date) const
{
  return !(*this == date);
}

CDate& CDate::operator ++ () //Prefix
{
  ++this->day;
  if(this->day > daysOfMonth[this->month - 1])
  {
    this->day = 1;
    ++this->month;
    if(this->month > 12)
    {
      this->month = 1;
      ++this->year;
    }
    this->Validate();
  }
  return *this;
}

CDate CDate::operator ++ (int x) //Postfix
{
  CDate temp(*this);
  this->day++;
  if(this->day > daysOfMonth[this->month - 1])
  {
    this->day = 1;
    this->month++;
    if(this->month > 12)
    {
      this->month = 1;
      this->year++;
    }
    this->Validate();
  }
  /* Why can't return 'this'?? */
  /* Why return *this is allowed */
  return temp;
}

CDate& CDate::operator -- () //Prefix
{
  --this->day;
  if(this->day < 1)
  {
    --this->month;
    if(this->month < 1)
    {
      this->month = 12;
      --this->year;
    }
    this->Validate();
    this->day = daysOfMonth[this->month - 1];
  }
  /* Why
  CDate temp(*this);
  return temp;
     is not allowed */
  return *this;
}

CDate CDate::operator -- (int x) //Postfix
{
  CDate temp(*this);
  this->day--;
  if(this->day < 1)
  {
    this->month--;
    if(this->month < 1)
    {
      this->month = 12;
      this->year--;
    }
    this->Validate();
    this->day = daysOfMonth[this->month - 1];
  }
  return temp;
}

CDate CDate::operator + (int x)
{
  CDate D1;
  D1.day = this->day;
  D1.month = this->month;
  D1.year = this->year;
  int counter;
  for(counter = 0; counter < x; counter++)
  {
    D1.day = D1.day + 1;
    if(D1.day > daysOfMonth[D1.month - 1])
    {
      D1.day = 1;
      D1.month = D1.month + 1;
      if(D1.month > 12)
      {
        D1.month = 1;
        D1.year = D1.year + 1;
      }
    }
    D1.Validate();
  }
  return D1;
}

CDate operator+(int x, CDate &date)
{
  CDate D1(date);
  int counter;
  for(counter = 0; counter < x; counter++)
  {
    D1.day = D1.day + 1;
    if(D1.day > D1.daysOfMonth[D1.month - 1])
    {
      D1.day = 1;
      D1.month = D1.month + 1;
      if(D1.month > 12)
      {
        D1.month = 1;
        D1.year = D1.year + 1;
      }
    }
    D1.Validate();
  }
  return D1;
}

CDate CDate::operator + (const CDate date)
{
  CDate D1(*this);
  int counter;
  int subtrahend = 0;
  while(D1.year > 0)
  {
    D1.day = D1.day - 1;
    if(D1.day < 1)
    {
      D1.month = D1.month - 1;
      if(D1.month < 1)
      {
        D1.month = 12;
        D1.year = D1.year - 1;
      }
      D1.Validate();
      D1.day = D1.daysOfMonth[D1.month - 1];
    }
    subtrahend++;
  }

  CDate D2(date);
  int counter2;
  for(counter2 = 0; counter2 < subtrahend; counter2++)
  {
    D2.day = D2.day + 1;
    if(D2.day > daysOfMonth[D2.month - 1])
    {
      D2.day = 1;
      D2.month = D2.month + 1;
      if(D2.month > 12)
      {
        D2.month = 1;
        D2.year = D2.year + 1;
      }
    }
  }
  return D2;
}

CDate CDate::operator - (int x)
{
  CDate D1;
  D1.day = this->day;
  D1.month = this->month;
  D1.year = this->year;
  int counter;
  for(counter = 0; counter < x; counter++)
  {
    D1.day = D1.day - 1;
    if(D1.day < 1)
    {
      D1.month = D1.month - 1;
      if(D1.month < 1)
      {
        D1.month = 12;
        D1.year = D1.year - 1;
      }
      D1.Validate();
      D1.day = daysOfMonth[D1.month - 1];
    }
  }
  return D1;
}

int operator-(int x, CDate &date)
{
  CDate D1(date);
  int counter;
  int subtrahend = 0;
  while(D1.year > 0)
  {
    D1.day = D1.day - 1;
    if(D1.day < 1)
    {
      D1.month = D1.month - 1;
      if(D1.month < 1)
      {
        D1.month = 12;
        D1.year = D1.year - 1;
      }
      D1.Validate();
      D1.day = D1.daysOfMonth[D1.month - 1];
    }
    subtrahend++;
  }
  return x - subtrahend;
}

CDate CDate::operator - (const CDate date)
{
  CDate D1(date);
  int counter;
  int subtrahend = 0;
  while(D1.year > 0)
  {
    D1.day = D1.day - 1;
    if(D1.day < 1)
    {
      D1.month = D1.month - 1;
      if(D1.month < 1)
      {
        D1.month = 12;
        D1.year = D1.year - 1;
      }
      D1.day = D1.daysOfMonth[D1.month - 1];
    }
    subtrahend++;
  }

  CDate D2(*this);
  int counter2;
  for(counter2 = 0; counter2 < subtrahend; counter2++)
  {
    D2.day = D2.day - 1;
    if(D2.day < 1)
    {
      D2.month = D2.month - 1;
      if(D2.month < 1)
      {
        D2.month = 12;
        D2.year = D2.year - 1;
      }
      D1.Validate();
      D2.day = daysOfMonth[D2.month - 1];
    }
  }
  return D2;
}

CDate& CDate::operator += (int x)
{
  int counter;
  for(counter = 0; counter < x; counter++)
  {
    ++this->day;
    if(this->day > daysOfMonth[this->month - 1])
    {
      this->day = 1;
      ++this->month;
      if(this->month > 12)
      {
        this->month = 1;
        ++this->year;
      }
    }
    this->Validate();
  }
  return *this;
}

CDate& CDate::operator -= (int x)
{
  int counter;
  for(counter = 0; counter < x; counter++)
  {
    --this->day;
    if(this->day < 1)
    {
      --this->month;
      if(this->month < 1)
      {
        this->month = 12;
        --this->year;
      }
      this->day = daysOfMonth[this->month - 1];
    }
    this->Validate();
  }
  return *this;
}

istream& operator >> (istream& input, CDate& date)
{
  do
  {
    cout<<"\a\nEnter date as dd mm yyyy:";
    input>>date.day>>date.month>>date.year;
    date.Validate();
  }
  while(date.day == -1);
  return input;
}

ostream& operator << (ostream& output, const CDate& date)
{
    output << date.day<<'/'<<date.month<<'/'<<date.year;
    return output;
}

CDate& CDate::Validate()
{
  if(this->month < 1 || this->month > 12)
  {
    this->day = -1;
  }
  else
  {
    if(IsLeapYear())
    {
      daysOfMonth[1] = 29;
    }
    else
    {
      daysOfMonth[1] = 28;
    }
  }
  if(this->day < 1 || this->day > daysOfMonth[this->month - 1])
  {
    this->day = -1;
  }
  return *this;
}

bool CDate::IsLeapYear()const
{
  if(this->year % 4 )
  {
    return 0;
  }
  else
  {
    return 1;
  }
}

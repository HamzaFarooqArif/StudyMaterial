#include <iostream>
#include <string>
using namespace std;
class CDate{
private:
  int month, day, year;
  static int daysofMonth[12];
  static char strofmonth[12][4];
  static char stringofmonth[12][10];
public:
	CDate();
	CDate(int, int, int);
	~CDate(){}
	void setDay(int);
	void setMonth(int);
	void setYear(int);
  void print(int)const;
  void Readfromkb();
  void validate();
  bool isleapyear()const;
  void setDate(int, int, int);
};
int  CDate::daysofMonth[12] = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
char CDate::strofmonth[12][4] = {"JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"};
char CDate::stringofmonth[12][10] = {"JANUARY", "FEBRUARY", "MARCH", "APRIL", "MAY", "JUNE", "JULY", "AUGUST", "SEPTEMBER", "OCTOBER", "NOVEMBER", "DECEMBER"};
CDate::CDate(){day = 14; month = 8; year = 1947; validate();}
CDate::CDate(int d, int m, int y){
  day = d, month = m; year = y; validate();
}

void CDate::Readfromkb(){
  do{cout<< "\n \a Enter a date as dd mm yyyy :";cin>> day>> month>> year;validate();}while(day == -1);
}
void CDate::validate(){if(month < 1 || month > 12) day = -1; else{if(isleapyear())daysofMonth[1] = 29; else daysofMonth[1] = 28;}
if(day < 1 || day > daysofMonth[month - 1]) day = -1;}
bool CDate::isleapyear()const{
  if(year % 4 ) return 0;else return 1;
}
void CDate::setDay(int d){day = d; validate();}
void CDate::setYear(int y){year = y; validate();}
void CDate::setMonth(int m){month = m; validate();}
void CDate::setDate(int d, int m, int y){
  day = d, month = m; year = y; validate();
}
void CDate::print(int opt = 0)const{
  if(opt == 2)cout<< stringofmonth[month - 1]<< " "<< day<< "," <<year <<"\n";
  else if(opt == 1)std::cout <<day << "-"<< strofmonth[month - 1]<< "-"<<year <<"\n";
  else cout<<day <<"/" <<month <<"/" <<year <<"\n";
}
int main()
{

  CDate date(14, 2, 2000);
  date.print(2);
  date.Readfromkb();
  date.print(2);
  date.print();
  date.print(1);
  date.setDay(14);
  date.print(2);
  date.setDay(90);
  date.print(0);
  date.setMonth(12);
  date.print();
  date.setMonth(90);
  date.print();
  date.setDate(14, 2, 2000);
  date.print(2);
  date.setDate(90, 20, 2000);
  date.print(2);
}

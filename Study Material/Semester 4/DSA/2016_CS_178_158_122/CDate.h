#include <iostream>

using namespace std;

class CDate
{
private:
  int day;
  int month;
  int year;

  static int daysOfMonth[12];
  static char strOfMonth[12][4];
  static char stringOfMonth[12][10];

public:
  //constructors
  CDate();
  CDate(int, int, int);
  CDate(const CDate& date);
  //Destructor
  ~CDate();
  /* Get input from user at the terminal */
  CDate& ReadFromKB();

  /* Print date in three different formates */
  /*Not const bcause a const function can't return *this */
  CDate& Print(int opt = 0) /*const*/;

  /* To set the value of data members of the object */
  CDate& SetDay(int);
  CDate& SetMonth(int);
  CDate& SetYear(int);
  CDate& SetDate(int, int, int);

  /* To get the value of data members of the object */
  int GetDay();
  int GetMonth();
  int GetYear();

  /* To get the string representation of the object */
  char* ToString() const;

  /* To change the spelling of month i.e static data members
  *this not allowed for static member functions */
  CDate& ChangeStrOfMonth(int month_num, char *month_name);
  CDate& ChangeStringOfMonth(int month_num, char *month_name);

  /* Operator overloading */
  bool operator < (const CDate date) const; // Binary Operator overloading
  bool operator > (const CDate date) const; // Binary Operator overloading
  bool operator <= (const CDate date) const; // Binary Operator overloading
  bool operator >= (const CDate date) const; // Binary Operator overloading
  bool operator == (const CDate date) const; // Binary Operator overloading
  bool operator != (const CDate date) const; // Binary Operator overloading
  CDate& operator ++ (); //prefix Unary operator overloading
  CDate operator ++ (int x); //postfix Unary operator overloading
  CDate& operator -- (); //prefix Unary operator overloading
  CDate operator -- (int x); //postfix Unary operator overloading
  CDate operator + (int x); // Binary Operator overloading
  friend CDate operator+(int x, CDate &date);  /* Binary Operator overloading
  using friend function */
  CDate operator + (const CDate date);
  friend int operator-(int x, CDate &date);  /* Binary Operator overloading
  using friend function */
  CDate operator - (int x);  // Binary Operator overloading
  CDate operator - (const CDate date);
  CDate& operator += (int x);  // Binary Operator overloading
  CDate& operator -= (int x);  // Binary Operator overloading

  /* i/o operator overloading using friend functions */
  friend istream& operator >> (istream& input, CDate& date);
  friend ostream& operator << (ostream& output, const CDate& date);

  /* To check if the arguments are valid before the formation of the object */
  CDate& Validate();
  /* To check if the particular year is leap year i.e month FEB has
  29 days of month */
  bool IsLeapYear() const;
};

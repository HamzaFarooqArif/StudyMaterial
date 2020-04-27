#include <iostream>
using namespace std;
class CName
{
private:
  char *first, *mid, *last;
  static char str1[41];
  static char str2[41];
public:
  CName();
  CName(char *first, char *mid, char *last);

  ~CName();

  CName(const CName &src);

  CName& operator =(const CName &src);

  CName& setname(const char *first, const char *mid, const char *last);

  char* getfirstname()const;
  char* getmidname()const;
  char* getlastname()const;


  CName& setfirstname(const char * first);
  CName& setmidname(const char * mid);
  CName& setlastname(const char * last);

  CName& writetofile(ofstream & ofile);
  CName& readfromfile(ifstream & infile);

  friend istream& operator >>(istream &input, CName &name);
  friend ostream& operator <<(ostream &output, const CName &name);
  friend ifstream& operator >>(ifstream& infile, CName &name);
  friend ofstream& operator <<(ofstream& outfile, const CName & name);
};

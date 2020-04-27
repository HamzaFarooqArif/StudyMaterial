#include <iostream>
#include <fstream>
using namespace std;

class CMCQ
{
private:
  char *Description;
  char** Options;
  char *Answer;
public:
  CMCQ();
  CMCQ(char * des, char * opt1, char * opt2, char * opt3, char *opt4, char * ans);
  CMCQ(CMCQ& mcq);
  ~CMCQ();

  char* GetDescription();
  char* GetOption(int);
  char* GetAnswer();

  CMCQ& print(int);
  CMCQ& SetDescription(char * des);
  CMCQ& SetOption(char*, int);
  CMCQ& SetAnswer(char * opt1);

  friend ostream& operator << (ostream & output, CMCQ &mcq);
  friend istream& operator >> (istream & input, CMCQ & mcq);
  friend ofstream& operator << (ofstream & outfile, CMCQ &mcq);
  friend ifstream& operator >> (ifstream & infile, CMCQ & mcq);
};

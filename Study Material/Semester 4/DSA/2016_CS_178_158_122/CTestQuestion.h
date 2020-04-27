#include "CMCQ.h"

class CTestQuestion
{
private:
  int* options;
  char* entered_ans;
  CMCQ mcq;
public:
  CTestQuestion();
  CTestQuestion(CMCQ& mcq, char* entered_ans);
  ~CTestQuestion();
  
  CTestQuestion& ReadMCQ();
  CTestQuestion& ReadMCQ(ifstream & infile);

  CTestQuestion& WriteMCQ();
  CTestQuestion& WriteMCQ(ofstream & outfile);

  CTestQuestion& SetEnteredAns();

  char* GetEnteredAns();
  char* GetOption(int);

  CMCQ& GetMCQ();
};

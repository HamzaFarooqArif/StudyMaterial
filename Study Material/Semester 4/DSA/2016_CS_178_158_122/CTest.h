#include <fstream>
#include "CTestQuestion.h"
#include "cname.h"
#include "CDate.h"

class CTest
{
private:
  CName student_name;
  CDate test_date;
  CTestQuestion *mcqs;
  int num_of_mcqs;
public:
  CTest(ifstream& infile, int number_of_mcqs);
  ~CTest();
  CTest& GenerateReport();
  CTest& runTest();
};

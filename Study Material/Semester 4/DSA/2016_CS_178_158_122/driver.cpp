#include "CTest.h"
#include <fstream>

int main()
{
  ifstream infile;
  infile.open ("MCQs.txt");

  CTest test(infile, 50);
  infile.close();
  test.runTest();
  test.GenerateReport();

  return 0;

}

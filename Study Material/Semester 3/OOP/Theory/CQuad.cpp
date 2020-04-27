#include <iostream>
#include <math.h>
#include <string.h>
using namespace std;

int main()
{
  class CQuad
  {
    double a, b, c;
    char solution[100], equation[81];
    
    public: 
        void ReadFromKB()
        {
          cout<<"\n\a For ax^2 + bx + c = 0 Enter a b c:";
          cin>>a>>b>>c;
        }
        void Reset()
        {
          sprintf(equation, "%lgx^2 %+lgx %+lg = 0", a, b, c);
          
          double d, v1, v2;
          
          d = b*b - 4*a*c;
          
          if(d < 0)
          {
            v1 = -b/2/a;
            v2 = sqrt(-d)/2/a;
            
            sprintf(solution, "x = {%+lg+i%lg, %+lg-i%lg}", v1, v2, v1, v2);
          }
          else
          {
            v2 = sqrt(d)/2/a;
            sprintf(solution, "x = {%+lg,%+lg}", v1+v2, v1-v2);
          }
        }
        void PrintEquation()
        {
          cout<<equation;
        }
        void PrintSolution()
        {
          cout<<solution;
        }
        void setA(double a1)
        {
          a = a1;
          Reset();
        }
        void setB(double b1)
        {
          b = b1;
          Reset();
        }
        void setC(double c1)
        {
          c = c1;
          Reset();
        }
        void setABC(double a1, double b1, double c1)
        {
          a = a1;
          b = b1;
          c = c1;
          Reset();
        }
        double getA() const
        {
          return a;
        }
        double getB() const
        {
          return b;
        }
        double getC() const
        {
          return c;
        }
        char *getEquation() const
        {
          char *str = new char[81];
          strcpy(str, equation);
          return str;
        }
        char *getSolution() const
        {
          char *str = new char[100];
          strcpy(str, solution);
          return str;
        }
  };
  
  CQuad E1;
  /*for(double a1 = 1; a1 < 11; a1 += 0.5)
  {
    for(double b1 = -10; b1 < 10; b1 += 0.5)
    {
      for(double c1 = -5; c1 < 5; c1 += 0.2)
      {
        E1.setABC(a1, b1, c1);
        E1.PrintEquation();
        cout<<" ==>";
        E1.PrintSolution();
      }
    }
  }*/
  
  double a1 = 1;
  double b1 = 1;
  double c1 = 1;
  
  E1.setABC(a1, b1, c1);
  E1.PrintEquation();
  cout<<" ==>";
  E1.PrintSolution();
  
  return 0;
}





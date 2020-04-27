using namespace::std;
#include<iostream>

int main()
{
int a=1;
float b=2.1;
long c;
double d;
char e;
bool f;

cout<<sizeof(a)<<" "<<sizeof(b)<<" "<<sizeof(c)<<" "<<sizeof(d)<<" "<<sizeof(e)<<" "<<sizeof(f)<<endl;

// division returns the integer part
	// and discards any remainder
	cout << "       5/3 = " <<          5/3   << endl;
	cout << "       6/3 = " <<          6/3   << endl << endl;

	// the largest integer
	cout << "The largest integer:          " << 2147483647 << endl;

	// adding 1 to the largest integer wraps to
	// the largest negative integer
	cout << "The largest negative integer: " << 2147483647 + 1 << endl;

	// working with double
	cout << "32.25 * 5.2352 = " <<  32.25 * 5.2352   << endl;
	cout << "32.25 / 5.2352 = " <<  32.25 / 5.2352   << endl << endl;
	cout << "    5/3= " <<  5.0/3.0      <<endl;

	// the largest doubles
	cout << "A large double:        " << 1.235e201 << endl;
	cout << "The largest double:    " << 1.79769313486231570e+308 << endl;
	cout << "An even larger double: " << 1e1000 << endl;
	

	// working with char 
	// error char c='dd';
	cout << 'a' << 'b' << 'c' << endl;
	cout << 'A' << 'B' << 'C' << endl;
	cout << '1' << '2' << '3' << endl;
	// the pound sign, a tab, a backslash, a new line, and a *
	cout << '#' << '\t' << '\\' << '\n' << '*' << endl;


	//working with bool
	cout << "true =  " <<  true << endl;
	cout << "false = " << false << endl << endl;


	a=b;
        e=97;

	cout<<" float->int"<< a<<"  int->char "<<e<<endl;
	


//c=(char)a;
	
 /*int h, bb, area;
cin>>h>>b;
h=8;bb=8;
area=bb*h;
cout<<area<<endl;
cout<<". ."<< a<<" .";
*/
return 0;
}
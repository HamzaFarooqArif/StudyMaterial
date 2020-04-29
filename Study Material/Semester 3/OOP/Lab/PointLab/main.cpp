#include <iostream>
#include "Point.h"
#include <cmath>

using namespace std;

double computeArea(Point& p1, Point& p2, Point& p3);
Point* readPoint();

/******************************************************************************************
******************************* Main function *********************************************
*******************************************************************************************/


int main()
{
	cout << "********  Solution for Lab 7 ********* " << endl;
	
	cout << "********  One possible solution ********" << endl;
	
	Point *p1 = readPoint();
	
	p1->printPoint();  //using forward arrows for calling function of pointer object
	
	Point *p2 = readPoint();
	
	p2->printPoint();
	
	Point *p3 = readPoint();
	
	p3->printPoint();
	
	cout << "Area = " << computeArea(*p1, *p2, *p3) << endl; 
	
	
	/***********Releasing memory ***************/
	
	delete p1;
	delete p2;
	delete p3;
	
	cout << endl << endl;
	cout << "******************************************" << endl;
	cout << "********  2nd possible solution ********" << endl;
	cout << "************** Easy one ***********" << endl;	
	
	cout << endl << "Please enter values for point: " << endl;
	cout << "Enter x: " << endl;
	
	double x;
	cin >> x;
	cout << endl;
	
	cout << "Enter y: " << endl;
	
	double y;
	cin >> y;
	cout << endl;
	
	cout << "Enter z: " << endl;
	
	double z;
	cin >> z;
	cout << endl;
	
	Point p11(x,y,z); //Point 1 for 2nd solution
	
	cout << endl << "Please enter values for point 2: " << endl;
	cout << "Enter x: " << endl;
	
	cin >> x;
	cout << endl;
	
	cout << "Enter y: " << endl;
	
	cin >> y;
	cout << endl;
	
	cout << "Enter z: " << endl;
	
	cin >> z;
	cout << endl;
	
	Point p12(x,y,z);
	
	cout << endl << "Please enter values for point 2: " << endl;
	cout << "Enter x: " << endl;
	
	cin >> x;
	cout << endl;
	
	cout << "Enter y: " << endl;
	
	cin >> y;
	cout << endl;
	
	cout << "Enter z: " << endl;
	
	cin >> z;
	cout << endl;
	
	Point p13(x,y,z);
	
	cout << "Area = " << computeArea(p11, p12, p13) << endl; 
	
	return 0;
}

/******************************************************************************************
**************Compute Area calculates area of a triangle using 3 points *******************
*******************************************************************************************/

double computeArea(Point& p1, Point& p2, Point& p3)
{
	//using hero formula 
	double a = p1.distance(p2); // distance between p1 and p2
	double b = p2.distance(p3); //distance between p2 and p3
	double c = p3.distance(p1); //distance between p3 and p1
	
	//cout << &p1 << endl;
	
	//p1.setX(-2000);
	
//	cout << "a = " << a << " b = " << b << "c = " << c << endl;
	
	double s = (a + b + c) / 2;
	
//	cout << "s = " << s << endl;
	
	double area = sqrt(s * (s - a) * (s - b) * (s - c));
	
	return area;
}

/*******************************************************************************************************
  ********* Read point - reads input from user and use these values to create a new point ******
* *****************************************************************************************************/

// I am returning Point* from readPoint function. Try returning only Point and see what happens.

Point* readPoint()
{
	cout << endl << "Please enter values for point: " << endl;
	cout << "Enter x: " << endl;
	
	double x;
	cin >> x;
	cout << endl;
	
	cout << "Enter y: " << endl;
	
	double y;
	cin >> y;
	cout << endl;
	
	cout << "Enter z: " << endl;
	
	double z;
	cin >> z;
	cout << endl;
	
	Point *point = new Point(x, y, z); // using heap for object creation. Why stack is not used here?
	
	//Point point4(x, y, z); //without dynamic memory
	
	//cout << &point4 << endl;
	
	return point;
}


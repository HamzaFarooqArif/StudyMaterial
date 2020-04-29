#include "Point.h"
#include <cmath>
#include <iostream>

using namespace std;

/************************************
  ********* Constructors ************
* ***********************************/

Point::Point()
{
}

Point::Point(double newX, double newY, double newZ)
{
	x = newX;
	y = newY;
	z = newZ;
}

/************************************
  ********* Getters ************
* ***********************************/

double Point::getX()
{
	return x;
}

double Point::getY()
{
	return y;
}

double Point::getZ()
{
	return z;
}
/************************************
  ********* Setters ************
* ***********************************/

void Point::setX(double x)
{
	this->x = x; 
}

void Point::setY(double y)
{
	this->y = y; 
}

void Point::setZ(double z)
{
	this->y = y; 
}

/************************************
  ********* Distance to function ****
* ***********************************/

double Point::distance(Point & point)
{
	double xDifferenceSquare = (point.getX() - x) * (point.getX() - x);  //note this.x can also be used in place of x
	double yDifferenceSquare = (point.getY() - y) * (point.getY() - y); // (y2 - y1) * (y2 - y1)
	double zDifferenceSquare = (point.getZ() - z) * (point.getZ() - z);  // (z2 - z1) * (z2 - z1)
	
	double distance = sqrt(xDifferenceSquare + yDifferenceSquare + zDifferenceSquare);
	
	return distance;
}

/*************************************************
  ********* Prints point for our ease ************
* ************************************************/

void Point::printPoint()
{
	cout << endl << "P(" << x << ", " << y << ", " << z << ")" << endl; 
}

/*************************************************
  ********* Destructor ***************************
* ************************************************/


Point::~Point()
{
	cout << endl << "Destructor for Point class called" << endl; 
}

//end of file

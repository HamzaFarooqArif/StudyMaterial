
/*Header for Point class*/

class Point
{
	// private attributes for Point class
	private:
		double x;
		double y;
		double z;
		
	// public functions of point class
	public:
		Point();
		Point(double newX, double newY, double newZ);
		
		//geters
		double getX();
		double getY();
		double getZ();
		
		//setters
		void setX(double x);
		void setY(double y);
		void setZ(double z);
		
		//distance function - member function of point class
		
		double distance(Point & point);
		
		// print point function
		
		void printPoint();
		
		//destructor
		
		~Point();
		
};

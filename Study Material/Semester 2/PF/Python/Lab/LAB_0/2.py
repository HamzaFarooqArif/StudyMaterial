from math import sqrt
p1x=int (input("Enter x-component of point1"))
p1y=int (input("Enter y-component of point1"))
p2x=int (input("Enter x-component of point2"))
p2y=int (input("Enter y-component of point2"))

distance=sqrt( ((p2x-p1x)**2) + ((p2y-p1y)**2) )
print (distance)

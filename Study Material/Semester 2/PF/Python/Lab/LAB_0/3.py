from math import sqrt
a=int (input("Enter the value of a"))
b=int (input("Enter the value of b"))
c=int (input("Enter the value of c"))

disc = (b**2) - (4*a*c)

if disc < 0:
   print ("Roots are imaginary")
else:
   x1=(-b-sqrt(disc))/(2*a)
   x2=(-b+sqrt(disc))/(2*a)
   print (x1)
   print (x2)
   
   




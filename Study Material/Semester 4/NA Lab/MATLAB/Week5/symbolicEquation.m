%this program calculate the diffrential and 
%definite integral of a implicit function
%f.. is the implicit function
%f1... diffrential of func
%f0... definite integral of func
%function is from the book "thomos calculus ed. 12 "
syms x y
f = x  / x^2 + y^2; 
f1 = diff(f, x)
f0 = int(f, x)

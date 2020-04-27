%                  $$$  Lab 3 question 1 $$$
%
% ~ in this question i will implement a function of x and y variable
%   symbolically
% ~ here x and y are the variables of function which would be symbols 
%   and f is the function of x and y the function f is taken from a textbook
%   of maths in engineering (A first course in differential equation) 
%   chapter 1 exercise 1.1
% ~ on that function f we will calculate its differential w.r.t x and y
%   respectively.
% ~ and then the integral w.r.t to x and y respectively.
% ~ the differential and integral both are partial 


syms x y % symbols x and y


f = (x / (x^2 + y^2)^(1/2)) % function 

differential_wrt_x = diff(f, x) % differential of f w.r.t x

differential_wrt_y = diff(f, y) % differential of f w.r.t y

integration_wrt_x = int(f, x) % integral of f w.r.t x

integration_wrt_y = int(f, y) % integral of f w.r.t y


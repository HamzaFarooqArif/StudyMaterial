f = @(x) x^3 - 2*x - 5;
tol = 10^-5;
x0 = 0.5;
x1 = 0.8;
format long;
format compact;
val = myregulafalsi(f,x0,x1,tol)
error = f(val)

function x = myregulafalsi(f,x0,x1,tol)
y0 = f(x0);
y1 = f(x1);
iter = 1;
while (abs(x0-x1) >= tol)
% ---------Printing parameters---------
str = ['-----------', num2str(iter), 'th iteration-----------'];
disp(str);
str = ['xn = ', num2str(x0)]; 
disp(str); 
str = ['xn+1 = ', num2str(x1)]; 
disp(str);
str = ['yn = ', num2str(y0)]; 
disp(str);
str = ['yn+1 = ', num2str(y1)]; 
disp(str);
iter = iter + 1;
% ---------Printing parameters---------
x = (x0.*y1 - x1.*y0)/(y1 - y0);
y = f(x);
x0 = x1;
y0 = y1;
x1 = x;
y1 = y;
end
end
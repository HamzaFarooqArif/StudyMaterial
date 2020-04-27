f = @(x) x^3 - 2*x - 5;
f1 = @(x) 3*x^2 - x;
tol = 10^-5;
x0 = 0.5;
format long;
format compact;
val = newton(f,f1,x0,tol)
error = f(val)

function x = newton(f, f1, x0, tol)
         x = x0;
         i = 0;
         y = f(x);
         iter = 1;
         while abs(y) > tol && i < 1000
% ---------Printing parameters---------
str = ['-----------', num2str(iter), 'th iteration-----------'];
disp(str);
str = ['x = ', num2str(x)]; 
disp(str); 
str = ['y = ', num2str(y)]; 
disp(str);
iter = iter + 1;
% ---------Printing parameters---------
             x = x - y/f1(x);
             y = f(x);
             i = i+1;
         end
end
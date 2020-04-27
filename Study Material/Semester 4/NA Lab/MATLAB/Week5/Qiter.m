f = @(x) x - sin(x) - 1/2;
O = @(x) sin(x) + 1/2;
O1 = @(x) cos(x);
tol = 10^-5;
x0 = 0.5;
format long;
format compact;

val = iterative(O,O1,x0,tol)
error = f(val)

function x = iterative(O, O1, x0, tol)
         x = x0;
         i = 0;
         y = f(x);
         while abs(y) > tol && i < 1000
end
f = @(x)2*cosh(x)*sin(x)-1
x(1) = 0.4;
x(2) = 0.5;
tol = 0.00000001;
iterations = 0;
i =2;
eps = 1^10
while(eps > tol)
    x(i+1) = x(i) - f(x(i))*(x(i)-x(i-1))/(f(x(i))-f(x(i-1)));
    eps = x(i+1) - x(i);
    i = i+1;
    x(i);
end


    
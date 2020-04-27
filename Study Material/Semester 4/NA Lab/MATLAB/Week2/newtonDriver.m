a = @(x) x.^5 - 7;
b = @(x) 5.*x.^4;

format long
c = mynewton(a, b, 2, 6);
error = 1.47577 - c
residual = abs(error)


f = @(x) x.^(1/3);
f1 = @(x) (1/3)*x.^(-2/3);

mynewton(f, f1, 0.1, 10);
f = @(x) x.^2;
f1 = @(x) 2.*x;
x = mynewton(f, f1, 1, 10);

function x = mysymnewton(f, x0, n, tol)
syms x;
f = (x.^3) - 4;
n = 1000;
tol = 10.^ -4;
x0 = 2;
f1 = diff(f);
f = subs(f, 2);
f1 = subs(f1, 2);
x = x0;
for i = 1:n
    x = x - f/f1;
end
    r = abs(f);
    if r > tol
        warning('Tolerence not achieved')
        tol
    end
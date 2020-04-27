% Declare given f as anonymous function
f = @(x) tan(pi * x) - 6;
% Get its derivative as f1
f1 = pi*(tan(pi*x)^2 + 1);

disp('Using Bisection method')
bisect(f, 0, 0.48, 10^-10)

disp('Using False position method');
myregulafalsi(f, 0, 0.48, 10, 10^-6);

disp('using secant method');
mysecant(f, 0, 0.48, 10, 10^-6);


function x = bisect(f, a, b, tol)
c = f(a);
d = f(b);
i = 0;
while ( abs(a-b) > tol)
    i = i +1;
if c*d > 0.0
"function has same sign at both endpoints"
end
% disp('x y')
    x = (a + b) / 2;
    y = f(x);
%     disp([x y])
    if y == 0.0
        break
    end
    if c*y < 0
        b = x;
    else
        a = x;
    end  
end
end

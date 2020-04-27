f = @(x) x - sin(x);
tol = 10^-5;
x0 = 1;
x1 = 3;
format long;
format compact;
val = bisect(f,x0,x1,tol)
error = f(val)

function x = bisect(f, a, b, tol)
c = f(a);
d = f(b);
i = 0;
while ( abs(a-b) > tol)

if c*d > 0.0
"function has same sign at both endpoints"
end
%disp('x y')
    x = (a + b) / 2;
    y = f(x);
    %disp([x y])
    if y == 0.0
        break
    end
    if c*y < 0
        b = x;
    else
        a = x;
    end
 % ---------Printing parameters---------
str = ['-----------', num2str(i + 1), 'th iteration-----------'];
disp(str);
str = ['xn = ', num2str(a)]; 
disp(str); 
str = ['xn+1 = ', num2str(b)]; 
disp(str);
str = ['yn = ', num2str(y)]; 
disp(str);
str = ['yn+1 = ', num2str(d)]; 
disp(str);
i = i + 1;
% ---------Printing parameters---------

end


% x = (a + b) / 2
% e = (b-a)/ 2
% i

end


    
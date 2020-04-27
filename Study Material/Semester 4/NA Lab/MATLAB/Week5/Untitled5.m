f = @(x)x^3 - 4;
x1 = 1;
x2 = 3;
n = 20;
f1 = f(x1);
f2 = f(x2);
c = x2 - ((f(x2)*(x2-x1))/(f(x2)-f(x1)))
f3 = f(c);
if f1*f2 < 0
    for i = 1:n
        if f3<0
            x1 = c
            f1 = f(x1);
            c = x2 - (f1*(x1-x2)/(f1-f2))
            f3 = f(c)
        else
            x2 = c;
            f2 = f(x2);
            c =x2 - (f2*(x2-x1)/(f2-f1))
            f3 = f(c)
        end
    end
else
    disp('wrong interval')
end



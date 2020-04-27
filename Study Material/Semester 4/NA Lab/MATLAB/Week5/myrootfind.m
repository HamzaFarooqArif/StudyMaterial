function [a,b] = myrootfind(f,a0,b0)
n = 1001;
a = [];
b = [];
x = linspace(a0,b0,n);
y = f(x);
for i = 1:(n-1)
    if y(i) * y(i+1) < 0
        a = [a x(i)];
        b = [b x(i+1)];
    end
end
if size(a,1) == 0
    "no roots were found"
end
end


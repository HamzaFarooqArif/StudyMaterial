function x = mypi(n)
x = 0;
a =1 ;
b = 3;
for i = 1:n
    x = x+ 8*(1/(a*b));
    a = a+4;
    b = b+4;
end
m = x - pi
relative = m /pi
end

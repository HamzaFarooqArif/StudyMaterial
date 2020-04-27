function x = seriesSum(x)
sum = 1;
i =1;
n = 1;
while(n > 10)
    i = x*i;
    p = 1 - x^n+1 / 1 - x;
    sum  = sum + p
    i = i + 1;
end
end
    
    
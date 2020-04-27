% this program basically calculate the sum using 
% sum = x^n / n!
% calculate the actual and approximate values
% and absolute error 
x = -20;
n = 1;
sum = 0;
i = 1;
while(n < 20)
    s = (x ^ n) / factorial(n);
    
    sum = sum + s
    n = n+1;
end
   
approx  = sum
actual  = exp(x)
error = abs(actual - approx) 
% for n = 10 , error is 7.6672e+06
% for n = 15, error is 2.7134e+8
% for n = 20, error is 1.6823e+9
% and so on ,... for different values of n we get different results
% so error never becomes zero
% this error occurs due to rounding or truncationtion
% error due to power of exp is also involved

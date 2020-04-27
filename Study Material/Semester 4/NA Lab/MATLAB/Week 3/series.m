% Question 2
% This script calculates the e^x for x = -20
% As it is an infinite series, the calculation will terminate at some n
% Many mathematical operations and truncation makes the calculated value
% least accurate as compared to actual value

x = -20; % given x value
n = 94; % number of iterations at which result stops changing
result = 0; % initialized to zero
actual_result = exp(x); % actual value


for i = 0:n; % Calculate the partial sum for n terms
    result = result + (x^i / factorial(i));
end
abs_error = abs(result - actual_result); % absolute error in computation
n
actual_result
result
abs_error

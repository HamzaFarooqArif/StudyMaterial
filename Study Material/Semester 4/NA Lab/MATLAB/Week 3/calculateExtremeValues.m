%Question 3
% 
% This script calculates the extreme values of function under a given
% interval. First critical points are calculated at which the function is
% neither increasing nor decreasing. The script iterates through the
% interval by putting the values in function and by the help of critical
% values, extreme values are determined.
% symbolic notation and functions are used because we have to calculate the
% differential of given function.


syms x;  % define symbol for symbolic functions

format compact; % Increase readability

% First function definition
f_1 = sin(x) + cos(x); 
f_1_interval = [0, 2*pi]; % its interval
[f_1_min, f_1_max] = calculateExtremeValuesA(f_1, f_1_interval)


% Second function definition 
f_2 = x^4 - 3*x^3 - 1;
f_2_interval = [-2, 2]; % its interval
[f_2_min, f_2_max] = calculateExtremeValuesA(f_2, f_2_interval)


% the function which calculates the extreme values of function
function [maximum, minimum] = calculateExtremeValuesA(f, interval)

d = diff(f); % derivative of function
y = solve(d); % solve derivative , critical points
m = min(y); % minimum critical point
n = max(y); % maximum critical point

% Compute extreme values of input function f
if(m >= interval(1) && n <= interval(2))
    maximum = subs(f, n);
    minimum = subs(f, m);
else
    maximum = subs(f, interval(2));
    minimum = subs(f, interval(1));
end
end
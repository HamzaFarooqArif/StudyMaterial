function [area] = mymidpoint(f,a,b,n)
% Calculate integral of f(x) using mid point rule
% INPUT:   f -- a function handle
%          a -- lower limit of interval
%          b -- upper limit of interval
%          n -- number of subintervals of [a,b]
% OUTPUT:  area -- area under the curve

h = (b-a)/n; % Calculate subinterval
x = a:h:b; % creating the partition on interval [a,b]
m = (x(1:end-1)+x(2:end))/2; %calculating mid-points of subintervals.
area = h*sum(f(m)); %The mid-point formula.

end
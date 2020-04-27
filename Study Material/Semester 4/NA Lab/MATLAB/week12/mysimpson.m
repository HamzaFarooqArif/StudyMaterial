function S = mysimpson(f, a, b, n)
% Calculates Simpsons rule by calling mysimpweights
% INPUT:   f -- a function handle
%          a -- lower limit of interval
%          b -- upper limit of interval
%          n -- number of subintervals of [a,b]
% OUTPUT:  S -- simpsons rule

     h = (b - a) / n; % Calculate the subinterval
     x = a:h:b; % Calculate x vector
     % Calculate Simpsons rule by calling mysimpweights
     S = (h/3)*dot(f(x), mysimpweights(n));
end
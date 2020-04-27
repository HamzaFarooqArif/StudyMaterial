f = @(x) sqrt(x); % Declare an anonymous function
a = 1; % Lower Limit of interval
b = 2; % Upper Limit of interval
mysimpson(f, a, b, 4) % Calcualte simpsons rule for n = 4
mysimpson(f, a, b, 100) % Calcualte simpsons rule for n = 100

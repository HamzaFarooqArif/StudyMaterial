% Question2
% Plots the graph of exponential decay curve of a sine wave
% on the interval [0, 40]

% Fix the domain of Time on X-axis with 1000 samples
x = linspace(0,40,1000);
% Function 1 + sin(x - pi/3).*exp(-0.2*x) on Y-axis
y = F(x);

% Plot the corresponding sine wave
plot(x, y);

function y = F(x)
% Computes the function 1 + sin(x - pi/3).*exp(-0.2*x)
% Input: x --  a number or vector
% Output: y -- a number or vector
         y = 1 + sin(x - pi/3).*exp(-0.2*x);
end
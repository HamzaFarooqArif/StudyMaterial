% Question 1
% Plots the graph of exponential decay curve of a sine wave function
% its derivative and its integral

% Define symbols to be used in symbolic functions
syms x;
% Declare symbolic function of decay curve of sine wave
f = 1 + sin(x - pi/3).*exp(-0.2*x);
% Get first derivative of f(x)
f1 = diff(f);
% Get integral of f(x)
intf = int(f);
% Plot f(x), derivative of f(x) and integral of f(x) on the same figure
fplot(f, '-');
hold on;
fplot(f1, 'o-');
hold on;
fplot(intf, 'x-');

% Set the title of the graph
title('Graph of f, diff(f) and int(f) -5 to 5');
% Set x-axis label
xlabel('-5 < x < 5');
% Set y-axis label
ylabel('f(x), f1(x) and intf(x)');
% Set Legend for readability
legend('f(x)','f1(x)', 'intf(x)');
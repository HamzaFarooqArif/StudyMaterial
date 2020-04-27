% mygraphs
% plots the graphs of x, x^2, x^3, and x^4
% on the inetrval [-1 ,1]

% fix the domain and evaluation points
x = -1:.1:1;

% calculate powers
% x1 is just x
x2 = x.^2;
x3 = x.^3;
x4 = x.^4;

% plot each of the graphs
plot(x, x, '+-', x, x2, 'x-', x, x3, 'o-', x, x4, '--')
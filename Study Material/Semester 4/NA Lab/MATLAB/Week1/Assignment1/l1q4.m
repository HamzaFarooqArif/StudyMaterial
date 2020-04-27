% Question4
% plots the graphs of sinx, sin2x, sin3x, sin4x, sin5x and sin6x
% on the inetrval [0, 2pi] on one plot

% fix the domain and evaluation points
x = linspace(0, 2.*pi, 1000);

% calculate Sinusoidal Functions
x1 = sin(x);
x2 = sin(2.*x);
x3 = sin(3.*x);
x4 = sin(4.*x);
x5 = sin(5.*x);
x6 = sin(6.*x);

% plot each of the graphs
plot(x, x1, x, x2, x, x3, x, x4, x, x5, x, x6)
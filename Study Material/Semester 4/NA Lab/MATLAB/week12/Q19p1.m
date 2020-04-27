% Part A ----------------------------------------------------------------
x = [0 0.1 0.499 0.5 0.6 1.0 1.4 1.5 1.899 1.9 2.0]; % Given data x-axis
y = [0 0.6 0.17 0.19 0.21 0.26 0.29 0.29 0.30 0.31 0.31]; % Given data y-axis
xx = linspace(0,2,200); % Sample x-points for smoothing the graph
plot(x,y,'*');
xlabel('0.0 < t < 2.0'); % x-axis label
ylabel('0.0 < y < 0.31'); % y-axis label
% Tools->Basic Fitting->8th degree polynomial
% Part B ----------------------------------------------------------------
hold on; % Plot the graph on the same figure
plot(xx,csapi(x,y,xx)); % Plot spline interpolant
legend('y(t)','Spline'); % Indicate what each graph is about
title('Spline Interpolant'); % Title the graph

% 8th degree polynomial doesn't satisfy two ordered pairs (0.499, 0.17)
% and (0.5, 0.19). So spline interpolant is better because all points
% lie on the curve.
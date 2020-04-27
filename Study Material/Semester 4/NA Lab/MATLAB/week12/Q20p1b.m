x = [40.3 49.28 53.37 52.40 40.42 62.59 66.17 71.70 36.73 58.95 60.91 66.41];
y = [0.253 0.302 0.418 0.374 0.367 0.325 0.420 0.492 0.447 0.431 0.489 0.694];
plot(x, y, '*');

xlabel('40.3 < MPa < 66.41'); % x-axis label
ylabel('0.253 < A < 0.694'); % y-axis label
legend('table data'); % Indicate what each graph is about
title('Stress Strain Curve'); % Title the graph

% Spline interpolant fits best and all points lie on the curve


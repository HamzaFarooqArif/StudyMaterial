x = 100:50:600;
y = [49.5 49.6 52.2 52.2 52.8 52.8 53.5 54 55 55.6 56];
plot(x, y, '*');
xlabel('100 < FPM < 600'); % x-axis label
ylabel('49.5 < Drive < 56'); % y-axis label
legend('table data'); % Indicate what each graph is about
title('Decibel Meter'); % Title the graph

% 10th degree poly nomial fits best and all points lie on the curve


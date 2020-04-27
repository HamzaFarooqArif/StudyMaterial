% Q4 Part C-------------------------------------------------------
A = [1.2969 .8648; .2161 .1441]; % Given Matrix A
b1 = [1.2969; 0.2161];
disp('Solution using b1:');
x = A\b1 % Find first solution matrix

b2 = [1.297; 0.216]; % Rounded off upto 3 decimal digits
disp('Solution using b2:');
x2 = A\b2 % Find second solution matrix

% all small changes A and b in A and b and the resulting change,
% x, in the solution x. Here maximum change in solution x that is
% x is 2.5e+8 approx. So, solution x will also be affected by b.
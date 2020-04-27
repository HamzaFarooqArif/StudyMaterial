A = [1 2; 3 4];
B = [-2 1 0;1 -2 1;0 1 -3];
tolerance = 0.1;
[vecA,valA,jA] = mypm(A,tolerance);% Calling "mypm" function by providing input matrix and tolerance
[vecB,valB,jB] = mypm(B,tolerance);
disp('The Eigen Value of A is:');
disp(valA); % Displaying the Dominant Eigen Value in command window
disp('The Eigen Value of B is:');
disp(valB); % Displaying the Dominant Eigen Value in command window
disp('The no. of iterations A are:');
disp(jA); % Displaying the No. of iterations in command window
disp('The no. of iterations B are:');
disp(jB); % Displaying the No. of iterations in command window

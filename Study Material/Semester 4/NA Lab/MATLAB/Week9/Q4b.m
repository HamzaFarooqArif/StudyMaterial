% Q4 Part B-------------------------------------------------------

% As the matrix A is rounded off to 3 decimal places, rows of matrix A
% becomes nearly a linear combination of each other. This leads the 
% matrix to be nearly singular and hence a large condition number.


format long;
format compact;
B = [1.297 .865; .216 .144]; % Matrix A Rounded off upto 3 decimal digits
disp('Determinant of B is:');
det(B) % Display determinant of B
disp('Inverse of B is:');
inv(B) % Display Inverse of B
% Display condition number of B
disp(['condition number of A = ', num2str(cond(A))]);

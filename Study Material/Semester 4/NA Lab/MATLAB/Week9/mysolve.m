function [x1,r1,x2,r2] = mysolve(A,b)
% Solves linear systems using the LU decomposition with pivoting
% and also with the built-in function A\b.
% Inputs: A -- the matrix
%         b -- the right-hand vector
% Outputs: x1 -- the solution using LU method
%          r1 -- the norm of the residual using LU method
%          x2 -- the solution using the built-in method
%          r2 -- the norm of the residual using the
%                built-in method

           % LU Decomposition method-----
           % Get upper and lower triangular matrices of matrix A
           [L,U] = lu(A); 
           x1 = U\(L\b); % Get LU method solution
           r1 = norm(x1); % Get residual

           % Matlab Built-in method-----
           x2 = A \ b;
           r2 = norm(x2);

end
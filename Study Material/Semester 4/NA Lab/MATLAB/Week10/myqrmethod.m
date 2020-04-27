function [E, steps ] = myqrmethod (A)
% Computes all the eigenvalues of a matrix using the QR method .
% Input : A -- square matrix
% Outputs : E -- vector of eigenvalues
% steps -- the number of iterations it took
[m n] = size (A);
if m ~= n
warning ('The input matrix is not square .')
return
end
% Set up initial estimate
H = hess (A);
E = diag (H);
change = 1;
steps = 0;
% loop while estimate changes
while change > 0
    if steps < 1001
Eold = E;
% apply QR method
[Q R] = qr(H);
H = R*Q;
E = diag (H);
% test change
change = norm (E - Eold );
steps = steps +1;
    end
end
end
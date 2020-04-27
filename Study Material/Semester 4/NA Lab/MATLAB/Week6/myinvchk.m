function y = myinvchk(n)
         A = randn(n, n);
         B = inv(A);
         C = A*B;
         Residual = C - eye(n);
         y = norm(Residual);
end
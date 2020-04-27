function e = mysolvecheck(n)

    %creating a random matrix A of nXn
    A = rand(n, n);

    %creating a random matrix b of nX1
    b = rand(n, 1);

    %calculating x using inverse(A) * b
    x = A\b;

    %calculatin r
    r = A*x-b;

    %calculating norm of r
    e = norm(r);
    
    %displaying error
    % disp(['e = ', num2str(e)]);
end



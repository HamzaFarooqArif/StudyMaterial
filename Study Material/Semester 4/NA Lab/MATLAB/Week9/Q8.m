% Q4 Part B-------------------------------------------------------
format long;
format compact;

n = 0; % Set initial dimensions to zero before loop is started

multiplier = 50; % Decide the incerement interval in 'n'

for N = n:1000 % Run loop for a larger value
    % Generate a random square matrix of random size
    A = rand(N*multiplier, N*multiplier);
    % Generate a random column vector of random size
    b = rand(N*multiplier, 1); 
    % solve using separately written 'mysolve' function
    sol = mysolve(A, b);
    % Generate and solve the hilbert matrix
    % sol2 = mysolve(hilb(N*multiplier), b);
    n = n + multiplier;
    disp(['current n value = ', num2str(n)]);
end


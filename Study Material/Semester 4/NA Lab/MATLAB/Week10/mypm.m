function [vector,value,i]=mypm(B,tolerance) % Creatinf function program 'mypm'
m = size (B ,1); % Start matrix for initial approximation
x = ones(m, 1);
residual=1;% Maximum tolerance allowed
n=10;% Initial assumption of dominant eigen vector
i=0;% Initialization for calculating no. of iterations
while residual > tolerance % Checking the condition for change in the vector is less than the tolerance
y=B*x
residual=abs(norm(x)-n);
n=norm(x)
x=y/n
i = i+1; % Final total No. of iterations
end
vector=x;% final dominant eigen vector
value=n;% final dominant eigen vector
end
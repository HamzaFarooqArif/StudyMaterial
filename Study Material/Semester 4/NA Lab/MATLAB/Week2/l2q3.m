f = @(x) x.^3 - 4; % Given function
f1 = @(x) 3*x.^2;  % its derivative
n = 3;             % number of iterations
x0 = 2;            % starting value
actValue = 4^(1/3);% Actual value
absError = [0, 0, 0, 0];% corresponding Absolute Errors
relError = [0, 0, 0, 0];% corresponding Relative Errors
perError = [0, 0, 0, 0];% corresponding Percentage Errors
X = A(f, f1, x0, n);    % array of calculated values
for idx = 1:4           % run 4 times and calculate
    absError(idx) = abs(actValue - X(idx));
    relError(idx) = absError(idx)/actValue;
    perError(idx) = relError(idx)*100;
end

f = figure; % make a figure
t = uitable(f); % insert table in figure
% Name the columns
t.ColumnName = {'ValueName','CalculatedValue','AbsoluteError', 'RelaiveError', 'PercentageError'};
% enter data
d = {'x0', X(1), absError(1), relError(1), perError(1);
     'x1', X(2), absError(2), relError(2), perError(2);
     'x2', X(3), absError(3), relError(3), perError(3);
     'x3', X(4), absError(4), relError(4), perError(4)};
% insert data in table
t.Data = d;
% set table position and size in figure
t.Position = [20 20 440 100];

function X = A(f, f1, x0, n)
% Solves f(x) = 0 using Newton's method
% Input: f -- the function
%        f1 -- f's derivative
%        x0 -- starting value
%        n -- number of iterations
% Output: X the approximate soltions array
         x = x0;            % set x equal to the initial value guess x0
         X = [2, 0, 0, 0];
         for i = 1:n        % do n times 
             x = x - f(x)/f1(x);
             X(i+1) = x;
         end
end
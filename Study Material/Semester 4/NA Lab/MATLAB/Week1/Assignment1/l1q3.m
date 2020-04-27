% Question3
% Plots the graph of y = (x.^2) .* (exp((-x).^2))
% on the interval [-5, 5]

% Fix the domain and evaluation points
x = linspace(-5, 5, 100);
% Compute the corresponding y values
y = F(x);

% Plot the graph
plot(x, y);

function y = F(x)
% Computes the function (x.^2) .* (exp((-x).^2))
% Input: x -- a number or vector;
%             for a vector the computation is elementwise
% Output: y -- a number or vector of the same size as x
         y = (x.^2) .* (exp((-x).^2));
end
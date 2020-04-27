function y = myfunc(x, p)
% Computes the function 2*x.^p - 3 * x + 1
% Input: x -- a number or vector;
%             for a vector the computation is elementwise
% Output: y -- a number or vector of the same size as x
         y = 2*x.^p - 3 * x + 1;
end
% Q6 -------------------------------------------------------

% In the given Aequiltruss matrix, the condition number is comparatively
% small because in that matrix none of the rows is linear combination of 
% any other row. On the other hand, rows of randomly generated matrix
% may have more than 1 linear combination of other rows. This leads to
% large condition number.

load('Aequiltruss.mat'); % Load truss matrix
condA = cond(A); % Get condition number of truss matrix
% Display condition number of truss matrix
disp(['Condition number of A = ', num2str(condA)]);

% 1-d arry to store condition numbers of randomly generated 7x7 arrays
condArr = [];
condSum = 0; % Sum of condition numbers of randomly generated 7x7 arrays
for i = 1:1000
    B = rand(7, 7); % Generate a local 7x7 matrix
    condArr(i) = cond(B); % Add an element in condition number array 
    % Add condition number in the total sum
    condSum = condSum + condArr(i);
end

% Get mean of all condition numbers
MeanCond = condSum / 1000;
% To get median, array data must be sorted
sortedCondArr = sort(condArr);
% Get median of all condition numbers
medianCond = sortedCondArr(500);
% Display median
disp(['Median of condition numbers = ', num2str(medianCond)]);
% Display average
disp(['Mean of condition numbers = ', num2str(MeanCond)]);

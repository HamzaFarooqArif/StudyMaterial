format long
format compact
r = [0.9, 0.99, 0.999, 0.9999, 0.99999]; % Array of r's values
Snew = [0, 0, 0, 0, 0]; % Corresponding Snew array
i = [0, 0, 0, 0, 0]; % Corresponding iterations array
ActError = [0, 0, 0, 0, 0]; % Corresponding Actual array
RError = [0, 0, 0, 0, 0]; % Corresponding Relative array
for idx = 1:5 % Run 5 times
    Sold = -1;
    while (Snew(idx)) > Sold
    Sold = Snew(idx);
    Snew(idx) = Snew(idx) + (r(idx))^i(idx);
    i(idx) = i(idx) + 1;
    end
% Calculate Actual Error
ActError(idx) = 1/(1 - r(idx)) - Snew(idx);
% Calculate Relative Error
RError(idx) = (ActError(idx))/(1/(1 - r(idx)));
end

f = figure; % make a figure
t = uitable(f); % insert table in figure
% Name the columns
t.ColumnName = {'r','RelativeError','Iterations'};
% enter data
d = {r(1),RError(1),i(1);r(2),RError(2),i(2);r(3),RError(3),i(3);r(4),RError(4),i(4)};
% insert data in table
t.Data = d;
% set table position and size in figure
t.Position = [20 20 260 95];
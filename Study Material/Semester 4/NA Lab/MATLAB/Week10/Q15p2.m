
T = @(m, k) 2*pi*sqrt(k/m);
f = @(m, k) sqrt(k/m);

% Part A ---------------------------------------------
% m1 = 1kg, m2 = 2kg so
m = 3;
disp('Frequency for PartA');
Freq1 = f(m, k)

% Part B ---------------------------------------------
% m1 = 1kg, m2 = 2kg, m3 = 3kg so
m = 6;
disp('Frequency for PartB');
Freq2 = f(m, k)

% So Freq1 = sqrt(2)*Freq2
% Lowest frequency mode may have the largest displacement, that is
% also called fundamental mode of frequency. The two modes then move
% with the different frequencies.

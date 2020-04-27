format long;
format compact;
f = @(x) sqrt(x); % Define an anonymous function
a = 1; % Lower limit of interval
b = 2; % Upper limit of interval
[Ln, Rn, Tn] = myints(f, a, b, 100); % myints function call

% Calculate the precentage errors in corresponding results
eLn = abs((1.2190 - Ln)/2)*100;
eRn = abs((1.2190 - Rn)/2)*100;
eTn = abs((1.2190 - Tn)/2)*100;

% Display Results along with their percentage errors
disp(['Ln = ', num2str(Ln), ' error = ',num2str(eLn), '%']);
disp(['Rn = ', num2str(Rn), ' error = ',num2str(eRn), '%']);
disp(['Tn = ', num2str(Tn), ' error = ',num2str(eTn), '%']);
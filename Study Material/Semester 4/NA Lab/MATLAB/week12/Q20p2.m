% time vector
t = 0:8;
% concentration vector
C = [3.033 3.306 3.672 3.929 4.123 4.282 4.399 4.527 4.622];

% plotting data
figure
plot(t,C,'-*');
% setting axis-lables
xlabel('Time') % x-axis label
ylabel('Concentration') % y-axis label
hold on;

% exponential fitting of data using polyfit function
exp_fit = fit(t(:),C(:),'exp1');
disp('Exponential fit coefficients are:');
disp(exp_fit);

% coefficients a and b
a = exp_fit(1);
b = exp_fit(2);

% display a and b
disp('coefficients a and b of linear fit ax+b are: ');
disp('a: ');
disp(a);
disp('b: ');
disp(b);

% linear fitting of data using polyfit function
linear_fit = polyfit(t,C,1);
disp('linear fit coefficients are:');
disp(linear_fit);

% coefficients a and b
a = linear_fit(1);
b = linear_fit(2);

% display a and b
disp('coefficients a and b of linear fit ax+b are: ');
disp('a: ');
disp(a);
disp('b: ');
disp(b);

% interval 0 to 10
interval = 0:0.5:10;
% exponential curve values for 0 to 10 expr = a-b*e^(-0.2t)
expr = a-b.*exp(-0.2.*interval);
expr1 = 5.025-2.066.*exp(-0.2.*interval);

figure
% plotting exponential solid curve for interval [0,10]
plot(interval,expr,'b');
hold on
% plotting exponential solid curve for interval [0,10]
plot(interval,expr1,'g');
hold on
% plot original data
plot(t,C,'*')
hold on
% plotting linear fit
plot(t,polyval(linear_fit,t));
hold off
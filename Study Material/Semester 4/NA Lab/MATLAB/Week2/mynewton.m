f = @(x) x.^3 - 4;
f1 = @(x) 3*x.^2;
n = 3;
x0 = 2;
actValue = 4^(1/3);
absError = [0, 0, 0, 0];
relError = [0, 0, 0, 0];
perError = [0, 0, 0, 0];
X = A(f, f1, x0, n);
for idx = 1:4
    absError(idx) = abs(actValue - X(idx));
    relError(idx) = absError(idx)/actValue;
    perError(idx) = relError(idx)*100;
end
absError
relError
perError

function X = A(f, f1, x0, n)
         x = x0;
         X = [2, 0, 0, 0];
         for i = 1:n
             x = x - f(x)/f1(x);
             X(i+1) = x;
         end
end
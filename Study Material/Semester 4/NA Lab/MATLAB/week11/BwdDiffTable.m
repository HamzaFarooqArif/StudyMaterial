function table = BwdDiffTable(f, h, x0, xn)
x = x0:h:xn;
fx = [];
revFx = [];
diff = [];
table = [];
alter = false;
for i=1:length(x)
    fx(i) = f(x(i));
end

for i=1:length(x)
    revFx(i) = fx(length(x)-i+1);
end

for i=x0:length(x)
        if alter == false
            for j=x0:length(x)-i
                diff(j, i) = -backwardDiff(i, length(x)-j+1, revFx);
            end
            alter = true;
        else
            for j=x0:length(x)-i
                diff(j, i) = backwardDiff(i, length(x)-j+1, revFx);
            end
            alter = false;
        end
    end

for i=x0:length(x)
    table(i, 1) = x(i);
end
for i=x0:length(x)
    table(i, 2) = fx(i);
end
for i=x0:length(x)
    for j=x0:length(x)-i
        table(j, 2+i) = diff(j, i);
    end
end
end

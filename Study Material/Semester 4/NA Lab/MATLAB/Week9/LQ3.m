valueArray = [10, 50, 100, 500, 1000];
residual = [];
temp = 0;
for i=1:length(valueArray)
    n = valueArray(i);
    temp = 0;
    for j = 1:10
        temp = temp + mysolvecheck(n);
    end  
    residual(i) = temp /10;
end


loglog(valueArray, residual, '-s');
title('Graph b/w n and residual');
xlabel("n values"); ylabel("residual values");
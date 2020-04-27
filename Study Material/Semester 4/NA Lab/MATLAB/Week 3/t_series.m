function y = t_series(x, n)
         sum = 0; 
         for i = 1:n
             sum = sum + x.^i;
         end
         y = sum;
end

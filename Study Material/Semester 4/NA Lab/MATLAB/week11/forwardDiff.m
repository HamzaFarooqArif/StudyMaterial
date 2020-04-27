function x = forwardDiff(pow, val, table)
       if pow == 1
           x = table(val + 1) - table(val);
       else
           x = forwardDiff((pow - 1), val + 1, table) - forwardDiff((pow - 1), val, table);
       end
end
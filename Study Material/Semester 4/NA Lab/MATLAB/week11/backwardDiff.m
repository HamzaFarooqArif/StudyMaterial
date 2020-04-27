function x = backwardDiff(pow, val, table)
       if pow == 1
           x =  table(val) - table(val - 1);
       else
           x =  backwardDiff((pow - 1), val, table) - backwardDiff((pow - 1), (val - 1), table);
       end
end
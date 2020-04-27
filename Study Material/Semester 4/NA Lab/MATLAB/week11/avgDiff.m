function x = avgDiff(pow, X, h, f)
       if pow == 1
            x = f(X + h/2) + f(X - h/2);
       else
            x =  (avgDiff((pow - 1), X, h, f) + avgDiff((pow - 1), X+h, h, f));
       end
end
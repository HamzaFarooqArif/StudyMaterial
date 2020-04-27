function x = mynewtontol(f, f1, x0, tol)
         x = x0;
         i = 0;
         y = f(x);
         while abs(y) > tol && i < 1000
             x = x - y/f1(x);
             y = f(x);
             i = i+1;
         end
end
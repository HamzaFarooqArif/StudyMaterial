function x = mynewton2(f, f1, x0, n, tol)
         x = x0;
         for i = 1:n
             x = x - f(x)/f1(x);
         end
         r = abs(f(x));
         if(r > tol)
             warning('The desired accuracy was not attained')
         end
end

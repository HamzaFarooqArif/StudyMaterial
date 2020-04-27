function [Ln, Rn, Tn] = myints(f, a, b, n)
     % Calculates Left hand point, Right hand point and Trapezoid Rule
     % INPUT:  f -- a function handle
     %         a -- lower limit of integral
     %         b -- upper limit of integral
     %         n -- number of divisions
     % OUTPUT: Ln -- Left hand point
     %         Rn -- Right hand point
     %         Tn -- Trapezoid Rule
     h = (b - a) / n; % Interval
     clear x y; % clear x y vectors in Workplace
     x(1) = a; % Set very first element x vector
     y(1) = f(x); % Set very first element of y vector
     for i=1:n % update x and y vectors
         x(i+1) = x(i) + h; 
         y(i+1) = f(x(i+1));
     end
     % Initialization to zero
     Ln = 0; 
     Rn = 0;
     for i=1:n % Update Left and Right hand points
         Ln = Ln + y(i);
         Rn = Rn + y(i+1);
     end
     % Calculate Left and Right hand points
     Ln = h*Ln; 
     Rn = h*Rn;
     Tn = (Ln + Rn) / 2; % Calculate Trapezoid Rule
end
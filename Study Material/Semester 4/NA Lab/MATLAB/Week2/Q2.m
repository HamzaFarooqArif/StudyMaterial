function S = Q2(n)
         S = 0;
         a = 1;
         for i = 1:n
             S = S + 1/(a.*(a+2));
             a = a + 4;
         end
         S = S.*8;
         ActualError = pi - S
         AbsoluteError = (1/2).*(10.^-4)
         RelativeError1 = ActualError/S
end
function c = mysimpweights(n)
       if rem(n,2) == 0
       %for n intervals there will be n+1 points y0 to yn
       c = ones(n+1,1); % initialize weights to 1
       for i = 2:n
           if rem(i,2)==0
               c(i)=4; % W_odd = 4
           else
               c(i)=2; % W_even = 2
           end
       end
       else
           error('n must be even for Simpsons rule') %number of intervals, must be even
       end
end
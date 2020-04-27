format long
format compact
n = 1; % number of collisions is set to 1
% Run while ball stops bouncing
while totalDist(n) < totalDist(n + 1)
     n = n + 1;
end
% Display number of collisions
n
% Display Total distance travelled
Distance_travelled = totalDist(n)

function distance = totalDist(n)
% Calculates the total distance travelled in n collisions
% Input: n -- number of collisions
% Output: distance: total distance travelled by the ball
         coeff = 0.9; % coeff of compensation of collision
         height = 2;  % Initial height
         distance = 0;% Total distance travelled
         for idx = 1:n % Run for n collisions
             distance = distance + height; 
             height = height*coeff.^2;
         end
end    
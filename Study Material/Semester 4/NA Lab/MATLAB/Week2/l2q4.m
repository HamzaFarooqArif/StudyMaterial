format long
format compact
coeff = 0.9; % coeff of compensation of collision
height = 2;  % Initial height
distance = 0;% Total distance travelled
n = 0;       % Number of collisions
while height > 0.001 % Run until height approaches to 1mm
    distance = distance + height;
    height = height*coeff.^2;
    n = n + 1; % count number of collisions
end
% Display number of collisions
n
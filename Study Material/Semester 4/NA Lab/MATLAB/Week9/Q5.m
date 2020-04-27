% Q5 -------------------------------------------------------------



B = [sin(sym(1)) sin(sym(2)); sin(sym(3)) sin(sym(4))];
c = [1; 2];
x = B \ c;
pretty(x);

Cs = [sym(1) sym(2); sym(2) sym(4)];
Cn = double(Cs);
d1 = [4; 8];
d2 = [1; 1];

x1 = Cs \ d1
x2 = Cn \ d1
x3 = Cs \ d2
x4 = Cn \ d2

% As Cs matrix is singular, unique solution doesnt exist. Symbolic
% solutions are exact solutions and gives more information about the
% solution. On the other hand, approximation may contain error and
% comparitively smaller information about the solution.
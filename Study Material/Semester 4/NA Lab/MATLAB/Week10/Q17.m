format long
format compact
A = hilb (10);
[Eqr , steps ] = myqrmethod (A)
Eml = eig (A)
diff = norm (Eml - flipud (Eqr ));

% There is just an inversion of eigenvalues according to the way we've written our code
% for n = 50 and 200, it takes so much time to complete the calculation
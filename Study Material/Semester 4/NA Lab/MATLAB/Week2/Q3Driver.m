D = 0.825;
V1 = Q3(D + 0.002);
V2 = Q3(D - 0.002);

ActualError = V1 - V2
AbsoluteError = (1/2).*(10.^-3);
RelativeError1 = ActualError/V1
RelativeError2 = ActualError/V2
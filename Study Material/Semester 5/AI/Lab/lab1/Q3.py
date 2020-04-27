D = {'2016-CS-700': [('DSA', 3), ('Algo', 2.5), ('AI', 3)], '2016-CS-701': [('DSA',3.2),('Algo',3.5),('PF',2.8)], '2016-CS-710': [('DSA',2.5),('DB',3.5),('PF',2.8)]}

highest = 1
for Roll in D:
    if D[Roll][0][1] > highest:
        highest = D[Roll][0][1]
print(highest)

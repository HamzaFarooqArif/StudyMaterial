D = {'2016-CS-700': [('DSA', 3), ('Algo', 2.5), ('AI', 3)], '2016-CS-701': [('LA',3),('Algo',3.5),('PF',2.8)], '2016-CS-710': [('OOP',3),('DB',3.5),('PF',2.8)]}
idx = 0
for Roll in D:
    print(Roll)
    for subj in D[Roll]:
        print(subj)

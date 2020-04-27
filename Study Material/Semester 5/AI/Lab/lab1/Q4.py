D = {'2016-CS-700': [('DSA', 3), ('Algo', 2.5), ('AI', 3)], '2016-CS-701': [('LA',3),('Algo',3.5),('AI',2.0)], '2016-CS-710': [('OOP',3),('DB',3.5),('AI',2.9)]}

total = 0
lowest = 2.5
for Roll in D:
    if D[Roll][2][1] < lowest:
        total += 1
print(total)

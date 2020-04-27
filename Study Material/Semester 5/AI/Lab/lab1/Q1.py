inputList = ['ABCDEF', 'GHIJKL', 'MNO']
print(list(filter(lambda x: len(x) > 5, (list(map(lambda y: y.lower(), inputList))))))

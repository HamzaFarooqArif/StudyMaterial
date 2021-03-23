import csv
import math
import time

# ================Assignment 01================
def cleanPoint(point):
    x, y = point.split(', ')
    x = int(x)
    y = int(y)
    return (x, y)

def computeLoss(theta0, theta1, point):
    y_hat = theta0 + theta1*point[0]
    loss = pow((y_hat - point[1]), 2)
    return loss

def computeCost(theta0, theta1, pointList):
    cost = 0
    for point in pointList:
        cost += computeLoss(theta0, theta1, point)
    return cost
# =============================================

# ================Assignment 02================
def getBestModel(modelList, pointList):
    result = {}
    for model in modelList:
        cost = computeCost(model[0], model[1], pointList)
        result[cost] = model
    minCost = min(result.keys())
    return result[minCost]
# =============================================

# ================Assignment 03================
def predictParams(paramRange, pointList):
    models = []
    for theta0 in range(paramRange[0] + 1):
        for theta1 in range(paramRange[1] + 1):
            models.append((theta0, theta1))
    print(len(models))
    bestModel = getBestModel(models, pointList)
    return bestModel
# =============================================



if __name__ == '__main__':
    pointList = []
    
    with open('input.csv', 'r', newline='\n', encoding = 'utf-8-sig') as csvfile:
        spamreader = csv.reader(csvfile, delimiter='\n')
        for row in spamreader:
            pointList.append(cleanPoint(row[0]))
    
    start_time = time.time()
    
    bestModel = predictParams((9999, 9999), pointList)

    print(round((time.time() - start_time), 4))

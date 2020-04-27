import numpy as np
import matplotlib.pyplot as bilal
import cv2
#matplotlib inline
image = cv2.imread('cup.jpg')
#converting image to Gray scale
gray_image = cv2.cvtColor(image,cv2.COLOR_BGR2GRAY)
#plotting the grayscale image
bilal.imshow(gray_image)
bilal.show()
#converting image to HSV format
hsv_image = cv2.cvtColor(image,cv2.COLOR_BGR2HSV)
#plotting the HSV image
#cv2.imshow('k',hsv_image)
#cv2.waitKey(0)
bilal.imshow(hsv_image)
bilal.show()

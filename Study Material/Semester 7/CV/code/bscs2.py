import numpy as np
import matplotlib.pyplot as plt
import cv2
#matplotlib inline

#reading the image

image = cv2.imread('cup.jpg')
#image = cv2.cvtColor(image,cv2.COLOR_BGR2RGB)
#plotting the image
plt.imshow(image)
plt.show()

#saving image
cv2.imwrite('test_write.jpg',image)


from pyimagesearch.transform import four_point_transform
from imutils.video import VideoStream
import numpy as np 
import cv2

def draw_circle(event,x,y,flags,param):
    global ptsIdx
    if event == cv2.EVENT_LBUTTONDBLCLK and ptsIdx < 4:
        pts[ptsIdx] = x,y
        ptsIdx += 1

vs = VideoStream(src=0).start()
pts = np.zeros((4, 2), dtype = "float32")
ptsIdx = 0

cv2.namedWindow('Original')
cv2.setMouseCallback('Original',draw_circle)

while(1):
    frame = vs.read()
    for i in range(ptsIdx):
        cv2.circle(frame,(pts[i][0],pts[i][1]),5,(255,0,0),-1)
    cv2.imshow('Original',frame)
    if ptsIdx == 4:
        warped = four_point_transform(frame, pts)
        cv2.imshow("Warped", warped)

    key = cv2.waitKey(1) & 0xFF
    if key == ord("q"):
        break
vs.stop()
cv2.destroyAllWindows()


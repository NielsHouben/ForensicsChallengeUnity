import cv2
from cvzone.PoseModule import PoseDetector

# cap = cv2.VideoCapture('./videos/Video.mp4')
# cap = cv2.VideoCapture('./videos/VID_20230210_140621_524.mp4')
cap = cv2.VideoCapture('./videos/person2.mp4')

detector = PoseDetector()
posList = []
while True:
    try:
        success, img = cap.read()
        img = detector.findPose(img)
        lmList, bboxInfo = detector.findPosition(img)


        if bboxInfo:
            lmString = ''
            for lm in lmList:
                lmString += f'{lm[1]},{img.shape[0] - lm[2]},{lm[3]},'
            posList.append(lmString)
        else:
            posList.append("")

        print(len(posList))

        cv2.imshow("Image", img)
        key = cv2.waitKey(1)
        # if key == ord('s'):
        #     with open("AnimationFileCrimePerson1.txt", 'w') as f:
        #         f.writelines(["%s\n" % item for item in posList])
    except:
        print("done")
        with open("AnimationFileCrimePerson2.txt", 'w') as f:
            f.writelines(["%s\n" % item for item in posList])
        exit()
.MODEL SMALL
.data
   

.code

mov AX, @data
mov DS, AX

mov CX, 9
mov ah, 2
mov bl, 0


START:
add bl, 1
mov dl, bl
add dl, 30h
int 21h

LOOP START

ret





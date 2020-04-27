.MODEL SMALL
.data
    STR1 DB 10, 13, 'Enter Number: $'
    STR2 DB 10, 13, 'Value is Even$'
    STR3 DB 10, 13, 'Value is Odd$'
    STR4 DB 10, 13, 'Do you want to run again (Y/N)?$'

.code


mov ax, @data
mov DS, AX

START:
LEA DX, STR1
mov ah, 9
int 21h

mov ah,1
INT 21h
mov bl, 2
div bl

mov dl, ah
CMP dl, 0
JNE ODD

EVEN:
LEA DX, STR2
mov ah, 9
int 21h
JMP LAST

ODD:
LEA DX, STR3
mov ah, 9
int 21h
JMP LAST

LAST:
LEA DX, STR4
mov ah, 9
int 21h

mov ah,1
INT 21h
CMP al, 079h
JE START
CMP al, 079h
JE EXIT

EXIT:
.exit











ret





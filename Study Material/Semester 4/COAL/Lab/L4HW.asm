.MODEL SMALL
.data
    STR1 DB 10, 13, 'Enter a Character: $'
    STR2 DB 10, 13, 'Do You Want To Run Again? (type Y) $' 
    
.code
mov AX, @data
mov DS, AX

START:
LEA DX, STR1
mov ah, 9
INT 21h
    
mov ah, 1
INT 21h
mov bl, al

CMP bl, 96
JLE UPPERTOLOWER

LOWERTOUPPER:
sub bl, 20h
JMP OUTPUT

UPPERTOLOWER:
add bl, 20h


OUTPUT:
mov ah, 2
mov dl, 0Ah
INT 21h
mov dl, 0Dh
INT 21h 
mov dl, bl
INT 21h

LAST:
LEA DX, STR2
mov ah, 9
int 21h

mov ah,1
INT 21h
CMP al, 079h
JE START



.exit
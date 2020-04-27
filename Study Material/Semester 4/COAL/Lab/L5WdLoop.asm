.MODEL SMALL
.data
    STR1 DB 10, 13, 'Enter 1st Number$'
    STR2 DB 10, 13, 'Enter 2nd Number$'
    STR3 DB 10, 13, 'Enter 3rd Number$'
    STR4 DB 10, 13, 'Do you want to run again?(type y)$'
    n1 db ?
    n2 db ?
    n3 db ?
    
.code

OPENING:

mov AX, @data
mov DS, AX
jmp BEFORE_SORTING

BEFORE_SORTING:
LEA DX, STR1
mov ah, 9
int 21h
mov ah, 1
int 21h
mov n1, al

LEA DX, STR2
mov ah, 9
int 21h
mov ah, 1
int 21h
mov n2, al

LEA DX, STR3
mov ah, 9
int 21h
mov ah, 1
int 21h
mov n3, al

START:
mov bl, n1
CMP bl, n2
JL REPLACEN1N2

mov bl, n2
CMP bl, n3
JL REPLACEN2N3

mov bl, n1
CMP bl, n3
JL REPLACEN1N3

JMP OUTPUT


REPLACEN1N2:
mov bl, n1
mov bh, n2

mov dh, bl
mov bl, bh
mov bh, dh 

mov n1, bl
mov n2, bh

JMP START

REPLACEN2N3:
mov bl, n2
mov bh, n3

mov dh, bl
mov bl, bh
mov bh, dh

mov n2, bl
mov n3, bh

JMP START 


REPLACEN1N3:
mov bl, n1
mov bh, n3

mov dh, bl
mov bl, bh
mov bh, dh

mov n1, bl
mov n3, bh

JMP START
 


OUTPUT:
mov ah, 2
mov dl, 0Ah
int 21h
mov dl, 0Dh
int 21h
mov dl, n3
int 21h
mov dl, n2
int 21h
mov dl, n1
int 21h

LEA DX, STR4
mov ah, 9
int 21h
mov ah, 1
int 21h
CMP al, 079h
JNE exit
JMP OPENING

exit:
.exit    
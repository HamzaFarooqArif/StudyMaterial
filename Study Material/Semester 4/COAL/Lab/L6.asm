.MODEL SMALL
.data
    STR1 DB 'AEIOUAEIOUAEIODJAGFVBFXCMUABCDEF $'
    vov_count db 0
    count db 0
.code
mov ax, @data
mov ds, ax

LEA bx, STR1

Start:
mov al, [bx]

Compare:
cmp al, 'A'
je disp
cmp al, 'E'
je disp
cmp al, 'I'
je disp
cmp al, 'O'
je disp
cmp al, 'U'
je disp
cmp al, '$'
je Exit
inc bx
jmp Start



disp:
mov cl, al

mov ah, 2
mov dl, 0Ah
INT 21h
mov dl, 0Dh
INT 21h

mov dl, cl
mov ah, 2
int 21h
inc bx
inc vov_count
jmp Start

Exit:  
mov ax, 0
mov al, vov_count 
mov bl, 10
div bl

mov bh, ah
mov bl, al

mov ah, 2
mov dl, 0Ah
INT 21h
mov dl, 0Dh
INT 21h

mov dl,bl
add dl, 30h
mov ah, 2
int 21h


mov dl,bh
add dl, 30h
mov ah, 2
int 21h

.exit

ret
              

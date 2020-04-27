.MODEL SMALL
.data
    STR1 DB 10, 13, 'Enter Number: $'
    first DB ?
    count DB 0
.code

mov ax, @data
mov DS, AX

LEA DX, STR1
mov ah, 9
INT 21h












; Get first input character from the terminal window
mov ah,1
INT 21h
mov bl, al
sub bl, 30h

START:

; Place the cursor at the start of newline
mov ah, 2
mov dl, 0Ah
INT 21h
mov dl, 0Dh
INT 21h


; Get second input character from the terminal window 
mov first, bl
add count, 1
mov bh, count

mov al, 0
mov ah, 0

mov al, bh
mul bl

mov bl, al


add bl, 30h

; Place cursor at newline
mov ah, 2
mov dl, 0Ah
INT 21h

; Copy Output value from 'bl' to 'dl'
mov dl, bl


sub bl, 30h ; Convert Printable form into value
mov ah, 00h ; Reset / Refresh 'ah' register
mov al, 00h ; Reset / Refresh 'al' register
mov al, bl  ; Copy Output value into 'al'
mov bl, 10  ; Copy divisor in 'bl'
div bl      ; Divide 'al' by 'bl'
; Quotient is in 'ah' and Remainder in 'al'
mov bl, al  ; Copy Remainder into 'bl'
mov bh, ah  ; Copy Quotient into 'bh' 
mov ah, 2   ; DOS interrupt for Output
add bl, 30h ; Value to Printable form conversion
mov dl, bl  ; Copy first digit to print
INT 21h     ; Call Interrupt handler
add bh, 30h ; Value to Printable form conversion
mov dl, bh  ; Copy second digit to print
INT 21h     ; Call Interrupt handler

mov bl, first

CMP count, 9
JNE START
.exit

.MODEL SMALL
.data
    STR1 DB 10, 13, 'Enter a two digit number: $'
    STR2 DB 10, 13, 'Choose operation to be performed: (enter / * + -) $'
    STR3 DB 10, 13, 'Do you want to run again? (y/n) $'
    firstDigit DB ?
    secondDigit DB ?
    
    firstNumber DB ?
    secondNumber DB ?
    
    result DB ?
    resultDigit1 DB ?
    resultDigit2 DB ?
    resultDigit3 DB ?
    
    mulResult DW ?
    resultDigit4 DB ?

.code

mov ax, @data
mov DS, ax

Start:     
; Get first input character from the terminal window
LEA DX, STR1
mov ah, 9
INT 21h

mov ah,1
INT 21h
mov bl, al
sub bl, 30h

mov firstDigit, bl

; Get second input character from the terminal window
mov ah,1
INT 21h
mov bl, al
sub bl, 30h

mov secondDigit, bl

; Make one number from two numbers
mov ah, 0
mov al, firstDigit
mov bl, 10
mul bl

add al, secondDigit
mov firstNumber, al

; Get first input character from the terminal window
LEA DX, STR1
mov ah, 9
INT 21h

mov ah,1
INT 21h
mov bl, al
sub bl, 30h

mov firstDigit, bl

; Get second input character from the terminal window

mov ah,1
INT 21h
mov bl, al
sub bl, 30h

mov secondDigit, bl

; Make one number from two numbers
mov ah, 0
mov al, firstDigit
mov bl, 10
mul bl

add al, secondDigit
mov secondNumber, al

LEA DX, STR2
mov ah, 9
INT 21h

mov ah,1
INT 21h
mov bl, al
CMP bl, 43
JE Addition
CMP bl, 42
JE Multiplication
CMP bl, 45
JE Subtraction
CMP bl, 47
JE Division
JMP Exit


Addition:
mov ah, firstNumber
add ah, secondNumber
mov result, ah
JMP DisplayResult

Subtraction:
mov ah, firstNumber
sub ah, secondNumber
mov result, ah
JMP DisplayResult

Multiplication:    
mov ax, 0h
mov bx, 0h
mov al, firstNumber
mov bl, secondNumber
mul bx
mov mulResult, ax
JMP DisplayMulResult

Division:
mov ah, 00h
mov al, firstNumber
mov bl, secondNumber
div bl
mov result, al
JMP DisplayResult

DisplayResult:
; Display first digit
mov bl, result
mov ah, 00h ; Reset / Refresh 'ah' register
mov al, 00h ; Reset / Refresh 'al' register
mov al, bl  ; Copy Output value into 'al'
mov bl, 10  ; Copy divisor in 'bl'
div bl      ; Divide 'al' by 'bl'

mov bl, al
mov bh, ah
mov result, al

mov ah, 2
mov dl, 0Ah
INT 21h
mov ah, 2
mov dl, 0Dh
INT 21h

mov resultDigit1, bh

; Display second digit
mov bl, result
mov ah, 00h ; Reset / Refresh 'ah' register
mov al, 00h ; Reset / Refresh 'al' register
mov al, bl  ; Copy Output value into 'al'
mov bl, 10  ; Copy divisor in 'bl'
div bl      ; Divide 'al' by 'bl'

mov bl, al
mov bh, ah
mov result, al

mov resultDigit2, bh

; Display third digit
mov bl, result
mov ah, 00h ; Reset / Refresh 'ah' register
mov al, 00h ; Reset / Refresh 'al' register
mov al, bl  ; Copy Output value into 'al'
mov bl, 10  ; Copy divisor in 'bl'
div bl      ; Divide 'al' by 'bl'

mov bl, al
mov bh, ah
mov result, al

mov resultDigit3, bh

mov ah, 2
mov dl, resultDigit3
add dl, 30h
INT 21h
mov ah, 2
mov dl, resultDigit2
add dl, 30h
INT 21h
mov ah, 2
mov dl, resultDigit1
add dl, 30h
INT 21h

LEA DX, STR3
mov ah, 9
INT 21h
mov ah, 1
INT 21h
mov bl, al
CMP bl, 121
JE Start

DisplayMulResult:
mov ax, 0h
mov bx, 0h
mov cx, 0h
mov dx, 0h

mov ax, mulResult
mov bx, 1000
div bx
mov mulResult, dx

mov bl, al
mov ah, 2
mov dl, bl
add dl, 30h
INT 21h

mov ax, 0h
mov bx, 0h
mov cx, 0h
mov dx, 0h

mov ax, mulResult
mov bx, 100
div bx
mov mulResult, dx

mov bl, al
mov ah, 2
mov dl, bl
add dl, 30h
INT 21h

mov ax, 0h
mov bx, 0h
mov cx, 0h
mov dx, 0h

mov ax, mulResult
mov bx, 10
div bx
mov mulResult, dx

mov bl, al
mov ah, 2
mov dl, bl
add dl, 30h
INT 21h

mov ax, 0h
mov bx, 0h
mov cx, 0h
mov dx, 0h

mov ax, mulResult
mov bx, 1
div bx
mov mulResult, dx

mov bl, al
mov ah, 2
mov dl, bl
add dl, 30h
INT 21h

 
Exit:
.exit
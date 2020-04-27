;Machine code starts from address (offset) 100h in this segment
org 100h
;DOS Interrupt for input a character.
mov ah,1
; Call interrupt handler
INT 21h
; Copy the content from 'al' to 'bl'
mov bl, al
; Subtract 30hex from 'bl' 
; to convert the internal value to pritable character
sub bl, 30h

; DOS Interrupt for output a character.
mov ah, 2
; Copy newline character into 'dl' register.
mov dl, 0Ah
INT 21h
; Copy carriage return ('\r') character into 'dl' register.
; to place cursor at the start of line
mov dl, 0Dh
INT 21h

; Input 2nd character
mov ah, 1
INT 21h
mov bh, al
sub bh, 30h

; Perform 'Addition' arithmetic operation
add bl, bh
; Translate into printable value
add bl, 30h

; Newline
mov ah, 2
mov dl, 0Ah
INT 21h

; Display the sum
mov ah, 2
mov dl, bl
INT 21h

; Return control to system
ret





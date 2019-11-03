org 100h

segment .text

;---------------------------------------------------------------------------------
; insert code here	
main:
	mov dx, s
	mov ah, 9
	int 21h
	
	mov ah, 10h
	int 16h
	
	call quit
	
quit:
	mov	AX, 4C00H
	int	21h
	ret
	
;---------------------------------------------------------------------------------
; insert variables here	
segment .data
	s: db "Enter digit (0..9) for show time, Esc - for exit:", 13, 10, '$'

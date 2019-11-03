org 100h

segment .text

;---------------------------------------------------------------------------------
; insert code here	
main:
	call quit
	
quit:
	mov	AX, 4C00H
	int	21h
	ret
	
;---------------------------------------------------------------------------------
; insert variables here	
segment .data

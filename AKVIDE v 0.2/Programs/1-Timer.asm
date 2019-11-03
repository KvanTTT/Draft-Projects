org 100h

segment .txt

main:
	mov dx, str
	mov ah, 9
	int 21h
	
	mov ah, 10h
	int 16h

	cmp al, 27
	je quit
	
	cmp al, 48
	jb main
	cmp al, 57
	ja main
	
	call show_real_time
	jmp main
	
	
show_real_time:
	mov ah, 02h
	int 1ah

	mov al, ch      ;hour 
	call print_digit
	
	mov al, ':'
	int 29h			
	
	mov al, cl       ;min
	call print_digit
	
	mov al, ':'
	int 29h	
	
	mov al, dh       ;sec
	call print_digit
	
	mov dx, next_str
	mov ah, 9
	int 21h
	
	ret
	
	
print_digit:
	mov ah, al
	shr al, 4
	add al, 30h
	int 29h
	
	mov al, ah
	and al, 0fh
	add al, 30h
	int 29h	
	
	ret

quit:
	mov	AX, 4C00H
	int	21h
	
segment .data
	str: db "Enter digit (0..9) for show time, Esc - for exit:", 13, 10, '$'
	next_str: db 13, 10, '$'
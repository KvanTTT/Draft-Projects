org 100h

segment .txt

main:
	mov dx, str_input
	call str_print
	
	mov ah, 10h
	int 16h

	cmp al, 27
	jne main_l3
	call quit
	
	main_l3:
	cmp al, 48
	jb main_exit
	cmp al, 56
	ja main_exit
	
	mov cx, ax
	
	mov ah, 0
	sub al, 30h
	
	push ax
	
	mov ah, 02h
	mov dl, ' '
	int 21h		
	
	mov dl, cl
	int 21h
	
	mov dx, str_next
	call str_print	
	
	mov dx, str_output
	call str_print
	
	pop ax
	
	cmp ax, 0
	je main_l1
		mov bx, ax
		call factorial     ; в ax - результат
		jmp main_l2
	main_l1:
		mov ax, 1
	main_l2:
	
	call print_int
	
	main_exit:
	mov dx, str_next
	call str_print
	
	jmp main
	
factorial:
	; в ax - результат
	; в bx - текущая цифра
	
	cmp bx, 1
	je f_exit 
		dec bx
		mul bx
		call factorial
	f_exit:
		
	ret
	
print_int:
	mov si, ax
	mov cx, 4
	puh_loop1:
		rol si, 4
		mov ax, si
		and ax, 000fh
		mov bx, table
		xlat
		mov dl, al
		mov ah, 02h
		int 21h		
	loop puh_loop1	

	ret	
	
table db "0123456789ABCDEF"
	
get_next_symb:
	mov ah, 01h
	int 21h
	ret

str_print:
	mov ah, 9
	int 21h
	ret
		
quit:
	mov	ax, 4C00H
	int	21h
	ret

	
segment .data
	str_input db "Enter number (0..8):", '$'
	str_output db "Factorial = ", '$'
	str_next db 13, 10, '$'
	n dw 0;

	

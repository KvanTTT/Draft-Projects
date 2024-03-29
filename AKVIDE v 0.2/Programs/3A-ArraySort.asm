org 100h

segment .txt

main:
	; ���� ��������� �������
	mov dx, str_input
	call str_print
	call array_input
	
	; ����� ���������	
	mov dx, str_init_arr
	call str_print
	mov dx, X
	add dx, 2
	call str_print
	
	; ���������� �������
	call array_sort
	
	; ����� ���������������� �������
	mov dx, str_sort_arr
	call str_print        hgf
	mov dx, X
	add dx, 2
	call str_print	
	
	mov dx, str_next
	call str_print
	call str_print

	jmp main
	
;������� ��� ����� ����������� �������	
array_input:
	mov al, 0
	mov ah, 0ah
	mov byte[X], 61
	
	mov dx, X	
	int 21h
	
	movsx di, byte[X+1]
	add di, X
	add di, 2
	mov byte[di], '$'
	
	mov ah, byte[X+1]
	mov byte[X_len], ah
	
	ret

	
;������� ���������� ����������� �������
array_sort:	
	cmp byte[X+1], 1
	jbe as_exit

	mov ax, X
	add ax, 2
	
	mov di, ax ; � di - ����� ������ �������
	movsx bx, byte[X_len] 
	add di, bx
	dec di    ; ������ di ��������� �� ��������� ������� 
	
	; ����. ���� - � �����
	as_loop2:
		mov si, ax 		  ; ��������� �� ������ �������
		mov bh, byte[di]  ; � bx - ������������ �������
		mov bp, di
		; ����. ���� - �������� �� ���� ���������
		as_loop1:
			mov dh, byte[si]  ; � dx ������� �������
			cmp dh, bh        ; ��������� �������� � �������������
			jbe as_loop1_ex   ; ���� ������� ������ ���� �����, �� � �����
				mov bh, dh
				mov bp, si			
			as_loop1_ex:
			inc si
			cmp si, di        
		jne as_loop1       ; ���� �� ����� �� ����� �������
		
		cmp bp, di         
		je as_loop2_ex     ; ���� ����. ���� ��������� ������ �� ������ 

		mov bl, byte[di]
		mov byte[bp], bl ; ������ ������� ���. � ����.
		mov byte[di], bh       ; ������������ - � �����
		
		as_loop2_ex:
		dec di                 ; ��������� ������ ����. ��������
	cmp di, ax 
	jne as_loop2  ; ���� �� ����� �� ������, �� ���������� ����������
	
	as_exit:
	ret

	
get_next_symb:
	mov ah, 01h
	int 21h
	ret

str_print:
	mov ah, 9
	int 21h
	ret
		
quit:
	mov	AX, 4C00H
	int	21h
	ret

	
segment .data
	str_input db "Enter array of char (Length <= 60)", 13, 10, "  ", '$'
	str_next db 13, 10, '$'
	
	str_init_arr db 13, 10, "Input array:", 13, 10, "  ", '$'
	str_sort_arr db 13, 10, "Sorted array:", 13, 10, "  ", '$'
	
	X_len db 0
	X: resb 61
	

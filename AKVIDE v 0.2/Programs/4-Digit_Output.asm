org 100h

segment .txt

main:
	mov dx, input
	mov ah, 9
	int 21h
	
	mov ah, 10h
	int 16h

	mov byte[key], al
	cmp byte[key], 27
	jne l0;
	call quit
	
	l0:
		cmp byte[key], 48
		jb main
		cmp byte[key], 56
		ja main
		
		cmp byte[key], 48
		jne l1;
		call [table]
		jmp main;
	
	l1:
		cmp byte[key], 49
		jne l2
		call [table + 2]
		
		mov dx, next_str
		call print_str
		
		pop ax
		mov byte[er], al
		cmp al, 0
		jne main            
		call cnv_ar_to_number
		jmp main
	
	l2:
		cmp byte[key], 50
		jne l3
		cmp byte[er], 0
		je l21
		push m_er              ; ���� ����� �� ������� ��� ������
		ret
		
		l21:
		mov dx, act2
		call print_str
		push word[X]
		call [table + 4]
		mov dx, d_next_str
		call print_str
		jmp main
		
	l3:
		cmp byte[key], 51
		jne l4
		cmp byte[er], 0
		je l31
		push m_er              ; ���� ����� �� ������� ��� ������
		ret
		
		l31:
		mov dx, act3
		call print_str
		push word[X]
		call [table + 6]
		mov dx, d_next_str
		call print_str
		jmp main
	
	l4:
		cmp byte[key], 52
		jne l5
		cmp byte[er], 0
		je l41
		push m_er              ; ���� ����� �� ������� ��� ������
		ret
		
		l41:
		mov dx, act4
		call print_str
		push word[X]
		call [table + 8]
		mov dx, d_next_str
		call print_str
		jmp main
		
	l5:
		cmp byte[key], 53
		jne l6
		cmp byte[er], 0
		jne m_er              ; ���� ����� �� ������� ��� ������
		
		mov dx, act5
		call print_str
		push word[X]
		call [table + 10]
		mov dx, d_next_str
		call print_str
		jmp main
		
	l6:
		cmp byte[key], 54
		jne l7
		cmp byte[er], 0
		jne m_er              ; ���� ����� �� ������� ��� ������
		
		mov dx, act6
		call print_str
		push word[X]
		call [table + 12]
		mov dx, d_next_str
		call print_str
		jmp main
		
	l7:
		cmp byte[key], 55
		jne l8
		cmp byte[er], 0
		jne m_er              ; ���� ����� �� ������� ��� ������
		
		mov dx, act7
		call print_str
		push word[X]
		call [table + 14]
		mov dx, d_next_str
		call print_str
		jmp main
		
	l8:
		call [table + 16]
		
	m_er:
		mov dx, correct_number
		call print_str
		jmp main

;---------------------------------------------------------------------------------	
; 0 - Display menu:
print_menu:
	mov ah, 9
	
	mov dx, act0
	int 21h
	mov dx, act1
	int 21h
	mov dx, act2
	int 21h
	mov dx, act3
	int 21h
	mov dx, act4
	int 21h
	mov dx, act5
	int 21h
	mov dx, act6
	int 21h
	mov dx, act7
	int 21h
	mov dx, act8
	int 21h
	
	ret
	
;---------------------------------------------------------------------------------	
; 1 - Integer input to word X:
int_input:
	pop bx
	mov dx, act1
	mov ah, 9
	int 21h
	
	xor bp, bp ; 0 - ���� ����������, 1 - ������������
	mov si, value
	inc si
	xor cl, cl
state_a: 
	call get_next_symb
	cmp al, '+' 
	je state_b 
	cmp al, '-' 
	je state_b 
	call is_digit 
	jnz err_int_input 
	mov byte [si], '+'
	inc si
	inc cl
	jmp state_c
		
state_b: 
	mov byte [si], al
	inc si;
	inc cl;
	cmp cl, 6
	je end_int_input
	call get_next_symb
	call is_digit
	jz state_c		
	jmp err_int_input
			
state_c: 
	mov byte [si], al
	inc si
	inc cl
	cmp cl, 6
	je end_int_input
	call get_next_symb
	call is_digit
	jz state_c
	cmp al, 13
	jne err_int_input
	jmp end_int_input
	
err_int_input:
	mov dx, next_str
	call print_str
	mov dx, uncorrect_digit
	call print_str
	mov bp, 1
	mov byte[value], 0
	jmp end_int_input2
	
end_int_input:
	mov byte[si], '$'
	mov byte[value], cl
	call cmp_min_max
	jz end_int_input2
	mov dx, next_str
	call print_str
	mov dx, big_int
	call print_str
	mov bp, 1
	mov byte[value], 0
	
end_int_input2:
	mov dx, next_str
	call print_str	
	push bp
	push bx
	ret
	
;---------------------------------------------------------------------------------

cmp_min_max:
	mov si, value
	xor al, al
	mov ah, byte[si]
	
cmm_next:
	cmp byte[si], 6
	jb cmm_set ; ���� ����������� ����� ������, �� �������

;-- ���� ����� - ������ ������
	inc si
	cmp byte [si], '-'
	je cmm_minus
	
	inc si
	cmp byte [si], '6'
	ja cmm_end
	jb cmm_set
	inc si
	cmp byte [si], '5'
	ja cmm_end
	jb cmm_set
	inc si
	cmp byte [si], '5'
	ja cmm_end
	jb cmm_set
	inc si
	cmp byte [si], '3'
	ja cmm_end
	jb cmm_set
	inc si
	cmp byte [si], '5'
	ja cmm_end
	jmp cmm_set
	
cmm_minus:
	inc si
	cmp byte [si], '3'
	ja cmm_end
	jb cmm_set
	inc si
	cmp byte [si], '2'
	ja cmm_end
	jb cmm_set
	inc si
	cmp byte [si], '7'
	ja cmm_end
	jb cmm_set
	inc si
	cmp byte [si], '6'
	ja cmm_end
	jb cmm_set
	inc si
	cmp byte [si], '8'
	ja cmm_end
	
cmm_set:
	test ax, 0 ; ������������� ���� ����, ���� �����	
	
cmm_end:		
	ret
	
;---------------------------------------------------------------------------------
get_next_symb:
	mov ah, 01h
	int 21h
	ret
	
;---------------------------------------------------------------------------------
is_digit:
	cmp al, '0'
	jb id1
	cmp al, '9'
	ja id1
	test ax, 0
id1:
	ret	

;---------------------------------------------------------------------------------
cnv_ar_to_number:
	mov word[X], 0 ; ����� ����� ��������� ���� �����
	
	; ��������������
	mov si, value
	mov ax, 0
	mov al, byte[value] 
	add si, ax ; ������ si ��������� �� ��������� �������
	mov ax, 1           ; 1, 10, 100, ...
	mov cx, 10          ; �� ��� ������ ����� ���������� ax
	mov di, 0           ; ������� ��������
	mov dx, 0
	mov bh, 0
	catn_loop1:
		push ax        ; ���������� ax - ����� �����������  
		mov bl, byte[si]  ; ������� ������ �����
		sub bl, 30h       ; ������ -> �����
		cmp di, 3
		jae catn_l20
			mul bl            ; ax = ax*10
			jmp catn_l30
		catn_l20:
			push dx
			mul bx
			pop dx
		catn_l30:
		add dx, ax        ; ��������� � ����� ���������� ���������
		pop ax   		  ; ��������������� ax
		inc di
		cmp di, 3
		jae catn_l2
			mul cl            ; ax = ax*10
			jmp catn_l3
		catn_l2:
			push dx
			mul cx
			pop dx
		catn_l3:
		dec si	          ; ��������� � ���������� �������
	cmp si, value+1
	jne catn_loop1
	
	; � ah - ������� ����
	mov al, 0
	cmp byte[value+1], '+'
	je catn_l1
	neg dx
	catn_l1:
	
	mov word[X], dx
	
	ret
	
;---------------------------------------------------------------------------------
; 2 - Output from X such binary unsigned integer:	
print_usbinary:
	; ����� ����� � �������� ������� ���������
	; c ������� ���������� ������ �����
	; � �������������� ����� �������� (CF)
	pop di
	pop bx	
		
	mov ah, 02h
	cmp bx, 0       ; ���� ����� ����� 0
	jne pusb_l2
	mov dl, 30h
	int 21h
	jmp pusb_exit
	
	pusb_l2:
	mov si, 0            ; ���� ����, ��� ��� ����������� �������
	mov cx, 16
	pb_loop1:
		shl bx, 1
		jc pb_id
			cmp si, 0
			je pb_loop1_cont
			mov dl, 30h
			jmp pb_ex
		pb_id:
			mov dl, 31h
			mov si, 1
		pb_ex:
		int 21h
		pb_loop1_cont:
	loop pb_loop1	
	
	pusb_exit:
	push di
	ret

;---------------------------------------------------------------------------------	
; 3 - Output from X such binary signed integer:
print_sbinary:
	pop cx
	; ��������� �� ����� �������� X
	pop bx
	
	; ������� ������� ����
	mov ah, 02h
	test bh, 128
	jnz psb_l1
		mov dl, '+'	     
		jmp psb_l2
	psb_l1:
		mov dl, '-'	     
	psb_l2:
	int 21h

	push cx
	
	; ����������� �����
	neg bx
	push bx	
	
	; �������� ��������� ������
	call [table + 4]	
	pop cx
	
	push cx
	ret
	
;---------------------------------------------------------------------------------
; 4 - Output from X such decimal unsigned integer: 	
print_usdec:
	pop di
	pop dx	
	
	cmp dx, 0       
	jne pusd_l0
	mov ah, 02h
	mov dl, 30h           ; ���� ����� ����� 0
	int 21h
	jmp pusd_exit
	
	; ����� �����
	pusd_l0:
	push di
	mov si, 0
	mov ax, dx
	mov bx, 10000              
	mov di, 10            ; �� ��� ������ ����� �������� ax  
	pusd_loop1:
		mov dx, 0
		div bx            ; ������� � ax
		
		mov cx, dx        ; ���������� dx - ��� �������
		cmp al, 0         ; � al - ��, ��� ����� �������
		jne pusd_l12
		cmp si, 0
		je  pusd_l13
		pusd_l12:
			mov dl, al        
			add dl, 30h       ; ����� -> ������
			mov ah, 02h
			mov si, 1
			int 21h
		
		pusd_l13:			             
		mov dx, 0
		mov ax, bx
		div di
		mov bx, ax
		
		mov ax, cx         ; ���������������� ax
	cmp bx, 0
	jne pusd_loop1
	pop di
		
	pusd_exit:
	push di
	ret
	
;---------------------------------------------------------------------------------
; 5 - Output from X such decimal signed integer:
print_sdec:
	pop cx
	; ��������� �� ����� �������� X
	pop bx
	
	; ������� ������� ����
	mov ah, 02h
	test bh, 128
	jnz psd_l1
		mov dl, '+'	     
		jmp psd_l2
	psd_l1:
		mov dl, '-'	     
	psd_l2:
	int 21h
	
	push cx
	
	; ����������� �����
	neg bx
	push bx	
	
	; �������� ��������� ������
	call [table + 8]	
	pop cx
	
	push cx
	ret
	
;---------------------------------------------------------------------------------
; 6 - Output from X such hexadecimal unsigned integer: 
print_ushex:
	pop di
	pop bx
	mov ah, 02h
	mov si, 0      ; ���� ����, ��� ��� ����������� �������
	
	cmp bx, 0       ; ���� ����� ����� 0
	jne puh_l0
	mov dl, 30h
	int 21h
	jmp puh_exit
	
	puh_l0:
	mov cx, 4
	puh_loop1:
		rol bx, 4
		mov dl, bl
		and dl, 000fh
		cmp dl, 9
		ja puh_l1
			add dl, 30h
			jmp puh_l11
		puh_l1:
			add dl, 37h
		puh_l11:
		cmp dl, 30h
		jne puh_l12
		cmp si, 0
		je  puh_l13
		puh_l12:
		mov si, 1
		int 21h
		puh_l13:
	loop puh_loop1
	
	puh_exit:
	push di
	ret	
	

;---------------------------------------------------------------------------------
; 7 - Output from X such hexadecimal signed integer: 
print_shex:
	pop cx
	; ��������� �� ����� �������� X
	pop bx
	
	; ������� ������� ����
	mov ah, 02h
	test bh, 128
	jnz psh_l1
		mov dl, '+'	     
		jmp psh_l2
	psh_l1:
		mov dl, '-'	     
	psh_l2:
	int 21h
	
	push cx
	
	; ����������� �����
	neg bx
	push bx	
	
	; �������� ��������� ������
	call [table + 12]	
	pop cx
	
	push cx
	ret	
	
;---------------------------------------------------------------------------------	
print_str:
	mov ah, 9
	int 21h
	ret
	
;---------------------------------------------------------------------------------				
quit:
	mov	ax, 4C00H
	int	21h
	ret
	
;---------------------------------------------------------------------------------
	
segment .data
	input db "Enter Number of Action (0..8): ", 13, 10, '$'
	act0 db "0 - Display menu", 13, 10, '$'
	act1 db "1 - Integer input to word X: ", 13, 10, '$'
	act2 db "2 - Output from X such binary unsigned integer: ", 13, 10, '$'
	act3 db "3 - Output from X such binary signed integer: ", 13, 10, '$'
	act4 db "4 - Output from X such decimal unsigned integer: ", 13, 10, '$'
	act5 db "5 - Output from X such decimal signed integer: ", 13, 10, '$'
	act6 db "6 - Output from X such hexadecimal unsigned integer: ", 13, 10, '$'
	act7 db "7 - Output from X such hexadecimal signed integer: ", 13, 10, '$'
	act8 db "8 - Exit from programm", 13, 10, 13, 10, '$'
	
	uncorrect_digit db "Error: Input uncorrect symbol (not digit)", '$'
	big_int db "Error: Input integer too very big (must be -32768..65535)", 13, 10, '$'
	correct_number db "At first enter correct number!", 13, 10, 13, 10, '$'
	
	table dw print_menu, int_input, print_usbinary, print_sbinary, print_usdec, print_sdec, print_ushex, print_shex, quit

	er db 1;
	X dw 0;
	key db 0; 
	value db 0, 0, 0, 0, 0, 0, 0, '$'
	
	next_str: db 13, 10, '$'
	d_next_str: db 13, 10, 13, 10, '$'

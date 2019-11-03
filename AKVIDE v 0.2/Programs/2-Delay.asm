org 100h

segment .txt

main:
	mov dx, str
	mov ah, 9
	int 21h
	
	mov ah, 10h
	int 16h

	cmp al, 27
	jne m1
	call quit
	m1:
	
	cmp al, 48
	jb main
	cmp al, 57
	ja main
	
	mov byte[sec], al
	mov dx, str_delay
	mov ah, 09h
	int 21h
	mov dl, byte[sec]
	mov ah, 02h
	int 21h
	mov dx, str_sec
	mov ah, 09h
	int 21h
	
	xor ah, ah ; ah = 0
	mov al, byte[sec]
	sub al, 30h
	push ax
	
	xor al, al ; al = 0
	mov es, ax
	mov ax, word[es:046ch]
	mov word[tick], ax
	push word[tick]
	call delay
	
	mov dx, next_str
	mov ah, 9
	int 21h
	int 21h
	
	jmp main


print_digit:
	mov dx, ax
	mov cx, ax
	mov ah, 02h
	
	mov dl, ch
	shr dl, 4
	cmp dl, 9
	ja pd_l1
		add dl, 30h
		jmp pd_l11
	pd_l1:
		add dl, 37h
	pd_l11:
	int 21h
	
	mov dl, ch
	and dl, 0fh
	cmp dl, 9
	ja pd_l2
		add dl, 30h
		jmp pd_l21
	pd_l2:
		add dl, 37h
	pd_l21:
	int 21h

	mov dl, cl
	shr dl, 4
	cmp dl, 9
	ja pd_l3
		add dl, 30h
		jmp pd_l31
	pd_l3:
		add dl, 37h
	pd_l31:
	int 21h
	
	mov dl, cl
	and dl, 0fh
	cmp dl, 9
	ja pd_l4
		add dl, 30h
		jmp pd_l41
	pd_l4:
		add dl, 37h
	pd_l41:
	int 21h
	
	ret
	
	
	
delay:
	pop bx 
	pop cx ; tick
	pop ax ; sec	

	mov si, cx ; запоминаем текущее количество тиков
	mov dh, 18
	mul dh
	add cx, ax ; количество тиков, которое должно пройти
	delay_l1:
		mov si, [es:046ch]
	cmp si, cx ; если пройдено меньше, то повтор
	jb delay_l1
		
	mov dx, str_tick_count
	mov ah, 9
	int 21h
	
	mov ax, si
	sub ax, word[tick]
	call print_digit	
	
	push bx
	ret
			

quit:
	mov	ax, 4C00H
	int	21h
	ret
	
segment .data
	str: db "Enter digit (0..9) for delay, Esc - for exit:", 13, 10, '$'
	str_delay: db "Delay during ", '$'
	str_sec: db " seconds:", 13, 10, '$'
	str_tick_count db "Total tick count (Hex): ", '$'
	next_str db 13, 10, '$'
	tick dw 0
	sec db 0
	t dw 0

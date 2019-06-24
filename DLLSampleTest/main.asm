include irvine32.inc
.data
;no static data
.code
;-----------------------------------------------------
;Sum PROC Calculates 2 unsigned integers
;Recieves: 2 DWord parametes number 1 and number 2
;Return: the sum of the 2 unsigned numbers into the EAX
;------------------------------------------------------
Sum PROC int1:DWORD, int2:DWORD
	mov eax, int1
	add eax, int2
	ret
Sum ENDP

;-----------------------------------------------------
;SumArr PROC Calculates Sum of an array
;Recieves: Offset and the size of an array
;Return: the sum of the array into the EAX
;------------------------------------------------------
SumArr PROC arr:PTR DWORD, sz:DWORD
	push esi
	push ecx

	mov esi, arr
	mov ecx, sz
	mov eax, 0
	sum_loop:
		add eax, DWORD PTR [esi]
		add esi, 4
	loop sum_loop
	
	pop ecx
	pop esi
	Ret
SumArr ENDP

;----------------------------------------------------------------
;Sum PROC convert an array of bytes from lower case to upper case
;Recieves: offset of byte array and it's size
;---------------------------------------------------------------
ToUpper PROC str1:PTR BYTE, sz:DWORD
	push esi
	push ecx
	
	mov esi, str1
	mov ecx, sz
	l1:
		;input validations (Limitation the char to be between a and z)
		cmp byte ptr [esi], 'a'
		jb skip
		cmp byte ptr [esi], 'z'
		ja skip

		and byte ptr [esi], 11011111b
		skip:
		inc esi
	loop l1
	
	pop ecx
	pop esi
	ret
ToUpper ENDP

Brightness PROC arr:PTR DWORD, sz:DWORD, BValue:DWORD

	push esi
	push ecx

	mov esi, arr
	mov ecx, sz
	l:
	mov edx, DWORD PTR [esi]
	add edx, BValue
	cmp edx, +255d
	JG doOP
	cmp edx, 0d
	JNG doNOP
	mov DWORD PTR [esi], edx
	jmp quitl
	doOP:
	mov DWORD PTR [esi], 255d
	jmp quitl
	doNOP:
	mov DWORD PTR [esi], 0d
	quitl:
	add esi,4
	loop l

    pop esi
	pop ecx

	ret
Brightness ENDP

GrayScale PROC arrR:PTR DWORD,arrG:PTR DWORD,arrB:PTR DWORD, sz:DWORD

	push esi
	push ecx

	mov esi, arrR
	mov edi, arrG
	mov edx, arrB
	mov ecx, sz
	l:
	
	mov eax, DWORD PTR [esi]
	add eax, DWORD PTR [edi]
	add eax, DWORD PTR [edx]
	mov bl, 3
	push edx
    div bl
	pop edx

	mov DWORD PTR [esi], eax
	mov DWORD PTR [edi], eax
	mov DWORD PTR [edx], eax
	
	add esi,4
	add edi,4
	add edx,4
	loop l

    pop esi
	pop ecx

	ret
GrayScale ENDP

; DllMain is required for any DLL
DllMain PROC hInstance:DWORD, fdwReason:DWORD, lpReserved:DWORD
mov eax, 1 ; Return true to caller.
ret
DllMain ENDP
END DllMain
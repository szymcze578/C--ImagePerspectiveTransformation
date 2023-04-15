
; Nazwa Uczelni: Politechnika Œl¹ska
; Semestr i przedmiot: Jêzyki Asemblerowe, sem 5
; Temat projektu: Przekrzta³canie perspektywiczne obrazów
; Opis: Celem projektu jest edycja obrazu w taki sposób aby u¿ywaj¹c wygl¹da³ on jakby by³ zrzutowany perspektywicznie.
; Inaczej mówi¹c, pozycja obrazu po edycji bêdzie wygenerowana w taki sposób jakby zmieni³ siê punkt widzenia obserwatora.
; Autor: Szymon Czech

; --------------------------------------
; KOD W C++:
; --------------------------------------
; struct PixelPosition {
;   int x, y;
; };
; 
; PixelPosition GetPixelPosition(int index, int width) {
;   int pixelIndex = index / 3;
;   int x = pixelIndex % (width);
;   int y = pixelIndex / (width);
; 
;   return {x, y};
; }
; 
; void transformation(double factor, unsigned char* inp, int start, int end, int width, int height, unsigned char* outp) {
; 
;   for (int i = start; i < end; i += 3) {
;     PixelPosition pos = GetPixelPosition(i, width);
;     double new_x = pos.x;
;     double new_y = pos.x * 0.5 + pos.y;
;     double new_w = pos.x * factor + 1;
; 
;     int dst_x = (int)(new_x / new_w);
;     int dst_y = (int)(new_y / new_w);
; 
;     if (dst_x >= 0 && dst_x < width && dst_y >= 0 && dst_y < height) {
;       int index = (pos.y * width + pos.x) * 3;
;       int new_index = (dst_y * width + dst_x) * 3;
; 
;       outp[new_index] = inp[index];
;       outp[new_index + 1] = inp[index + 1];
;       outp[new_index + 2] = inp[index + 2];
;     }
;   }
; }
; --------------------------------------

; --------------------------------------
; KOD W ASEMBLERZE :
; --------------------------------------
.code
   
 ;przesuniecie na stosie dla zmiennych lokalnych
_width = 64   
_height = 72 
_outp = 80   

; deklaracja stalch przechowujacych wartosci 1 i 0.5 (do obliczania pozycji)
stala_1 DQ 03ff0000000000000r ; wartosc 1
stala_2 DQ 03fe0000000000000r ; wartosc 0.5

;void transformation(double factor, unsigned char* inp, int start, int end, int width, int height, unsigned char* outp) 

transformation PROC       
;  for (int i = start; i < end; i += 3) {
	cmp	r8d, r9d		; porownuje wartosci w rejestrze r8d i r9d
	jge	koniec_programu ; jesli porownanie jest prawdziwe, skacze do etykiety "koniec_programu"c
	push	rdi			; wrzuca wartosc znajdujaca sie w rejestrze RDI na stos
	sub	rsp, 16			; odejmuje 16 od rejestru rsp (wskaznika na stos)

; pobieranie zmiennych do odpowiednich rejestrow
	mov	r10d, DWORD PTR [rsp + _width]		; przepisuje wartosc z _width na r10d
	mov	r11d, r9d						; przepisuje wartosc z rejestru r9d do r11d
 	vmovsd	xmm4, QWORD PTR stala_1		
	vmovsd	xmm5, QWORD PTR stala_2		
	vmovaps	XMMWORD PTR [rsp], xmm6		; przepisuje wartosc xmm6 do adresu w rsp
	mov	rdi, rdx						
	mov	QWORD PTR [rsp+32], rbx			; przepisuje wartosc z rejestru rbx do adresu rsp+32
	mov	rbx, QWORD PTR [rsp + _outp]	; przepisuje wartosc z _outp do rejestru rbx
	mov	QWORD PTR [rsp+40], rsi			; przepisuje wartosc z rejestru rsi do adresu rsp+40
	mov	esi, DWORD PTR [rsp + _height]	; przepisywania wartosci zawartej w znajdujácej sie na stosie (rsp) z przesunieciem _height do rejestru esi.
	vmovaps	xmm6, xmm0					; przepisywania wartosci zawartych w rejestrze xmm0 do rejestru xmm6. 

Funkcja_GetPixelPosition:
; int pixelIndex = index / 3; n/3 = (n * 0x55555556 ) z odpowiednim przesunieciem bitowym
	mov	eax, 1431655766			; przypisanie do rej. eax wartosci 1431655766
	imul	r8d					; mnozenie eax przez r8d 
	vxorps	xmm2, xmm2, xmm2	; wyzerowanie xmm2
	shr	eax, 31					; przesuniecie bitow w rejestrze eax o 31 miejsc w prawo
	add	eax, edx				; dodawanie

; int x = pixelIndex % (width);
	cdq			 ; rozszerzenie eax na edx:eax (cdq to skrot od 'convert double to quad')
	idiv	r10d ; instrukcja dzieli zawartosc rejestru r10d przez operand, 
				 ; ktory jest w rejestrze  (AX, DX:AX, EDX:EAX lub RDX:RAX)
				 ; przechowywany jest iloraz dzielenia w rejestrze RAX, a reszta z dzielenia w EDX/RDX

; koniec funkcji GetPixelPosition

; PixelPosition pos = GetPixelPosition(i, width);
; double new_x = pos.x;
; double new_y = pos.x * 0.5 + pos.y;
; double new_w = pos.x * factor + 1;
	vcvtsi2sd xmm2, xmm2, edx ; konwersja 
	vmulsd	xmm0, xmm2, xmm6  ; mnozenie 
	vaddsd	xmm3, xmm0, xmm4  ; dodawanie 

;  int dst_x = (int)(new_x / new_w);
	vdivsd	xmm1, xmm2, xmm3  ; dzielenie 
	vmulsd	xmm2, xmm2, xmm5  ; mnozenie 
	vcvttsd2si r9d, xmm1      ; konwersja na int

	vxorps	xmm0, xmm0, xmm0  ; wyzerowanie xmm0
	vcvtsi2sd xmm0, xmm0, eax ; konwersja na double
	vaddsd	xmm1, xmm2, xmm0  ; dodawanie 

; int dst_y = (int)(new_y / new_w);
	vdivsd	xmm2, xmm1, xmm3  ; dzielenie xmm1/xmm3 = xmm2
	vcvttsd2si ecx, xmm2      ; konwersja na int 

;  if (dst_x >= 0 && dst_x < width && dst_y >= 0 && dst_y < height) {
	test	r9d, r9d  ; sprawdzanie czy r9d jest mniejsze od 0
	js	SHORT petla   ; sprawdza czy bit wyniku ostatniej operacji (w tym przypadku testowanie r9d) jest ustawiony na 1. Jesli tak, to do ->"petla".
	cmp	r9d, r10d	  ; porownanie wartosci  r9d i r10d. 
	jge	SHORT petla   ; jesli r9d jest wieksze lub rowne r10d, program przeskakuje do etykiety "petla".

	test	ecx, ecx  ; sprawdza czy bit wyniku ostatniej operacji  jest ustawiony na 1
	js	SHORT petla   ; jesli tak, to program przeskakuje do etykiety "petla".
	cmp	ecx, esi      ; porownuja wartosci zawarte w rejestrach ecx i esi.
	jge	SHORT petla   ; jesli ecx jest wieksze lub rowne esi, program przeskakuje do etykiety "petla"

;  int index = (pos.y * width + pos.x) * 3;
	imul	eax, r10d ; mnozenie (indeks dla tablicy inp)

;  int new_index = (dst_y * width + dst_x) * 3;
	imul	ecx, r10d ; mnozenie  (indeks dla tablicy outp)
	add	eax, edx      ; dodawanie
	add	ecx, r9d      ; dodawanie
	lea	eax, DWORD PTR [rax+rax*2] ; przesuwa wartosc w rejestrze eax o dwa bajty

; outp[new_index] = inp[index];
	movsxd	rdx, eax				; konwersja indeksu piksela z 32 na 64-bitowy
	lea	eax, DWORD PTR [rcx+rcx*2]	; obliczenie nowego indeksu piksela (w tablicy wyjsciowej) i przypisanie do rejestru eax
	movsxd	rcx, eax				; konwersja nowego indeksu piksela z 32 na 64-bitowy i do rcx
	movzx	eax, BYTE PTR [rdx+rdi] ; pobranie wartosci skladowej koloru dla indeksu piksela z tablicy wejsciowej (inp) i przypisanie do rejestru eax(rdx+rdi = adres inp[index])
	mov	BYTE PTR [rcx+rbx], al		; zapisanie wartosci skladowej koloru dla nowego indeksu piksela w tablicy wyjsciowej outp (outp[new_index])

; outp[new_index + 1] = inp[index + 1];
	movzx	eax, BYTE PTR [rdx+rdi+1] ; przepisuje wartosc 1 bajtu z adresu [rdx+rdi+1] do rejestru eax
	mov	BYTE PTR [rcx+rbx+1], al	  ; przepisuje wartosc z rejestru eax do nowego indeksu w out (adresu [rcx+rbx+1])

; outp[new_index + 2] = inp[index + 2];
	movzx	eax, BYTE PTR [rdx+rdi+2] ; przepisuje wartosc 1 bajtu z adresu [rdx+rdi+2] do rejestru eax
	mov	BYTE PTR [rcx+rbx+2], al      ; przepisuje wartosc z rejestru eax do nowego indeksu w out (adresu [rcx+rbx+2])

petla:
; for (int i = start; i < end; i += 3) {
	add	r8d, 3					; dodanie 3 do r8d (licznika)
	cmp	r8d, r11d				; porownanie r8d i r11d
	jl Funkcja_GetPixelPosition ; jesli r8d jest mniejsze, skocz ->  GetPixelPosition
	mov	rsi, QWORD PTR [rsp+40] ; przenies dane z [rsp+40] do rsi
	mov	rbx, QWORD PTR [rsp+32] ; przenies dane z [rsp+32] do rbx

; przywracanie rejestrow
	vmovaps	xmm6, XMMWORD PTR [rsp] ; przywracanie zawartosci rejestru xmm6 z [rsp]
	add	rsp, 16						; dodaj 16 bajtow do rsp, te ktore zostaly na poczatku zarezerwowane
	pop	rdi							; usun dane z szczytu stosu
koniec_programu:
	ret	0							
transformation ENDP                 
end

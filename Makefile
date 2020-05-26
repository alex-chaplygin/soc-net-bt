SRC = Сервер.cs СоциальнаяСеть.cs Пользователь.cs Чат.cs Сообщение.cs
DMCS = -r:System.Drawing.dll

Сервер.exe: $(SRC)
	dmcs $(DMCS) $(SRC)
run: Сервер.exe
	./Сервер.exe

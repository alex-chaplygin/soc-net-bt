SRC = Сервер.cs СоциальнаяСеть.cs Пользователь.cs Чат.cs Сообщение.cs Стена.cs Группа.cs
SRC_TEST = ТестСоцСети.cs СоциальнаяСеть.cs Пользователь.cs Чат.cs Сообщение.cs Стена.cs
DMCS = -r:System.Drawing.dll -debug+

Сервер.exe: $(SRC)
	dmcs $(DMCS) $(SRC)
test: $(SRC_TEST)
	dmcs $(DMCS) $(SRC_TEST)
run: Сервер.exe
	./Сервер.exe

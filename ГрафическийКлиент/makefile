SRC = Form1.Designer.cs Form1.cs ОтправитьПолучить.cs Program.cs Board.cs Board.Designer.cs Commands.cs Commands.Designer.cs
FLAGS = -res:Form1.resx -res:Board.resx -res:Commands.resx -r:System.Data.dll -r:System.Drawing -r:System.Windows.Forms.dll

ГрКлиент.exe: $(SRC)
	dmcs -out:ГрКлиент.exe $(FLAGS) $(SRC)

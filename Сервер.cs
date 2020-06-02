using System;
using System.IO;
using System.Collections.Generic;

namespace СоцСеть {
    class Сервер {
	static СоциальнаяСеть соцСеть;
	
	public static void Main(string[] args)
	{
	    if (args.Length < 1) {
		Console.WriteLine("Сервер <путь>");
		return;
	    }
	    string путь = args[0];
	    соцСеть = new СоциальнаяСеть();
	    Пользователь п1 = соцСеть.Регистрация("user", "pass");
	    Пользователь п2 = соцСеть.Регистрация("user2", "pass2");
	    while (true) {
		string[] файлы = Directory.GetFiles(путь, "*.запрос");
		foreach (string файл in файлы) {
		    try {
			ЖдатьБлокировку(файл);
			StreamReader sr = new StreamReader(файл);
			string сообщение = sr.ReadLine();
			Console.WriteLine(файл + ":" + сообщение);
			sr.Close();
			СоздатьБлокировку(файл + ".ответ");
			StreamWriter sw = new StreamWriter(файл + ".ответ");
			sw.WriteLine(Обработать(сообщение));
			sw.Close();
			ОсвободитьБлокировку(файл + ".ответ");
		    } catch (FileNotFoundException e) {
		    }
		}
	    }
	}

	static void ЖдатьБлокировку(string файл)
	{
	    while (true) {
		try {
		    StreamReader sr = new StreamReader(файл + ".блок");
		    sr.Close();
		} catch (FileNotFoundException e) {
		    return;
		}
	    }
	}

	static void СоздатьБлокировку(string файл)
	{
	    StreamWriter sw = new StreamWriter(файл + ".блок");
	    sw.WriteLine();
	    sw.Close();
	}

	static void ОсвободитьБлокировку(string файл)
	{
	    File.Delete(файл + ".блок");
	}

	public static string Обработать(string сообщение)
	{
	    string ответ = "";
	    string[] команда = сообщение.Split(' ');

	    try {
		if (команда[0] == "Авторизация")
		    ответ = Авторизация(команда[1], команда[2]);
		else
		    ответ = "Неизвестная команда";
	    } catch (IndexOutOfRangeException e) {
		ответ = "Неправильная команда";
	    }
	    return ответ;
	}

	public static string Авторизация(string имя, string пароль)
	{
	    Пользователь п = соцСеть.Авторизация(имя, пароль);
	    if (п == null) return "Неверное имя пользователя или пароль";
	    else return "Успешно";
	}
    }
}

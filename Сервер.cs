using System;
using System.IO;
using System.Collections.Generic;

namespace СоцСеть {
    class Сервер {
	static СоциальнаяСеть соцСеть;
	static Dictionary<int, Пользователь> активныеПользователи;
	static Random номера;
	
	public static void Main(string[] args)
	{
	    if (args.Length < 1) {
		Console.WriteLine("Сервер <путь>");
		return;
	    }
	    string путь = args[0];
	    соцСеть = new СоциальнаяСеть();
	    активныеПользователи = new Dictionary<int, Пользователь>();
	    номера = new Random();
	    соцСеть.Регистрация("user", "pass");
	    соцСеть.Регистрация("user2", "pass2");
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
			Console.WriteLine(e.Message);
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
		//	Console.WriteLine(e.Message);
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
		else if (команда[0] == "Выход")
		    ответ = Выход(команда[1]);
		else if (команда[0] == "Сообщение")
		    ответ = Сообщение(команда[1], команда[2], String.Join(" ", команда, 3, команда.Length - 3));
		else
		    ответ = "Неизвестная команда";
	    } catch (IndexOutOfRangeException e) {
		ответ = "Неправильная команда " + e.Message;
	    }
	    Console.WriteLine(ответ);
	    return ответ;
	}

	public static string Авторизация(string имя, string пароль)
	{
	    int номер = НайтиПользователя(имя, пароль);
	    if (номер == -1) {
		Пользователь п = соцСеть.Авторизация(имя, пароль);
		if (п == null) return "Неверное имя пользователя или пароль";
		else {
		    номер = ПолучитьНомер();
		    активныеПользователи.Add(номер, п);
		}
	    }
	    return номер.ToString();
	}

	public static string Выход(string номер)
	{
	    активныеПользователи.Remove(Convert.ToInt32(номер));
	    return "";
	}

	public static string Сообщение(string номер, string кому, string текст)
	{
	    int н = Convert.ToInt32(номер);
	    if (!активныеПользователи.ContainsKey(н)) return "Не авторизован";
	    Пользователь п = активныеПользователи[н];
	    Чат чат = null;
	    bool flag = false;
	    if (п.ПолучитьИмя() == кому)
		return "Нельзя отправить сообщение себе";
            foreach (Чат ч in п.ПолучитьЧаты())
                if (ч.ПолучитьПользователя1() == п && ч.ПолучитьПользователя2() == соцСеть.НайтиПользователя(кому))
                {
                    чат = ч;
                    flag = true;
                }
            if (flag == false)
                чат = соцСеть.НовыйЧат(п.ПолучитьИмя(), кому);
	    if (чат == null)
                return $"Пользователь с именем {кому} не существует";
	    чат.ДобавитьСообщение(new Сообщение(соцСеть.НайтиПользователя(кому), текст));
	    foreach (Чат ч in п.ПолучитьЧаты()) {
		Console.WriteLine("Чат " + ч.ПолучитьПользователя1().ПолучитьИмя() + "-" + ч.ПолучитьПользователя2().ПолучитьИмя());
		foreach (Сообщение с in ч.ПолучитьСообщения())
		    Console.WriteLine(с.ПолучитьТекст());
	    }
            return $"Сообщение отправлено: \"{текст}\"";
	}

	static int ПолучитьНомер()
	{
	    return номера.Next() % 1000;
	}

	static int НайтиПользователя(string имя, string пароль)
	{
	    foreach (int номер in активныеПользователи.Keys) {
		Пользователь п = активныеПользователи[номер];
		if (п.ПолучитьИмя() == имя && п.ПолучитьПароль() == пароль)
		    return номер;
	    }
	    return -1;
	}
    }
}

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
	    Загрузить();
	    активныеПользователи = new Dictionary<int, Пользователь>();
	    номера = new Random();
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

	static string Обработать(string сообщение)
	{
	    string ответ = "";
	    string[] команда = сообщение.Split(' ');

	    try {
		if (команда[0] == "Регистрация")
		    ответ = Регистрация(команда[1], команда[2]);
		else if (команда[0] == "Авторизация")
		    ответ = Авторизация(команда[1], команда[2]);
		else if (команда[0] == "Выход")
		    ответ = Выход(команда[1]);
		else if (команда[0] == "Сообщение")
		    ответ = Сообщение(команда[1], команда[2], String.Join(" ", команда, 3, команда.Length - 3));
		else if (команда[0] == "НовыйДруг")
                    ответ = НовыйДруг(Convert.ToInt32(команда[1]), команда[2]);
                else if (команда[0] == "СписокДрузей")
                    ответ = СписокДрузей(Convert.ToInt32(команда[1]));
		else if (команда[0] == "Стена")
                    ответ = ОтобразитьСтену(Convert.ToInt32(команда[1]));
		else
		    ответ = "Неизвестная команда";
	    } catch (Exception e) {
		ответ = "Неправильная команда " + e.Message;
	    }
	    Console.WriteLine(ответ);
	    Сохранить();
	    return ответ;
	}

	static string Авторизация(string имя, string пароль)
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

	static string Выход(string номер)
	{
	    активныеПользователи.Remove(Convert.ToInt32(номер));
	    return "";
	}

	static string Сообщение(string номер, string кому, string текст)
	{
	    Пользователь п = активныеПользователи[Convert.ToInt32(номер)];
	    if (п == null) return "Не авторизован";
	    return текст;
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

	static string Регистрация(string имя, string пароль)
        {
	    Пользователь п = соцСеть.Регистрация(имя, пароль);
	    if (п != null)
	    {
		активныеПользователи.Add(ПолучитьНомер(), п);
		return "Успешная регистрация";
	    }
	    else return "Пользователь с таким именем уже зарегистрирован";
        }
	
	static string НовыйДруг(int номер, string имя)
        {
            Пользователь п = соцСеть.НайтиПользователя(имя);
	    if (активныеПользователи.ContainsKey(номер) == true)
		if (п != null)
		{
		    активныеПользователи[номер].ДобавитьДруга(п);
		    return $"Вы добавили в друзья {имя}";
		}
            return "Пользователь не авторизован";
        }
	
        static string СписокДрузей(int номер)
        {
            string friendList = "";
	    if (активныеПользователи.ContainsKey(номер) == true) {
		foreach (Пользователь п in активныеПользователи[номер].СписокДрузей())
		    friendList += п.ПолучитьИмя() + "\n";
		if (friendList == "")
		    return "У вас нет друзей.";
		else
		    return friendList;
	    }
	    return "Пользователь не авторизован";
	}

	public static string ОтобразитьСтену(int код)
        {
	    List<Сообщение> сообщения = активныеПользователи[код].ПолучитьСтену().ПолучитьПубликации();
            string board = "";
            if (сообщения.Count > 10)
                for (int i = сообщения.Count - 10; i < сообщения.Count; i++)
                    board += сообщения[i].ПолучитьТекст() + "\n";
            else
                for (int i = 0; i < сообщения.Count; i++)
                    board += сообщения[i].ПолучитьТекст() + "\n";
            return board;
        }

	static void Загрузить()
        {
            StreamReader srПользователи = new StreamReader("пользователи.txt");
            StreamReader srСообщения = new StreamReader("сообщения.txt");
            StreamReader srСтены = new StreamReader("стены.txt");
            string line;
            while ((line = srПользователи.ReadLine()) != null)
                соцСеть.Регистрация(line.Split(':')[0], line.Split(':')[1]);
            srПользователи.Close();
            while ((line = srСообщения.ReadLine()) != null)
                Сообщение(line.Split(':')[0], line.Split(':')[1], line.Split(':')[2]);
            srСообщения.Close();
            while ((line = srСтены.ReadLine()) != null)
                соцСеть.НайтиПользователя(line.Split(':')[0]).Опубликовать(line.Split(':')[1]);
            srСтены.Close();
        }
	
        static void Сохранить()
        {
            StreamWriter swПользователи = new StreamWriter("пользователи.txt");
            StreamWriter swСообщения = new StreamWriter("сообщения.txt");
            StreamWriter swСтены = new StreamWriter("стены.txt");
            List<Пользователь> пользователи = соцСеть.ВернутьПользователей();
            List<Чат> чаты = соцСеть.ПолучитьЧаты();
            List<Сообщение> сообщения;
            foreach (Пользователь п in пользователи)
                swПользователи.WriteLine($"{п.ПолучитьИмя()}:{п.ПолучитьПароль()}");
            swПользователи.Close();
            foreach (Чат ч in чаты)
            {
                сообщения = ч.ПолучитьСообщения();
                foreach (Сообщение с in сообщения)
                    swСообщения.WriteLine($"{ч.ПолучитьПользователя1()}:{ч.ПолучитьПользователя2()}:{с.ПолучитьТекст()}");
            }
            swСообщения.Close();
            foreach (Пользователь п in пользователи)
            {
                сообщения = п.ПолучитьСтену().ПолучитьПубликации();
                foreach (Сообщение с in сообщения)
                    swСтены.WriteLine($"{п.ПолучитьИмя()}:{с.ПолучитьТекст()}");
            }
            swСтены.Close();
        }
    }
}

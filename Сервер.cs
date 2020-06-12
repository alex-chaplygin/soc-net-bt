using System;
using System.IO;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace СоцСеть {
    class Сервер {
	static СоциальнаяСеть соцСеть;
	static Dictionary<int, Пользователь> активныеПользователи;
	static Random номера;

	public static void Main(string[] args)
	{
	    TcpListener listener = null;
	    if (args.Length < 1) {
		Console.WriteLine("Сервер <порт>");
		return;
	    }
	    соцСеть = new СоциальнаяСеть();
	    активныеПользователи = new Dictionary<int, Пользователь>();
	    номера = new Random();
	    Пользователь п = соцСеть.Регистрация("user", "pass");
	    соцСеть.Регистрация("user2", "pass2");
	    соцСеть.Регистрация("user3", "pass3");
	    соцСеть.Регистрация("user4", "pass4");
	    п.Опубликовать("1!!!!!!!!!!");
	    п.Опубликовать("2------------");
	    п.Опубликовать("3------------");
	    п.Опубликовать("4------------");
	    п.Опубликовать("5------------");
	    п.Опубликовать("6------------");
	    п.Опубликовать("7------------");
	    п.Опубликовать("8------------");
	    п.Опубликовать("9------------");
	    п.Опубликовать("10------------");
	    п.Опубликовать("11------------");
	    int port = Convert.ToInt32(args[0]);
	    listener = new TcpListener(IPAddress.Loopback, port);
	    listener.Start();

	    while (true)
	    {
		TcpClient client = listener.AcceptTcpClient();
		Thread t = new Thread(ОбработкаЗапросаКлиента);
		t.Start(client);
	    }	    
	}

	static void ОбработкаЗапросаКлиента(Object obj)
	{
	    TcpClient client = null;
	    StreamWriter writer = null;
	    StreamReader reader = null;
	    try {
		client = (TcpClient)obj;
		NetworkStream stream = client.GetStream();
		writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };
		reader = new StreamReader(stream, Encoding.UTF8);
		string inputLine = "";
		inputLine = reader.ReadLine();
		writer.WriteLine(Обработать(inputLine));
		writer.Close();
		reader.Close();
		client.Close();
	    } catch (Exception e) {
	        writer.Close();
		reader.Close();
		client.Close();
		Console.WriteLine(e.Message);
	    }
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
	    if (активныеПользователи.ContainsKey(номер))
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
	    if (!активныеПользователи.ContainsKey(код))
		return "Пользователь не авторизован";
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
    }
}

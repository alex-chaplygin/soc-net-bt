using System;
using System.IO;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Drawing;

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
	    Загрузить();
	    активныеПользователи = new Dictionary<int, Пользователь>();
	    номера = new Random();
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
                    ответ = ОтобразитьСтену(Convert.ToInt32(команда[1]), Convert.ToInt32(команда[2]));
		else if (команда[0] == "Онлайн")
                    ответ = ПроверкаОнлайн(Convert.ToInt32(команда[1]), команда[2]);
		else if (команда[0] == "Прикрепить")
                    ответ = ПрикрепитьИзображение(Convert.ToInt32(команда[1]), команда[2]);
		else if (команда[0] == "Комментарий")
                    ответ = ДобавитьКомментарий(Convert.ToInt32(команда[1]), команда[2], Convert.ToInt32(команда[3]), string.Join(" ", команда, 4, команда.Length - 4));
		else if (команда[0] == "Подписаться")
                    ответ = Подписаться(Convert.ToInt32(команда[1]), команда[2]);
		else if (команда[0] == "СписокГрупп")
                    ответ = СписокГрупп(Convert.ToInt32(команда[1]));
		else if (команда[0] == "СписокКомментариев")
                    ответ = СписокКомментариев(Convert.ToInt32(команда[1]), команда[2], Convert.ToInt32(команда[3]), Convert.ToInt32(команда[4]));
		else if (команда[0] == "Список")
		    ответ = Список(Convert.ToInt32(команда[1]), команда[2], Convert.ToInt32(команда[3]));
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
	    return $"Сообщение отправлено";
	}

	static void ВыводЧатов(Пользователь п)
	{
	    foreach (Чат ч in п.ПолучитьЧаты()) {
		Console.WriteLine("Чат " + ч.ПолучитьПользователя1().ПолучитьИмя() + "-" + ч.ПолучитьПользователя2().ПолучитьИмя());
		foreach (Сообщение с in ч.ПолучитьСообщения())
		    Console.WriteLine(с.ПолучитьТекст());
	    }
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

	static string ОтобразитьСтену(int код, int num)
        {
	    if (!активныеПользователи.ContainsKey(код))
		return "Пользователь не авторизован";
	    List<Сообщение> сообщения = активныеПользователи[код].ПолучитьСтену().ПолучитьПубликации();
            string board = "";
	    if (сообщения.Count > 10 + num)
                for (int i = сообщения.Count - num - 10; i < сообщения.Count - num; i++)
                    board += сообщения[i].ПолучитьТекст() + "\n";
            else
                for (int i = 0; i < сообщения.Count - num; i++)
                    board += сообщения[i].ПолучитьТекст() + "\n";
            return board;
	}
	
	static string ПроверкаОнлайн(int номер, string имя)
        {
            if (активныеПользователи.ContainsKey(номер) == true)
            {
                if (соцСеть.НайтиПользователя(имя) == null)
                    return "Пользователь не найден";
                if (активныеПользователи.ContainsValue(соцСеть.НайтиПользователя(имя)) == true)
                    return "да";
                else
                    return "нет";
            }
            else
                return "Не авторизован";
        }

	static string ДобавитьКомментарий(int номер, string имя, int номерПубликации, string текст)
        {
            if (активныеПользователи.ContainsKey(номер) == false)
                return "Не авторизован";
            if (соцСеть.НайтиПользователя(имя) != null)
            {
		List<Сообщение> п = соцСеть.НайтиПользователя(имя).ПолучитьСтену().ПолучитьПубликации();
		int н = п.Count - номерПубликации - 1;
		if (н < 0)
                    return "Нет такой публикации";
                п[н].ДобавитьКомментарий(текст);
                return "Комментарий добавлен";
            }
            else return $"Пользователь с именем {имя} не найден";
        }

	static void Загрузить()
        {
	    StreamReader srКомментарии = new StreamReader("комментарии.txt");
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
            while ((line = srКомментарии.ReadLine()) != null)
                соцСеть.НайтиПользователя(line.Split(':')[0]).ПолучитьСтену().ПолучитьПубликации()[Convert.ToInt32(line.Split(':')[1])].ДобавитьКомментарий(line.Split(':')[2]);
            srКомментарии.Close();
        }
	
        static void Сохранить()
        {
	    StreamWriter swКомментарии = new StreamWriter("комментарии.txt");
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
                {
                    swСообщения.WriteLine($"{ч.ПолучитьПользователя1()}:{ч.ПолучитьПользователя2()}:{с.ПолучитьТекст()}");
                }
            }
            swСообщения.Close();
            foreach (Пользователь п in пользователи)
            {
                сообщения = п.ПолучитьСтену().ПолучитьПубликации();
                foreach (Сообщение с in сообщения)
                    swСтены.WriteLine($"{п.ПолучитьИмя()}:{с.ПолучитьТекст()}");
            }
            swСтены.Close();
	    foreach (Пользователь п in пользователи)
            {
                сообщения = п.ПолучитьСтену().ПолучитьПубликации();
                for (int j = 0; j < сообщения.Count; j++)
                    for (int i = 0; i < сообщения[j].ПолучитьКомментарии().Count; i++)
                        swКомментарии.WriteLine($"{п.ПолучитьИмя()}:{j}:{сообщения[j].ПолучитьКомментарии()[i]}");
            }
	    swКомментарии.Close();
	}

	static string ПрикрепитьИзображение(int номер, string path)
        {
            if (активныеПользователи.ContainsKey(номер) == false)
                return "Пользователь не авторизован";
            if (File.Exists(path) == false)
                return "Файл не найден " + path;
            try
            {
                Image img = Image.FromFile(path);
                List<Сообщение> публикации = активныеПользователи[номер].ПолучитьСтену().ПолучитьПубликации();
                if (публикации.Count == 0)
                    return "На стене нет публикаций";
                int index = публикации.Count - 1;
                публикации[index].ДобавитьИзображение(img);
                return "Изображение добавлено";
            }
            catch(FormatException e)
            {
                return Convert.ToString(e);
            }
        }

	static string Подписаться(int код, string имя)
        {
            if (активныеПользователи.ContainsKey(код) == true)
            {
                if (соцСеть.НайтиГруппу(имя) != null)
                {
                    соцСеть.ПодписатьсяНаГруппу(активныеПользователи[код], имя);
                    return $"Вы подписались на группу \"{имя}\"";
                }
                else return "Группа не найдена";
            }
            else
                return "Не авторизован";
        }

	static string СписокГрупп(int код)
        {
            if (активныеПользователи.ContainsKey(код) == false)
                return "Пользователь не авторизован";
            string groups = "";
            if (соцСеть.ПолучитьГруппы().Count != 0)
            {
                foreach (Группа g in соцСеть.ПолучитьГруппы())
                    groups += $"{g.ПолучитьНазвание()}\n";
                return groups;
            }
            else return "Группы не найдены";
	}
	
	static string СписокКомментариев(int код, string имяПользователя, int номерПубликации, int смещение)
        {
            if (!активныеПользователи.ContainsKey(код))
                return "Пользователь не авторизован";
            List<Сообщение> публикации = соцСеть.НайтиПользователя(имяПользователя).ПолучитьСтену().ПолучитьПубликации();
            if (публикации.Count == 0)
                return "Ошибка: на стене нет публикаций";
            int index = публикации.Count - номерПубликации - 1;
            List<string> комментарии = публикации[index].ПолучитьКомментарии();
            string ком = "";
            if (комментарии.Count == 0)
                return "Ошибка: у публикации отсутствуют комментарии";
            if (комментарии.Count >= смещение + 10)
                for (int i = комментарии.Count - смещение - 10; i < комментарии.Count - смещение; i++)
                    ком += комментарии[i] + "\n";
            else
                if (смещение < комментарии.Count)
                    for (int i = 0; i < комментарии.Count - смещение; i++)
                        ком += комментарии[i] + "\n";
                else return "Ошибка: недопустимое значение смещения";
            return ком;
	}
	
	static string Список(int код, string имя, int смещение)
        {
	    if (!активныеПользователи.ContainsKey(код))
                return "Пользователь не авторизован";
            if (соцСеть.НайтиПользователя(имя) == null)
                return "Пользователь не найден";
            List<Сообщение> списокСообщений = null;
            string сообщения = "";
            foreach (Чат ч in активныеПользователи[код].ПолучитьЧаты())
                if (ч.ПолучитьПользователя2().ПолучитьИмя() == имя)
                    списокСообщений = ч.ПолучитьСообщения();
            if (списокСообщений == null)
                return "У вас нет диалога с этим пользователем";
            if (списокСообщений.Count > 0)
            {
                if (списокСообщений.Count > смещение + 10)
                    for (int i = списокСообщений.Count - смещение - 10; i < списокСообщений.Count - смещение; i++)
                        сообщения += списокСообщений[i].ПолучитьТекст() + "\n";
                else
                    if (смещение < списокСообщений.Count)
                    for (int i = 0; i < списокСообщений.Count - смещение; i++)
                        сообщения += списокСообщений[i].ПолучитьТекст() + "\n";
                else return "Ошибка: недопустимое значение смещения";
                return сообщения;
            }
            else return "Сообщений нет";
        }
    }
}

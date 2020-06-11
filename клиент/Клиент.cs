using System;
using System.IO;
using System.Collections.Generic;

namespace СоцСеть {
    class Клиент {
	public static void Main(string[] args)
	{
	    if (args.Length < 1) {
		Console.WriteLine("Клиент <путь>");
		return;
	    }
	    string путь = args[0];
	    Random r = new Random();
	    string pid = r.Next().ToString();
	    while (true) {
		string сообщ = Console.ReadLine();
		СоздатьБлокировку(путь + "/" + pid + ".запрос");
		StreamWriter sw = new StreamWriter(путь + "/" + pid + ".запрос");
		sw.WriteLine(сообщ);
		sw.Close();
		ОсвободитьБлокировку(путь + "/" + pid + ".запрос");
		StreamReader sr = null;
		while (sr == null)
		    try {
			ЖдатьБлокировку(путь + "/" + pid + ".запрос.ответ");
			sr = new StreamReader(путь + "/" + pid + ".запрос.ответ");
		    } catch (FileNotFoundException e) {
		    }
		string сообщение = "";
		string s;
		while ((s = sr.ReadLine()) != null)
		    сообщение += s;
		Console.WriteLine(сообщение);
		sr.Close();
		File.Delete(путь + "/" + pid + ".запрос");
		File.Delete(путь + "/" + pid + ".запрос.ответ");
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
    }
}

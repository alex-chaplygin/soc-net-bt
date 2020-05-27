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
		StreamWriter sw = new StreamWriter(путь + "/" + pid + ".запрос");
		sw.WriteLine(сообщ);
		sw.Close();
		StreamReader sr = null;
		while (sr == null)
		    try {
			sr = new StreamReader(путь + "/" + pid + ".запрос.ответ");
		    } catch (FileNotFoundException e) {
		    }
		Console.WriteLine(sr.ReadLine());
		sr.Close();
		File.Delete(путь + "/" + pid + ".запрос");
		File.Delete(путь + "/" + pid + ".запрос.ответ");
	    }
	}
    }
}

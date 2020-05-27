using System;
using System.IO;
using System.Collections.Generic;

namespace СоцСеть {
    class Тест {
	static СоциальнаяСеть соцСеть;
	
	public static void Main(string[] args)
	{
	    соцСеть = new СоциальнаяСеть();
	    Пользователь п1 = соцСеть.Регистрация("user", "pass");
	    Пользователь п2 = соцСеть.Регистрация("user2", "pass2");
	    Console.Write("Имя пользователя: ");
	    string имя = Console.ReadLine();
	    Console.Write("Пароль: ");
	    string пароль = Console.ReadLine();
	    п1 = соцСеть.Авторизация(имя, пароль);
	    if (п1 == null) {
	    	Console.WriteLine("Неверное имя пользователя или пароль");
	    	return;
	    }
	    соцСеть.НовыйЧат(имя, "user2");
	    п1.НаписатьСообщение("user2", "Привет!");
	    п2.НаписатьСообщение(имя, "Привет! " + имя);
	    List<Чат> чаты = п1.ПолучитьЧаты();
	    Console.WriteLine();
	    foreach (Сообщение с in чаты[0].ПолучитьСообщения()) {
		Console.Write(с.ПолучитьПользователя().ПолучитьИмя());
		Console.WriteLine(": " + с.ПолучитьТекст());
	    }
	}
    }
}

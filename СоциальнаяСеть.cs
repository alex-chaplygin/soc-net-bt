using System.Collections.Generic;
using System;

namespace СоцСеть {
    class СоциальнаяСеть {
	List<Пользователь> пользователи;
	List<Чат> чаты;
	List<Группа> группы;

	public СоциальнаяСеть() {
	    пользователи = new List<Пользователь>();
	    чаты = new List<Чат>();
	    группы = new List<Группа>();
	}

	public Пользователь Регистрация(string имя, string пароль)
	{
	    if (НайтиПользователя(имя) != null) return null;
	    Пользователь п = new Пользователь(имя, пароль);
	    пользователи.Add(п);
	    return п;
	}

	public Пользователь НайтиПользователя(string имя)
	{
	    foreach (Пользователь п in пользователи)
		if (п.ПолучитьИмя() == имя) return п;

	    return null;
	}

	public void УдалитьПользователя(string имя)
	{
	    Пользователь п = НайтиПользователя(имя);

	    if (п != null)
		пользователи.Remove(п);
	}

	public Пользователь Авторизация(string имя, string пароль)
	{
	    Пользователь п = НайтиПользователя(имя);

	    if (п == null) return null;
	    if (пароль == п.ПолучитьПароль()) return п;
	    else return null;
	}

	public Чат НовыйЧат(string имя1, string имя2)
	{
	    Пользователь п1 = НайтиПользователя(имя1);
	    Пользователь п2 = НайтиПользователя(имя2);
	    Чат ч;
	    if (п1 != null && п2 != null) {
		if (п1 == п2) return null;
		foreach (Чат ч2 in чаты)
		    if (ч2.ПолучитьПользователя1() == п1 && ч2.ПолучитьПользователя2() == п2)
			return ч2;
		ч = new Чат(п1, п2);
		чаты.Add(ч);
		п1.ПолучитьЧаты().Add(ч);
		п2.ПолучитьЧаты().Add(ч);
		return ч;
	    } else
		System.Console.WriteLine("Не найдены пользователи " + имя1 + " " + имя2);
	    return null;
	}
	
	public List<Пользователь> ВернутьПользователей()
        {
            return пользователи;
        }
	
        public List<Чат> ПолучитьЧаты()
        {
            return чаты;
	}

	public Группа НайтиГруппу(string name)
        {
            foreach (Группа г in группы)
                if (г.ПолучитьНазвание() == name)
                    return г;
            return null;
        }
	
        public void ДобавитьГруппу(string name)
        {
            if (НайтиГруппу(name) != null)
                return;
            группы.Add(new Группа(name));
        }
	
        public void УдалитьГруппу(string name)
        {
            группы.Remove(НайтиГруппу(name));
        }
	
        public void ПодписатьсяНаГруппу(Пользователь п, string name)
        {
            if (НайтиГруппу(name) == null)
                return;
            НайтиГруппу(name).Подписаться(п);
        }

	public List<Группа> ПолучитьГруппы()
        {
            return группы;
        }
    }  
}

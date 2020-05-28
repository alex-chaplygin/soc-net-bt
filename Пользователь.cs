using System.Collections.Generic;
using System.Drawing;

namespace СоцСеть {
    class Пользователь {
	string имя;
	string пароль;
	Стена стена;
	List<Чат> чаты;

	public Пользователь(string имя, string пароль)
	{
	    this.имя = имя;
	    this.пароль = пароль;
	    стена = new Стена();
	    чаты = new List<Чат>();
	}

	public string ПолучитьИмя()
	{
	    return имя;
	}

	public string ПолучитьПароль()
	{
	    return пароль;
	}

	public Стена ПолучитьСтену()
	{
	    return стена;
	}

	public List<Чат> ПолучитьЧаты()
	{
	    return чаты;
	}

	public void Опубликовать(string текст)
	{
	    Сообщение сообщение;

	    сообщение = new Сообщение(this);
	    сообщение.ЗадатьТекст(текст);
	    стена.Опубликовать(сообщение);
	}

	public void ПрикрепитьИзображение(Image и)
	{
	    Сообщение с;
	    List<Сообщение> список;

	    список = стена.ПолучитьСообщения();
	    с = список[список.Count - 1];
	    с.ДобавитьИзображение(и);
	}

	public void УдалитьПубликацию()
	{
	    List<Сообщение> список;

	    список = стена.ПолучитьСообщения();
	    список.RemoveAt(список.Count - 1);
	}

	public void НаписатьСообщение(string кому, string текст)
	{
	    Чат ч = null;
	    foreach (Чат ч2 in чаты)
		if (ч2.ПолучитьПользователя1().ПолучитьИмя() == кому ||
		    ч2.ПолучитьПользователя2().ПолучитьИмя() == кому) {
		    ч = ч2;
		    break;
		}
	    if (ч == null) return;
	    Сообщение с = new Сообщение(this);
	    с.ЗадатьТекст(текст);
	    ч.ДобавитьСообщение(с);
	}
    }
}

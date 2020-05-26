using System.Drawing;

namespace СоцСеть {
    class Сообщение {
	Пользователь пользователь;
	string текст;
	
	public Сообщение(Пользователь п)
	{
	    пользователь = п;
	}
	
	public Пользователь ПолучитьПользователя()
	{
	    return пользователь;
	}
	
	public void ЗадатьТекст(string т)
	{
	    текст = т;
	}
	
	public string ПолучитьТекст()
	{
	    return текст;
	}
	
	public void ДобавитьИзображение(Image i)
	{
	}
    }
}

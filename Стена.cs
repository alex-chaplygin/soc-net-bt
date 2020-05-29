using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СоцСеть
{
    class Стена
    {
        List<Сообщение> публикации;
	
        public Стена()
	{
            публикации = new List<Сообщение>();
	}
	
        public void Опубликовать(Сообщение публикация)
        {
            публикации.Add(публикация);
        }
	
        public void Удалить (int номер)
        {
            публикации.RemoveAt(номер);
        }
	
        public void Редактировать(int номер, Сообщение публикация)
        {
            публикации.RemoveAt(номер);
            публикации.Insert(номер, публикация);
        }
	
	public List<Сообщение> ПолучитьПубликации()
	{
	    return публикации;
	}
    }
}

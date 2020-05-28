using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СоцСеть
{
    class Стена
    {
        public List<Сообщение> сообщения;
        public Стена ()
            {
            сообщения = new List<Сообщение>();
            }
        public void Опубликовать( Сообщение сообщение)
        {
            сообщения.Add(сообщение);
        }
        public void Удалить (int номер)
        {
            сообщения.RemoveAt(номер);
        }
        public void Редактировать(int номер, Сообщение новоеСообщение)
        {
            сообщения.RemoveAt(номер);
            сообщения.Insert(номер, новоеСообщение);
        }
	public List<Сообщение> ПолучитьСообщения()
	{
	    return сообщения;
	}
    }
}

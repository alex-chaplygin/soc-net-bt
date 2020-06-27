using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace СоцСеть
{
    class Сообщение
    {
        private Пользователь пользователь;
        private string текст;
        private List<Image> изображения;
	private List<string> комментарии;
	private DateTime время;

        public Сообщение(Пользователь п)
        {
            пользователь = п;
            текст = "";
	    изображения = new List<Image>();
	    комментарии = new List<string>();
	    время = DateTime.Now;
        }

	public Сообщение(Пользователь п, string с, string time = "")
        {
            пользователь = п;
            текст = с;
            изображения = new List<Image>();
            комментарии = new List<string>();
            if (time == "")
                this.время = DateTime.Now;
            else
                this.время = DateTime.Parse(time);
        }

	public string ПолучитьВремя()
        {
	    string time = время.ToString();
            time = time.Replace(':', ',');
            return time;
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
	
        public void ДобавитьИзображение(Image и)
        {
            изображения.Add(и);
        }
	
        public void УдалитьИзображение(int номер)
        {
            изображения.RemoveAt(номер);
        }
	
        public List<Image> ПолучитьИзображения()
        {
            return изображения;
        }

	public void ДобавитьКомментарий(string text)
        {
            комментарии.Add(text);
        }
	
        public List<string> ПолучитьКомментарии()
        {
            return комментарии;
        }
    }
}

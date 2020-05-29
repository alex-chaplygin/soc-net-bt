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
        private List<Image> изображения = new List<Image>();

        public Сообщение(Пользователь п)
        {
            пользователь = п;
            текст = "";
        }
        public Сообщение(Пользователь п, string с)
        {
            пользователь = п;
            текст = с;
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace СоцСеть
{
    class Сообщение
    {
        private Пользователь User;
        private string Text;
        private List<Image> Images = new List<Image>();

        public Сообщение(Пользователь п)
        {
            User = п;
            Text = "";
        }
        public Сообщение(Пользователь п, string с)
        {
            User = п;
            Text = с;
        }
        public Пользователь ПолучитьПользователя()
        {
            return User;
        }
        public void ЗадатьТекст(string text)
        {
            Text = text;
        }
        public string ПолучитьТекст()
        {
            return Text;
        }
        public void ДобавитьИзображение(Image img)
        {
            Images.Add(img);
        }
        public void УдалитьИзображение(int num)
        {
            Images.RemoveAt(num);
        }
        public List<Image> ПолучитьИзображения()
        {
            return Images;
        }
    }
}

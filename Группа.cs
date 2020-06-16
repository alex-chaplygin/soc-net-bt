using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СоцСеть
{
    class Группа
    {
        string name;
        List<Пользователь> subscribers;
        public Группа(string name)
        {
            this.name = name;
        }
        public string ПолучитьНазвание()
        {
            return name;
        }
        public List<Пользователь> ПолучитьУчастников()
        {
            return subscribers;
        }
        public void ИзменитьНазвание(string name)
        {
            this.name = name;
        }
        public void Подписаться(Пользователь п)
        {
            subscribers.Add(п);
        }
    }
}

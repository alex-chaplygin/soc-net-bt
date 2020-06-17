using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СоцСеть
{
    class Группа
    {
        string название;
        List<Пользователь> участники;
	
        public Группа(string название)
        {
            this.название = название;
        }
	
        public string ПолучитьНазвание()
        {
            return название;
        }
	
        public List<Пользователь> ПолучитьУчастников()
        {
            return участники;
        }
	
        public void ИзменитьНазвание(string название)
        {
            this.название = название;
        }
	
        public void Подписаться(Пользователь п)
        {
            subscribers.Add(п);
        }
    }
}

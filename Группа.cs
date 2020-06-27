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
	Стена стена;
	
        public Группа(string название)
        {
            this.название = название;
	    стена = new Стена();
	    участники = new List<Пользователь>();
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
            участники.Add(п);
        }

	public Стена ПолучитьСтену()
        {
            return стена;
        }
    }
}

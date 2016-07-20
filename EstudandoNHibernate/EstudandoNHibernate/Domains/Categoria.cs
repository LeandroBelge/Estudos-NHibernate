using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudandoNHibernate.Domains
{
    public class Categoria
    {
        public virtual int Id {get; set;}
        public virtual string Descricao { get; set; }
        public virtual ISet<Pessoa> Pessoas { get; set; }
    }
}

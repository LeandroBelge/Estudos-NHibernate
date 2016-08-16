using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudandoNHibernate.Domains
{
    public class Pessoa
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual ISet<Categoria> Categorias { get; set; }
    }
}

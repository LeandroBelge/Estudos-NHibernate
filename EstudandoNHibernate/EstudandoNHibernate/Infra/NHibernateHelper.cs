using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EstudandoNHibernate.Infra
{
    public class NHibernateHelper
    {
        private Configuration configuracao()
        {
            Configuration cfg  = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(Assembly.GetExecutingAssembly());
            return cfg;
        }
    }
}

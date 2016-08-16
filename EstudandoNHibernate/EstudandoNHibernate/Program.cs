using EstudandoNHibernate.Domains;
using EstudandoNHibernate.Infra;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EstudandoNHibernate
{
    class Program
    {
        static void Main(string[] args)
        {
            NHibernateHelper helper = new NHibernateHelper();
            Configuration cfg = helper.configuracao();
            SchemaUpdate update = new SchemaUpdate(cfg);
            update.Execute(true, true);
            Console.ReadLine();
        }
    }
}

using EstudandoNHibernate.Infra;
using NHibernate;
using NHibernate.Cfg;
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
            Configuration configuracao = helper.configuracao();
            try
            {
                new SchemaUpdate(configuracao).Execute(true, true);
                Console.WriteLine("Entidade criada no BD");
            }
            catch
            {
                Console.WriteLine("Falha ao criar a entidade no BD");
            }
            Console.ReadLine();
        }
    }
}

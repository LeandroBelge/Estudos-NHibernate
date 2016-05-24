using NHibernate;
using NHibernate.Cfg;
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
            try
            {
                Configuration configuracao = new Configuration();
                configuracao.Configure();
                configuracao.AddAssembly(Assembly.GetExecutingAssembly());
                ISession sessao = configuracao.BuildSessionFactory().OpenSession();
                if (sessao != null)
                {
                    Console.WriteLine("A conexão funcionou");
                    sessao.Close();
                }
                else Console.WriteLine("A conexão falhou");
            }
            catch
            {
                Console.WriteLine("A conexão falhou");
            }
            Console.Read();
        }
    }
}

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
            ISession conexao1 = getConexao();
            ISession conexao2 = getConexao();
            try
            {
                Pessoa pessoa1 = conexao1.Get<Pessoa>(9);
                Pessoa pessoa2 = conexao2.Get<Pessoa>(9);

                
                Console.ReadLine();
            }
            finally
            {
                conexao1.Close();
                conexao2.Close();
            }   
        }

        static private ISession getConexao()
        {
            //Recupera minha configuração do NHibernate
            Configuration configuracao = new Configuration();
            configuracao.Configure();
            configuracao.AddAssembly(Assembly.GetExecutingAssembly());

            return  configuracao.BuildSessionFactory().OpenSession();
        }
    }
}

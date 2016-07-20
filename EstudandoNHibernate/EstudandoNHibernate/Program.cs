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
            ISession conexao = getConexao();
            try
            {
                ICriteria criteria = conexao.CreateCriteria<Pessoa>();
                criteria.Add(Restrictions.Eq("Categoria.Id", 1));
                criteria.Add(Restrictions.Le("Id", 9));
                IList<Pessoa> pessoas = criteria.List<Pessoa>();

                string Nomes = String.Empty;
                foreach (var item in pessoas)
                {
                    Nomes += item.Nome + "\n";
                }

                Console.WriteLine(Nomes);
                Console.ReadLine();
            }
            finally
            {
                conexao.Close();
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

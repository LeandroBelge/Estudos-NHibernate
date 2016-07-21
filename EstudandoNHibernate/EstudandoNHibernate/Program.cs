﻿using EstudandoNHibernate.Domains;
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
                string hql = "from Pessoa where nome like('%L%') order by Nome";
                IQuery query = conexao.CreateQuery(hql);
                IList<Pessoa> pessoas = query.List<Pessoa>();
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

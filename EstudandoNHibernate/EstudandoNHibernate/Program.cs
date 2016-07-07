using EstudandoNHibernate.Domains;
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
            //Recupera minha configuração do NHibernate
            Configuration configuracao = new Configuration();
            configuracao.Configure();
            configuracao.AddAssembly(Assembly.GetExecutingAssembly());
            
            //Instanciar e abrir minha conexão
            ISession session = configuracao.BuildSessionFactory().OpenSession();

            //iniciando uma transação que irá gravar minha alteração no BD.
            ITransaction transacao = session.BeginTransaction();

            //Instanciar uma pessoa e atribuir um nome a ela.
            Pessoa pessoa = new Pessoa();
            pessoa.Nome = "Primeira pessoa";

            //Pedir a minha session para guardar a pessoa no BD.
            session.SaveOrUpdate(pessoa);

            //Confirmar minha transação.
            transacao.Commit();

            //Recuperando uma entidade pelo ID
            session.Get<Pessoa>(pessoa.Id);

            //Iniciando nova transação
            ITransaction novaTransacao = session.BeginTransaction();

            //Removendo minha entidade do BD.
            session.Delete(pessoa);

            //Confirmando transação
            novaTransacao.Commit();

            //Fechar minha conexão
            session.Close();
        }
    }
}

using blog_app_mvc.Models;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace blog_app_mvc.App_Start
{
    public class FluentNHibernateConfig
    {
        public static ISessionFactory CreateSessionFactory()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql7
                    .ConnectionString(@"Data Source=localhost;Initial Catalog=BlogAppMvc;Integrated Security=True")
                    .ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<PostMap>())

                //.ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                //.ExposeConfiguration(cfg => new SchemaExport(cfg).Drop(true, true))
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true))
                .BuildSessionFactory();

            return sessionFactory;
        }
    }
}
#region License
// Copyright 2009 Josh Close
// This file is a part of WcfNhibernateNinject and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using System.Collections.Generic;
using FluentNHibernate.Cfg;
using NHibernate;

namespace Wnn.Business
{
	public static class SessionFactoryFactory
	{
		private static readonly object locker = new object();
		private static readonly Dictionary<string, ISessionFactory> sessionFactories = new Dictionary<string, ISessionFactory>();

		public static ISessionFactory GetSessionFactory( string connectionStringKey )
		{
			ISessionFactory sessionFactory;
			sessionFactories.TryGetValue( connectionStringKey, out sessionFactory );

			// Double check locking is used here because
			// WCF could have many instances accessing this
			// code at the same time.
			if( sessionFactory == null )
			{
				lock( locker )
				{
					sessionFactories.TryGetValue( connectionStringKey, out sessionFactory );
					if( sessionFactory == null )
					{
						sessionFactory = Fluently.Configure()
							.Database(
							FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql2005.ConnectionString(
								c => c.FromConnectionStringWithKey( connectionStringKey ) )
								.ProxyFactoryFactory( "NHibernate.ByteCode.LinFu.ProxyFactoryFactory, NHibernate.ByteCode.LinFu" ) )
							.Mappings( m => m.FluentMappings.AddFromAssembly( typeof( SessionFactoryFactory ).Assembly ) )
							.ExposeConfiguration( cfg => cfg.SetProperty( "generate_statistics", "true" ) )
							.ExposeConfiguration( cfg => cfg.SetProperty( "adonet.batch_size", "10" ) )
							.BuildSessionFactory();

						sessionFactories[connectionStringKey] = sessionFactory;
					}
				}
			}

			return sessionFactory;
		}
	}
}

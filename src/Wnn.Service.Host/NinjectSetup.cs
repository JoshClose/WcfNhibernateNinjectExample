#region License
// Copyright 2009 Josh Close
// This file is a part of WcfNhibernateNinject and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using NHibernate;
using Ninject.Modules;
using Wnn.Business;

namespace Wnn.Service.Host
{
	public class NinjectSetup : NinjectModule
	{
		private readonly string connectionStringKey;

		public NinjectSetup( string connectionStringKey )
		{
			this.connectionStringKey = connectionStringKey;
		}

		public override void Load()
		{
			Bind<ISession>()
				.ToMethod( ctx => SessionFactoryFactory.GetSessionFactory( connectionStringKey ).OpenSession() )
				.InSingletonScope();

			Bind<SessionManager>()
				.ToSelf()
				.InSingletonScope();
		}
	}
}

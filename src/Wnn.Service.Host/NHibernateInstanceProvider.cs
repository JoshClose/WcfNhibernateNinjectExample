#region License
// Copyright 2009 Josh Close
// This file is a part of WcfNhibernateNinject and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using System;
using System.Runtime.Remoting.Messaging;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using NHibernate;
using Ninject;
using Wnn.Business;

namespace Wnn.Service.Host
{
	public class NHibernateInstanceProvider : IInstanceProvider
	{
		private const string sessionKey = "ThreadSession";
		private const string transactionKey = "ThreadTransaction";
		private readonly Type serviceType;

		private static SessionManager SessionManager
		{
			get { return CallContext.GetData( sessionKey ) as SessionManager; }
			set { CallContext.SetData( sessionKey, value ); }
		}

		private static ITransaction Transaction
		{
			get { return CallContext.GetData( transactionKey ) as ITransaction; }
			set { CallContext.SetData( transactionKey, value ); }
		}

		public NHibernateInstanceProvider( Type serviceType )
		{
			this.serviceType = serviceType;
		}

		public object GetInstance( InstanceContext instanceContext )
		{
			return GetInstance( instanceContext, null );
		}

		public object GetInstance( InstanceContext instanceContext, Message message )
		{
			var connectionStringKey = GetConnectionStringKey( serviceType );

			var kernel = new StandardKernel( new NinjectSetup( connectionStringKey ) );

			SessionManager = kernel.Get<SessionManager>();
			Transaction = SessionManager.BeginTransaction();

			var instance = kernel.Get( serviceType );

			return instance;
		}

		public void ReleaseInstance( InstanceContext instanceContext, object instance )
		{
			try
			{
				Transaction.Commit();
			}
			catch
			{
				Transaction.Rollback();
			}
			finally
			{
				SessionManager.Close();
				SessionManager.Dispose();
			}
		}

		private static string GetConnectionStringKey( Type serviceType )
		{
			// All of our database connections should
			// go here. We could also put all of these types
			// into a config file and load them dynamically.
			string connectionStringKey;
			if( serviceType == typeof( BlogService ) )
			{
				connectionStringKey = "Dashboard";
			}
			else
			{
				throw new Exception( "Service type '{0}' does not match any database connection." );
			}
			return connectionStringKey;
		}
	}
}

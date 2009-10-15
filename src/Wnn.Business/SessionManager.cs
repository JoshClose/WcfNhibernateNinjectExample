#region License
// Copyright 2009 Josh Close
// This file is a part of WcfNhibernateNinject and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using System;
using System.Data;
using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace Wnn.Business
{
	public class SessionManager
	{
		private readonly ISession session;

		public SessionManager( ISession session )
		{
			if( session == null )
			{
				throw new ArgumentNullException( "session" );
			}

			this.session = session;
		}

		public virtual IQueryable<T> Linq<T>()
		{
			return session.Linq<T>();
		}

		public virtual T Get<T>( int id )
		{
			return session.Get<T>( id );
		}

		public virtual ISQLQuery CreateSqlQuery( string queryString )
		{
			return session.CreateSQLQuery( queryString );
		}

		public virtual void SaveOrUpdate( object obj )
		{
			session.SaveOrUpdate( obj );
		}

		public virtual void Delete( object obj )
		{
			session.Delete( obj );
		}

		public virtual ITransaction BeginTransaction()
		{
			return session.BeginTransaction();
		}

		public virtual IDbConnection Close()
		{
			return session.Close();
		}

		public virtual void Dispose()
		{
			session.Dispose();
		}
	}
}

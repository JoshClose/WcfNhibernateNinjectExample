#region License
// Copyright 2009 Josh Close
// This file is a part of WcfNhibernateNinject and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using System.Collections.Generic;
using System.Linq;

namespace Wnn.Business.Repositories
{
	public abstract class RepositoryBase<T>
	{
		protected SessionManager SessionManager { get; set; }

		protected RepositoryBase( SessionManager sessionManager )
		{
			SessionManager = sessionManager;
		}

		public T Get( int id )
		{
			return SessionManager.Get<T>( id );
		}

		public List<T> GetAll()
		{
			return SessionManager.Linq<T>().ToList();
		}

		public void SaveOrUpdate( T obj )
		{
			SessionManager.SaveOrUpdate( obj );
		}

		public void Delete( T obj )
		{
			SessionManager.Delete( obj );
		}
	}
}

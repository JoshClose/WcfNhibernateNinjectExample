#region License
// Copyright 2009 Josh Close
// This file is a part of WcfNhibernateNinject and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using System.Linq;
using Wnn.Business.Objects;

namespace Wnn.Business.Repositories
{
	public class UserRepository : RepositoryBase<User>
	{
		public UserRepository( SessionManager sessionManager ) : base( sessionManager ){}

		public User GetByUserNameAndPassword( string userName, string password )
		{
			return ( from u in SessionManager.Linq<User>()
			         where u.UserName == userName && password == u.Password
			         select u ).SingleOrDefault();
		}
	}
}

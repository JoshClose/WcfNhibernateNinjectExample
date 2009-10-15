#region License
// Copyright 2009 Josh Close
// This file is a part of WcfNhibernateNinject and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using System.Collections.Generic;
using System.Linq;
using Wnn.Business.Objects;

namespace Wnn.Business.Repositories
{
	public class PostRepository : RepositoryBase<Post>
	{
		public PostRepository( SessionManager sessionManager ) : base( sessionManager ){}

		public List<Post> GetAllForUser( string userName )
		{
			return ( from p in SessionManager.Linq<Post>()
			         where p.Author.UserName == userName
			         select p ).ToList();
		}
	}
}

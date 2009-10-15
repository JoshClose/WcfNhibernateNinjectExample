#region License
// Copyright 2009 Josh Close
// This file is a part of WcfNhibernateNinject and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using System.Collections.Generic;
using System.ServiceModel;
using Wnn.Service.Contract.DataContracts;

namespace Wnn.Service.Contract.ServiceContracts
{
	[ServiceContract]
	public interface IBlogService
	{
		[OperationContract]
		Post GetPostById( int id );
		[OperationContract]
		User GetUserById( int id );
		[OperationContract]
		User GetUserByUserNameAndPassword( string userName, string password );
		[OperationContract]
		List<Post> GetPosts();
		[OperationContract]
		List<Post> GetPostsFromAuthor( string userName );
	}
}

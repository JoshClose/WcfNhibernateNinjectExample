#region License
// Copyright 2009 Josh Close
// This file is a part of WcfNhibernateNinject and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Wnn.Business.Repositories;
using Wnn.Service.Contract.DataContracts;
using Wnn.Service.Contract.ServiceContracts;

namespace Wnn.Service
{
	[ServiceBehavior( InstanceContextMode = InstanceContextMode.PerCall )]
	public class BlogService : IBlogService
	{
		private readonly UserRepository userRepository;
		private readonly PostRepository postRepository;
		private readonly TagRepository tagRepository;

		public BlogService( UserRepository userRepository, PostRepository postRepository, TagRepository tagRepository )
		{
			this.userRepository = userRepository;
			this.postRepository = postRepository;
			this.tagRepository = tagRepository;
		}

		public Post GetPostById( int id )
		{
			return ConvertPost( postRepository.Get( id ) );
		}

		public User GetUserById( int id )
		{
			return ConvertUser( userRepository.Get( id ) );
		}

		public User GetUserByUserNameAndPassword( string userName, string password )
		{
			return ConvertUser( userRepository.GetByUserNameAndPassword( userName, password ) );
		}

		public List<Post> GetPosts()
		{
			return ( from p in postRepository.GetAll()
			         select ConvertPost( p ) ).ToList();
		}

		public List<Post> GetPostsFromAuthor( string userName )
		{
			return ( from p in postRepository.GetAllForUser( userName )
			         select ConvertPost( p ) ).ToList();
		}

		private static User ConvertUser( Business.Objects.User userData )
		{
			User user = null;
			if( userData != null )
			{
				user = new User
				{
					Email = userData.Email,
					FirstName = userData.FirstName,
					Id = userData.Id,
					LastName = userData.LastName,
					UserName = userData.UserName,
				};
			}
			return user;
		}

		private static Post ConvertPost( Business.Objects.Post postData )
		{
			Post post = null;
			if( postData != null )
			{
				post = new Post
				{
					Author = postData.Author.UserName,
					Content = postData.Content,
					Created = postData.Created,
					Id = postData.Id,
					Title = postData.Title,
					Tags = ( from t in postData.Tags
							 select t.Name ).ToList()
				};
			}
			return post;
		}
	}
}

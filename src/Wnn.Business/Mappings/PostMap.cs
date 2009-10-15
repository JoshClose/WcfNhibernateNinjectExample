#region License
// Copyright 2009 Josh Close
// This file is a part of WcfNhibernateNinject and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using FluentNHibernate.Mapping;
using Wnn.Business.Objects;

namespace Wnn.Business.Mappings
{
	public class PostMap : ClassMap<Post>
	{
		public PostMap()
		{
			SetupMapping();
		}

		private void SetupMapping()
		{
			Table( "Posts" );
			Id( m => m.Id );
			Map( m => m.Content );
			Map( m => m.Title );
			References( m => m.Author, "UserId" );
			HasMany( m => m.Tags )
				.Inverse()
				.Cascade.AllDeleteOrphan()
				.KeyColumns.Add( "PostId" )
				.Fetch.Subselect();
		}
	}
}

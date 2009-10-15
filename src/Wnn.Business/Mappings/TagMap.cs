#region License
// Copyright 2009 Josh Close
// This file is a part of WcfNhibernateNinject and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using FluentNHibernate.Mapping;
using Wnn.Business.Objects;

namespace Wnn.Business.Mappings
{
	public class TagMap : ClassMap<Tag>
	{
		public TagMap()
		{
			SetupMapping();
		}

		private void SetupMapping()
		{
			Table( "Tags" );
			Id( m => m.Id );
			Map( m => m.Name );
			References( m => m.Post, "PostId" );
		}
	}
}

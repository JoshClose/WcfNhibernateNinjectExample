#region License
// Copyright 2009 Josh Close
// This file is a part of WcfNhibernateNinject and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using FluentNHibernate.Mapping;
using Wnn.Business.Objects;

namespace Wnn.Business.Mappings
{
	public class UserMap : ClassMap<User>
	{
		public UserMap()
		{
			SetupMapping();
		}

		private void SetupMapping()
		{
			Table( "Users" );
			Id( m => m.Id );
			Map( m => m.Email );
			Map( m => m.FirstName );
			Map( m => m.LastName );
			Map( m => m.Password ).Access.CamelCaseField();
			Map( m => m.UserName );
		}
	}
}

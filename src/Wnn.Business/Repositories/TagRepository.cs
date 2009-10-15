﻿#region License
// Copyright 2009 Josh Close
// This file is a part of WcfNhibernateNinject and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using Wnn.Business.Objects;

namespace Wnn.Business.Repositories
{
	public class TagRepository : RepositoryBase<Tag>
	{
		public TagRepository( SessionManager sessionManager ) : base( sessionManager ){}
	}
}

#region License
// Copyright 2009 Josh Close
// This file is a part of WcfNhibernateNinject and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using System;
using System.Collections.Generic;

namespace Wnn.Business.Objects
{
	public class Post
	{
		public virtual int Id { get; protected set; }
		public virtual string Title { get; set; }
		public virtual string Content { get; set; }
		public virtual DateTime Created { get; set; }
		public virtual User Author { get; set; }
		public virtual List<Tag> Tags { get; set; }

		public virtual void AddTag( Tag tag )
		{
			tag.Post = this;
			Tags.Add( tag );
		}
	}
}

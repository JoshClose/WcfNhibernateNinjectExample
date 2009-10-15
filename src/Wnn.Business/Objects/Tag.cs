#region License
// Copyright 2009 Josh Close
// This file is a part of WcfNhibernateNinject and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
namespace Wnn.Business.Objects
{
	public class Tag
	{
		public virtual int Id { get; protected set; }
		public virtual string Name { get; set; }
		public virtual Post Post { get; set; }
	}
}

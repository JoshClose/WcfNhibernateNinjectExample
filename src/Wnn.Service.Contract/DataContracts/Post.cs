#region License
// Copyright 2009 Josh Close
// This file is a part of WcfNhibernateNinject and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Wnn.Service.Contract.DataContracts
{
	[DataContract]
	public class Post
	{
		[DataMember]
		public int Id { get; set; }
		[DataMember]
		public string Title { get; set; }
		[DataMember]
		public string Content { get; set; }
		[DataMember]
		public DateTime Created { get; set; }
		[DataMember]
		public string Author { get; set; }
		[DataMember]
		public List<string> Tags { get; set; }
	}
}

#region License
// Copyright 2009 Josh Close
// This file is a part of WcfNhibernateNinject and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using System.Runtime.Serialization;

namespace Wnn.Service.Contract.DataContracts
{
	[DataContract]
	public class User
	{
		[DataMember]
		public int Id { get; set; }
		[DataMember]
		public string UserName { get; set; }
		[DataMember]
		public string Email { get; set; }
		[DataMember]
		public string FirstName { get; set; }
		[DataMember]
		public string LastName { get; set; }
	}
}

#region License
// Copyright 2009 Josh Close
// This file is a part of WcfNhibernateNinject and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using System;
using System.Security.Cryptography;
using System.Text;

namespace Wnn.Business.Objects
{
	public class User
	{
		private string password;

		public virtual int Id { get; protected set; }
		public virtual string UserName { get; set; }
		public virtual string Email { get; set; }
		public virtual string Password
		{
			get { return password; }
			set
			{
				var md5 = MD5.Create();
				var passwordBytes = Encoding.UTF8.GetBytes( value );
				md5.ComputeHash( passwordBytes );
				password = Convert.ToBase64String( md5.Hash );
			}
		}

		public virtual string FirstName { get; set; }
		public virtual string LastName { get; set; }
	}
}

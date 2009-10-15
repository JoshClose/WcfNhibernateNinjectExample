#region License
// Copyright 2009 Josh Close
// This file is a part of WcfNhibernateNinject and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using System;
using System.ServiceModel.Configuration;

namespace Wnn.Service.Host
{
	public class NHibernateBehaviorExtensionElement : BehaviorExtensionElement
	{
		protected override object CreateBehavior()
		{
			return new NHibernateServiceBehavior();
		}

		public override Type BehaviorType
		{
			get { return typeof( NHibernateServiceBehavior ); }
		}
	}
}

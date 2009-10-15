#region License
// Copyright 2009 Josh Close
// This file is a part of WcfNhibernateNinject and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using System.Collections.Generic;
using System.ServiceModel;

namespace Wnn.Service.Host
{
	public class ServiceHostEngine
	{
		private readonly List<ServiceHost> serviceHosts = new List<ServiceHost>();

		public ServiceHostEngine()
		{
			// We can have multiple services listed here.
			// We could actually have a list of services in a config
			// file that is dynamically loaded here also.
			serviceHosts.Add( new ServiceHost( typeof( BlogService ) ) );
		}

		public void Start()
		{
			foreach( var serviceHost in serviceHosts )
			{
				serviceHost.Open();
			}
		}

		public void Stop()
		{
			foreach( var serviceHost in serviceHosts )
			{
				serviceHost.Close();
			}
		}
	}
}

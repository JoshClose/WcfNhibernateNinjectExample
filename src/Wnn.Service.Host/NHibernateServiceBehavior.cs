#region License
// Copyright 2009 Josh Close
// This file is a part of WcfNhibernateNinject and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Wnn.Service.Host
{
	public class NHibernateServiceBehavior : Attribute, IServiceBehavior
	{
		public void Validate( ServiceDescription serviceDescription, ServiceHostBase serviceHostBase )
		{
		}

		public void AddBindingParameters( ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters )
		{
		}

		public void ApplyDispatchBehavior( ServiceDescription serviceDescription, ServiceHostBase serviceHostBase )
		{
			foreach( var channelDispatcherBase in serviceHostBase.ChannelDispatchers )
			{
				var channelDispatcher = channelDispatcherBase as ChannelDispatcher;
				if( channelDispatcher == null )
				{
					continue;
				}

				foreach( var ed in channelDispatcher.Endpoints )
				{
					ed.DispatchRuntime.InstanceProvider = new NHibernateInstanceProvider( serviceDescription.ServiceType );
				}
			}
		}
	}
}

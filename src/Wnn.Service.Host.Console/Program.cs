#region License
// Copyright 2009 Josh Close
// This file is a part of WcfNhibernateNinject and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
namespace Wnn.Service.Host.Console
{
	class Program
	{
		static void Main( string[] args )
		{
			var service = new ServiceHostEngine();
			service.Start();
			System.Console.WriteLine( "Press any key to stop the services" );
			System.Console.ReadKey();
		}
	}
}

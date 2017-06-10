using System;
using System.Collections.Generic;
using System.Text;

namespace ParnerNet.Integrators.Scala
{
	public class ForecastProcessor : IProcessor
	{
		#region IProcessor Members

		public string Name
		{
			get { return "Forecast Processor"; }
		}

		public bool Execute( out string errors )
		{
			throw new Exception( "The method or operation is not implemented." );
		}

		#endregion
	}
}

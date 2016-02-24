using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trilobyte
{
	public class EntityAppearedEventArgs
	{
		public bool Cancel { get; set; }

		public EntityAppearedEventArgs()
		{
			Cancel = false;
		}
	}
}

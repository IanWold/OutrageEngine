using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trilobyte
{
	class EmptyEntity : Entity
	{
		public EmptyEntity(char c, int x, int y)
		{
			Display = c;
			X = x;
			Y = y;
		}
	}
}

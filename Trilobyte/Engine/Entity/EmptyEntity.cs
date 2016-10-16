using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outrage
{
	class EmptyEntity : Entity
	{
		public EmptyEntity(char c, Vector position)
		{
			Display = c;
			Position = position;
		}
	}
}

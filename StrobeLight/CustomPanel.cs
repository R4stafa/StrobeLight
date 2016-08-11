using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StrobeLight
{
	public class CustomPanel : Panel
	{
		public CustomPanel()
		{
			
		}

		public void setDoubleBuffered(bool enabled)
		{
			DoubleBuffered = enabled;
		}


	}
}

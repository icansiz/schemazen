using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchemaZen.Library.Models
{
	public abstract class BaseDBObject : INameable, IScriptable
	{
		public string Name { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime ModifyDate { get; set; }
		public abstract string ScriptCreate();
		
		public ExtendedPropertyList ExtendedProperties = new ExtendedPropertyList();

		public string HeaderScriptCreate()
		{
			var text = new StringBuilder();
			text.AppendLine($"/**********************************************************************************");
			text.AppendLine($"*   Object Create Date : {CreateDate}");
			text.AppendLine($"*   Object Modify Date : {ModifyDate}");
			text.AppendLine($"***********************************************************************************/");
			text.AppendLine("");
			return text.ToString();
		}

	}
}

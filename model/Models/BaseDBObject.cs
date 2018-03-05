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
		public string DatabaseName { get; set; }
		public abstract string ScriptCreate();
		
		public ExtendedPropertyList ExtendedProperties = new ExtendedPropertyList();
		public string ModifyHostName { get; set; }
		public string ModifyUserName { get; set; }

		public string HeaderScriptCreate(string owner = null)
		{

			string objectName = string.IsNullOrEmpty(owner) ? string.Empty : $"[{owner}].";
			objectName += $"[{Name}]";
			var text = new StringBuilder();
			text.AppendLine($"/**********************************************************************************");
			text.AppendLine($"        Object Name      : {objectName}");  
			text.AppendLine($"        Create Date      : {String.Format("{0:u}", CreateDate)}"); //  "2008-03-09 16:05:07Z" 
			text.AppendLine($"        Modify Date      : {String.Format("{0:u}", ModifyDate)}");
			if (!string.IsNullOrEmpty(ModifyHostName))
				text.AppendLine($"        Modify Host Name : {ModifyHostName}");
			if (!string.IsNullOrEmpty(ModifyUserName))
				text.AppendLine($"        Modify User Name : {ModifyUserName}");
			text.AppendLine($"***********************************************************************************/");
			text.AppendLine("");
			if (!string.IsNullOrEmpty(DatabaseName))
			{
				text.AppendLine($"USE [{DatabaseName}]");
				text.AppendLine("GO");
				text.AppendLine("");
			}
			return text.ToString();
		}

	}
}

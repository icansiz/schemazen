using System;
using System.Text;

namespace SchemaZen.Library.Models {
	public class ExtendedProperty {
		public string Name { get; set; }
		private string _value = "";
		public string Value
		{
			get { return CleansingString(_value); }
			set { _value = value;  }
		}
		public string Level0Type { get; set; }
		public string Level0Name { get; set; }
		public string Level1Type { get; set; }
		public string Level1Name { get; set; }
		public string Level2Type { get; set; }
		public string Level2Name { get; set; }

		public ExtendedProperty() { }

		private static string CleansingString(string str)
		{
			string cleanedStr = str.Replace("'", "''");
			return cleanedStr;
		}

		public string ScriptCreate() {
			var script = "EXEC sys.sp_addextendedproperty ";
			script += $"@name=N'{Name}', @value=N'{Value}', @level0type=N'{Level0Type}', @level0name=N'{Level0Name}'";
			script += string.IsNullOrEmpty(Level1Type) ? string.Empty : $", @level1type=N'{Level1Type}', @level1name=N'{Level1Name}'";
			script += string.IsNullOrEmpty(Level2Type) ? string.Empty : $", @level2type=N'{Level2Type}', @level2name=N'{Level2Name}'";
			return script;

		}

		public string ScriptAlter() {
			return ScriptCreate();
		}
	}
}

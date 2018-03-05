using System.Text;

namespace SchemaZen.Library.Models {
	public class PartitionFunction : BaseDBObject {
		
		public string RangeValues { get; set; }
		public string ParameterType { get; set; }
		public string RangeType { get; set; }
		public PartitionFunction (string name) {
			Name = name;
		}

		public override string ScriptCreate() {
			var text = new StringBuilder();
			text.Append(HeaderScriptCreate());
			text.Append($"CREATE PARTITION FUNCTION [{Name}]({ParameterType}) AS RANGE {RangeType} FOR VALUES ({RangeValues})");
			return (text.ToString());
		}
		public string ScriptDrop() {
			return $"DROP PARTITION FUNCTION [{Name}]";
		}
	}
}

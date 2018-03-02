namespace SchemaZen.Library.Models {
	public class PartitionFunction : BaseDBObject {
		
		public string RangeValues { get; set; }
		public string ParameterType { get; set; }
		public string RangeType { get; set; }
		public PartitionFunction (string name) {
			Name = name;
		}

		public override string ScriptCreate() {
			return $"CREATE PARTITION FUNCTION [{Name}]({ParameterType}) AS RANGE {RangeType} FOR VALUES ({RangeValues})";
		}
		public string ScriptDrop() {
			return $"DROP PARTITION FUNCTION [{Name}]";
		}
	}
}

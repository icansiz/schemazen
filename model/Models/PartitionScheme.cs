namespace SchemaZen.Library.Models {
	public class PartitionScheme : BaseDBObject {
		
		public string PartitionFunctionName { get; set; }
		public string FileGroups { get; set; }
		public PartitionScheme (string name) {
			Name = name;
		}

		public override string ScriptCreate() {
			return $"CREATE PARTITION SCHEME [{Name}] AS PARTITION [{PartitionFunctionName}] TO ({FileGroups})";
		}

		public string ScriptDrop() {
			return $"DROP PARTITION SCHEME [{Name}]";
		}
	}
}

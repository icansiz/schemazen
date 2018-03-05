using System.Text;
namespace SchemaZen.Library.Models {
	public class PartitionScheme : BaseDBObject {
		
		public string PartitionFunctionName { get; set; }
		public string FileGroups { get; set; }
		public PartitionScheme (string name) {
			Name = name;
		}

		public override string ScriptCreate() {
			var text = new StringBuilder();
			text.Append(HeaderScriptCreate());
			text.Append($"CREATE PARTITION SCHEME [{Name}] AS PARTITION [{PartitionFunctionName}] TO ({FileGroups})");
			return (text.ToString());
		}

		public string ScriptDrop() {
			return $"DROP PARTITION SCHEME [{Name}]";
		}
	}
}

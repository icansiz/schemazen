namespace SchemaZen.Library.Models {
	public class Role : BaseDBObject {
		public string Script { get; set; }

		public override string ScriptCreate() {
			return Script;
		}
	}
}

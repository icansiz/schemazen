﻿namespace SchemaZen.Library.Models {
	public class Synonym : BaseDBObject, IHasOwner {
		//public string Name { get; set; }
		public string Owner { get; set; }
		public string BaseObjectName { get; set; }

		public Synonym(string name, string owner) {
			Name = name;
			Owner = owner;
		}

		public override string ScriptCreate() {
			return $"CREATE SYNONYM [{Owner}].[{Name}] FOR {BaseObjectName}";
		}

		public string ScriptDrop() {
			return $"DROP SYNONYM [{Owner}].[{Name}]";
		}
	}
}

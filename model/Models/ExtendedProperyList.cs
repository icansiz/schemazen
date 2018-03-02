using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace SchemaZen.Library.Models {
	public class ExtendedPropertyList {
		private readonly List<ExtendedProperty> _mItems = new List<ExtendedProperty>();

		public ReadOnlyCollection<ExtendedProperty> Items => _mItems.AsReadOnly();

		public void Add(ExtendedProperty e) {
			_mItems.Add(e);
		}

		public void Remove(ExtendedProperty e) {
			_mItems.Remove(e);
		}

		public string Script() {
			var text = new StringBuilder();
			foreach (var e in _mItems) {
				text.AppendLine(e.ScriptCreate());
				text.AppendLine();
			}
			return text.ToString();
		}
	}
}

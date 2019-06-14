using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiApp.EntityModel
{
	public class BasicDefinition : EntityBase
	{
		public string Code { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }


		public ICollection<AccountingDocument> AccountingDocuments { get; set; }


	}
}

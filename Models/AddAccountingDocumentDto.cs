using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApp.Enums;

namespace WebApiApp.Models
{
	public class AddAccountingDocumentDto
	{		
		public string Title { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public bool IsNegative { get; set; }
		public CurrencyType CurrencyType { get; set; }
		public AccountingDocumentType AccountingDocumentType { get; set; }
		public Guid AccountingCodeId { get; set; }
		public Guid BasicDefinitionId { get; set; }

	}
}

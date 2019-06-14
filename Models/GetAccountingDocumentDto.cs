using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApp.Enums;

namespace WebApiApp.Models
{
	public class GetAccountingDocumentDto
	{
		public Guid Id { get; set; }
		public byte[] RowVersion { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public bool IsNegative { get; set; }
		public CurrencyType CurrencyType { get; set; }
		public AccountingDocumentType AccountingDocumentType { get; set; }
		public string AccCode { get; set; }
		public string BasicCode { get; set; }
		public string BasicTitle { get; set; }
		public string AccCodeTitle { get; set; }
	}
}

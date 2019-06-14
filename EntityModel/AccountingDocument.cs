using System;
using WebApiApp.Enums;

namespace WebApiApp.EntityModel
{
	public class AccountingDocument : EntityBase
	{

		public string Title { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public bool IsNegative { get; set; }
		public CurrencyType CurrencyType { get; set; }
		public AccountingDocumentType AccountingDocumentType { get; set; }


		public Guid AccountingCodeId { get; set; }
		public virtual AccountingCode AccountingCode { get; set; }


		public Guid BasicDefinitionId { get; set; }
		public virtual BasicDefinition BasicDefinition { get; set; }


	}

}

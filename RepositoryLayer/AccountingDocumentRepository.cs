using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebApiApp.DataLayerConfiguration;
using WebApiApp.EntityModel;

namespace WebApiApp.RepositoryLayer
{
	public class AccountingDocumentRepository : IAccountingDocumentRepository
	{

		private AccountingContext _context;

		public AccountingDocumentRepository (AccountingContext context)
		{
			_context = context;
		}

		public void AddDoc (AccountingDocument inputData)
		{
			_context.AccountingDocumentSet.Add(inputData);
			_context.SaveChanges();
		}

		public AccountingDocument GetDoc (Guid id)
		{
			return _context.AccountingDocumentSet.Where(e => e.Id.Equals(id))
					.Include(e => e.AccountingCode)
					.Include(e => e.BasicDefinition)
				.FirstOrDefault();
		}

		public void UpdateDoc (AccountingDocument inputData)
		{
			_context.Entry(inputData).OriginalValues["RowVersion"] = inputData.RowVersion;
			_context.AccountingDocumentSet.Update(inputData);
			_context.SaveChanges();
		}
	}
}

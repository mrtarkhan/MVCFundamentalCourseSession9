using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApp.EntityModel;

namespace WebApiApp.RepositoryLayer
{
	public interface IAccountingDocumentRepository
	{
		AccountingDocument GetDoc (Guid id);
		void AddDoc (AccountingDocument inputData);
		void UpdateDoc (AccountingDocument inputData);
	}
}

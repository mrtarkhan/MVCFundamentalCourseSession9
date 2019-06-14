using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApp.Models;

namespace WebApiApp.ServiceLayer
{
	public interface IAccountingDocumentService
	{
		GetAccountingDocumentDto GetDoc (Guid id);
		void AddDoc (AddAccountingDocumentDto inputData);
		void UpdateDoc (UpdateAccountingDocumentDto inputData);

	}
}

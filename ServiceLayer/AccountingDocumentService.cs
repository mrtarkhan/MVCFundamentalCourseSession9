using System;
using WebApiApp.EntityModel;
using WebApiApp.Models;
using WebApiApp.RepositoryLayer;

namespace WebApiApp.ServiceLayer
{
	public class AccountingDocumentService : IAccountingDocumentService
	{

		private IAccountingDocumentRepository _repo { get; set; }

		public AccountingDocumentService (IAccountingDocumentRepository repo)
		{
			_repo = repo;
		}

		public void AddDoc (AddAccountingDocumentDto inputData)
		{
			var dataToAdd = new AccountingDocument
			{
				Id = Guid.NewGuid(),
				CreatedDate = DateTime.Now,
				LastModifiedDate = DateTime.Now,
				AccountingCodeId = inputData.AccountingCodeId,
				BasicDefinitionId = inputData.BasicDefinitionId,
				AccountingDocumentType = Enums.AccountingDocumentType.User,
				CurrencyType = Enums.CurrencyType.Dollar,
				Price = inputData.Price,
				IsNegative = inputData.IsNegative,
				Title = "[سند ثبتی]: " + inputData.Title,
				Description = inputData.Description
			};

			dataToAdd.Price /= 130000;
			_repo.AddDoc(dataToAdd);

		}

		public GetAccountingDocumentDto GetDoc (Guid id)
		{
			var data = _repo.GetDoc(id);
			return new GetAccountingDocumentDto
			{
				Id = data.Id,
				RowVersion = data.RowVersion,
				AccountingDocumentType = data.AccountingDocumentType,
				CurrencyType = data.CurrencyType,
				Price = data.Price,
				IsNegative = data.IsNegative,
				Title = data.Title,
				Description = data.Description,
				AccCode = data.AccountingCode.Code,
				AccCodeTitle = data.AccountingCode.Title,
				BasicCode = data.BasicDefinition.Code,
				BasicTitle = data.BasicDefinition.Title
			};
		}

		public void UpdateDoc (UpdateAccountingDocumentDto inputData)
		{
			var data = _repo.GetDoc(inputData.Id);
			/* 
				because data is now tracking under efcore context observable
				we should check the rowversion here or should update it in Repository
				otherwise ef core just can be aware of concurrencies when appear just before 
				savechanges not all of them!
			*/
			data.RowVersion = inputData.RowVersion;
			data.LastModifiedDate = DateTime.Now;
			data.Price = inputData.Price;
			data.Title = inputData.Title;
			data.Description = inputData.Description;
			_repo.UpdateDoc(data);
		}
	}
}

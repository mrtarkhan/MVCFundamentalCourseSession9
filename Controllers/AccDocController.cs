using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiApp.Models;
using WebApiApp.ServiceLayer;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiApp.Controllers
{

	[Route("/api/[controller]")]
	public class AccDocController : Controller
	{


		private  IAccountingDocumentService Service;

		public AccDocController (IAccountingDocumentService service)
		{
			Service = service;
		}

		[HttpGet]
		[Route("{id}")]
		public GetAccountingDocumentDto Get (Guid id)
		{
			return Service.GetDoc(id);
		}

		
		[HttpPost]
		public IActionResult Post ([FromForm] AddAccountingDocumentDto input)
		{
			Service.AddDoc(input);
			return Ok();
		}


		[HttpPut]
		public IActionResult Amghezi ([FromForm] UpdateAccountingDocumentDto input)
		{
			Service.UpdateDoc(input);
			return Ok();
		}


	}
}

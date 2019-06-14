using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiApp.EntityModel
{
	public class EntityBase
	{
		public Guid Id { get; set; }
		public byte[] RowVersion { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime LastModifiedDate { get; set; }
	}
}

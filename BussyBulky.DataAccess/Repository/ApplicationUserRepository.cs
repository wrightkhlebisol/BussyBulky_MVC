using BussyBulky.DataAccess.Data;
using BussyBulky.DataAccess.Repository.IRepository;
using BussyBulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BussyBulky.DataAccess.Repository
{
	public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
		private ApplicationDbContext _db;
		public ApplicationUserRepository(ApplicationDbContext db) : base(db) 
		{ 
			_db = db;
		}
	}
}

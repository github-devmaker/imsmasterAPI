using Microsoft.AspNetCore.Mvc;
using WebApplication2.Contexts;

namespace WebApplication2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly Contexts.DbEmployee _context;

        public EmployeeController(DbEmployee context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("emp/{code}")]
        public ActionResult<Models.Employee> GetEmployee(string code)
        {
            return Ok(this._context.Employee.Where((x) => x.Code == code).FirstOrDefault());
        }
    }
}

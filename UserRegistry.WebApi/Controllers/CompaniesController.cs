using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using UserRegistry.Core.Models;
using UserRegistry.Core.Repositories;

namespace UserRegistry.WebApi.Controllers
{
    public class CompaniesController : ApiController
    {
        private readonly ICompanyRepository CompanyRepository;

        public CompaniesController(ICompanyRepository companyRepository)
        {
            CompanyRepository = companyRepository;
        }

        // GET: api/Companies
        public IHttpActionResult GetCompanies()
        {
            return Ok(CompanyRepository.GetAll().ToList());
        }

        // GET: api/Companies/5
        [ResponseType(typeof(Company))]
        public IHttpActionResult GetCompany(int id)
        {
            Company company = CompanyRepository.GetSingle(id);
            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        // PUT: api/Companies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompany(int id, Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != company.Id)
            {
                return BadRequest();
            }

            CompanyRepository.Edit(company);

            try
            {
                CompanyRepository.Save();
            }
            catch (UpdateException)
            {
                if (!CompanyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Companies
        [ResponseType(typeof(Company))]
        public IHttpActionResult PostCompany(Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CompanyRepository.Add(company);
            CompanyRepository.Save();

            return CreatedAtRoute("DefaultApi", new {id = company.Id}, company);
        }

        // DELETE: api/Companies/5
        [ResponseType(typeof(Company))]
        public IHttpActionResult DeleteCompany(int id)
        {
            Company company = CompanyRepository.GetSingle(id);
            if (company == null)
            {
                return NotFound();
            }

            CompanyRepository.Delete(company);
            CompanyRepository.Save();

            return Ok(company);
        }

        [Route("api/Companies/{id}/UsersCount")]
        public IHttpActionResult GetUsersCount(int id)
        {
            if (!CompanyExists(id))
                return NotFound();

            return Ok(CompanyRepository.GetUsersCount(id));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                CompanyRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyExists(int id)
        {
            return CompanyRepository.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}
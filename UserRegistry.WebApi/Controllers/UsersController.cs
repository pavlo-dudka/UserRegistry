using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using UserRegistry.Core.Models;
using UserRegistry.Core.Repositories;

namespace UserRegistry.WebApi.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserRepository UserRepository;

        public UsersController(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        // GET: api/Users
        public IHttpActionResult GetUsers()
        {
            return Ok(UserRepository.GetAll().ToList());
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = UserRepository.GetSingle(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            UserRepository.Edit(user);

            try
            {
                UserRepository.Save();
            }
            catch (UpdateException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserRepository.Add(user);
            UserRepository.Save();

            return CreatedAtRoute("DefaultApi", new {id = user.Id}, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = UserRepository.GetSingle(id);
            if (user == null)
            {
                return NotFound();
            }

            UserRepository.Delete(user);
            UserRepository.Save();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                UserRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return UserRepository.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}
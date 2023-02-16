using Exo.WebApi.Models;
using Exo.WebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exo.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_userRepository.Listar());
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            
        }
        [HttpPost]
        public IActionResult Post(User user)
        {
            try
            {
                _userRepository.Postar(user);
                return StatusCode(201);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _userRepository.Deletar(id);
                return StatusCode(204);

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        [HttpPut]
        public IActionResult Put(User user, int id)
        {
            try
            {
                _userRepository.Atualizar(user, id);
                return StatusCode(200);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}

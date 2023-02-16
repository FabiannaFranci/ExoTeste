using Exo.WebApi.Interface;
using Exo.WebApi.Models;
using Exo.WebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exo.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectRepository _projectrepository;
        public ProjectController(ProjectRepository projectrepository)
        { 
            _projectrepository = projectrepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_projectrepository.Ler());
            }

        
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        [HttpPost]
        public IActionResult Post(Project project)
        {
            try
            {
                _projectrepository.Postar(project);
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
            _projectrepository.Deletar(id);
            return StatusCode(204);
        }
        [HttpPut]
        public IActionResult Put(Project project, int id)
        {
            try
            {
                _projectrepository.Atualizar(project, id);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }

}


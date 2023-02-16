using Exo.WebApi.Context;
using Exo.WebApi.Interface;
using Exo.WebApi.Models;

namespace Exo.WebApi.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ProjectContext _projectContext;
        public ProjectRepository(ProjectContext context) 
        { 
            _projectContext = context;
        }

        public List<Project> Ler()
        {
            return _projectContext.Projeto.ToList();
        }

        public void Postar(Project project)
        {
            _projectContext.Projeto.Add(project);
            _projectContext.SaveChanges();
        }

       public void Deletar(int id)
        {
            Project foundproject = _projectContext.Projeto.Find(id);

            _projectContext.Projeto.Remove(foundproject);
            _projectContext.SaveChanges();
        }

        public void Atualizar(Project project, int id)
        {
            Project foundproject = _projectContext.Projeto.Find(id);

            if(foundproject != null) 
            { 
                foundproject.Titulo = project.Titulo;
                foundproject.DataInicio = project.DataInicio;
                foundproject.Area = project.Area ;
                foundproject.Terminado = project.Terminado;

                _projectContext.Projeto.Update(foundproject);
                _projectContext.SaveChanges();
            }

        }
    }
}

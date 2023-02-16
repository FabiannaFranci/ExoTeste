using Exo.WebApi.Models;

namespace Exo.WebApi.Interface
{
    public interface IProjectRepository
    {
        List<Project> Ler();

        void Postar(Project project);

        void Deletar(int id);

        void Atualizar (Project project, int id);
    }
}

using Exo.WebApi.Models;

namespace Exo.WebApi.Interface
{
    public interface IUserRepository
    {
        List<User> Listar();
        void Postar(User user);
        void Deletar (int id);
        void Atualizar(User user, int id);

        User Login(string? email, string? senha);

    }
}

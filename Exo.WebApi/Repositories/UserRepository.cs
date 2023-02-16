using Exo.WebApi.Context;
using Exo.WebApi.Interface;
using Exo.WebApi.Models;

namespace Exo.WebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ProjectContext _projectContext;

        public UserRepository(ProjectContext projectContext)
        { 
            _projectContext = projectContext;
        }

        public void Postar(User user)
        {
            _projectContext.Usuario.Add(user);
            _projectContext.SaveChanges();
        }

        public List<User> Listar()
        {
           return _projectContext.Usuario.ToList();
        }
        public void Deletar(int id)
        {
            User founduser = _projectContext.Usuario.Find(id);
            _projectContext.Usuario.Remove(founduser);
            _projectContext.SaveChanges();
        }

        public void Atualizar(User user, int id)
        {
            User founduser = _projectContext.Usuario.Find(id);

            if (founduser != null)
            {
                founduser.Email = user.Email;
                founduser.Tipo = user.Tipo;
                founduser.Senha = user.Senha;   
            }
            _projectContext.Update(founduser);
            _projectContext.SaveChanges();
        }

        public User Login(string email, string senha)
        {
            return _projectContext.Usuario.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
        
    }
}

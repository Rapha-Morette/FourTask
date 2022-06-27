using Microsoft.AspNetCore.Identity;
using Projeto_FourTask.Areas.Identity.Data;
using System.Linq.Expressions;

namespace Projeto_FourTask.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private ProjetoFourTaskContext _context;
        private UserManager<Usuario> _userManager;

        public UsuarioRepository(ProjetoFourTaskContext context, UserManager<Usuario> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public void Atualizar(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
        }

        public Usuario BuscarPor(string id)
        {
            return _context.Usuarios.Where(u => u.Id == id).FirstOrDefault();
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}

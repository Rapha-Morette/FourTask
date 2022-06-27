using Projeto_FourTask.Areas.Identity.Data;
using System.Linq.Expressions;

namespace Projeto_FourTask.Repositories
{
    public interface IUsuarioRepository
    {

        void Atualizar(Usuario usuario);

        Usuario BuscarPor(string id);

        void Salvar();
    }
}

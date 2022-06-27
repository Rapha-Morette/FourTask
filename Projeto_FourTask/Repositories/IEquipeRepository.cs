using Projeto_FourTask.Models;
using System.Linq.Expressions;

namespace Projeto_FourTask.Repositories
{
    public interface IEquipeRepository
    {
        IList<Equipe> BuscarPor(Expression<Func<Equipe, bool>> filtro);

        void CadastrarEquipe(Equipe equipe);

        Equipe BuscarPorId(int id);

        IList<Equipe> Listar();

        IList<Equipe> ListarEquipesEmTarefas();

        void AtualizarEquipe(Equipe equipe);

        void Salvar();

    }
}

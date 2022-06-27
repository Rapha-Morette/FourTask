using Projeto_FourTask.Models;
using System.Linq.Expressions;

namespace Projeto_FourTask.Repositories
{
    public interface ITarefaRepository
    {
         
        IList<Tarefa> Listar();

        void Cadastrar(Tarefa tarefa);

        Tarefa BuscarPorId(int id);

        IList<Tarefa> BuscarPor(Expression<Func<Tarefa, bool>> filtro);


        void Remover(int id);

        void Atualizar(Tarefa tarefa);

        void Salvar();
    }
}

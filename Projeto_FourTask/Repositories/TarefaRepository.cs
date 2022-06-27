using Microsoft.EntityFrameworkCore;
using Projeto_FourTask.Areas.Identity.Data;
using Projeto_FourTask.Models;
using System.Linq.Expressions;

namespace Projeto_FourTask.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private ProjetoFourTaskContext _context;

        public TarefaRepository(ProjetoFourTaskContext context)
        {
            _context = context;
        }

        public void Atualizar(Tarefa tarefa)
        {
            _context.Tarefas.Update(tarefa);
        }

        public IList<Tarefa> BuscarPor(Expression<Func<Tarefa, bool>> filtro)
        {
            return _context.Tarefas.Where(filtro).Include(t => t.Usuario).ToList();
        }

        public Tarefa BuscarPorId(int id)
        {
            return _context.Tarefas.Find(id);
        }

        public void Cadastrar(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
        }

        public IList<Tarefa> Listar()
        {
            return _context.Tarefas.ToList();
        }

        public void Remover(int id)
        {
            Tarefa tarefa = _context.Tarefas.Find(id);
            _context.Tarefas.Remove(tarefa);
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Projeto_FourTask.Areas.Identity.Data;
using Projeto_FourTask.Models;
using System.Linq.Expressions;

namespace Projeto_FourTask.Repositories
{
    public class EquipeRepository : IEquipeRepository
    {
        private ProjetoFourTaskContext _context;

        public EquipeRepository(ProjetoFourTaskContext context)
        {
            _context = context;
        }
        public void AtualizarEquipe(Equipe equipe)
        {
            _context.Equipes.Update(equipe);
        }

        public IList<Equipe> BuscarPor(Expression<Func<Equipe, bool>> filtro)
        {
            return _context.Equipes.Where(filtro).ToList();
        }

        public Equipe BuscarPorId(int id)
        {
            return _context.Equipes.Find(id);
        }

        public void CadastrarEquipe(Equipe equipe)
        {
            _context.Equipes.Add(equipe);
        }

        public IList<Equipe> Listar()
        {
           return _context.Equipes.ToList();
        }

        public IList<Equipe> ListarEquipesEmTarefas()
        {
           return _context.Equipes.OrderBy(e => e.Nome).ToList();
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}

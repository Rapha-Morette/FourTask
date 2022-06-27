using Projeto_FourTask.Areas.Identity.Data;
using Projeto_FourTask.Models;

namespace Projeto_FourTask.ViewModels
{
    public class EquipeViewModel
    {
        public Usuario Usuario { get; set; }
        public Equipe? Equipe { get; set; }
        public IList<Equipe>? ListaEquipe { get; set; }
        public Tarefa? Tarefa { get; set; }

        public IList<Tarefa>? ListaTarefa { get; set; }
    }
}

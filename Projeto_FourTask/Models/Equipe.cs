using Projeto_FourTask.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_FourTask.Models
{
    [Table("Tbl_Equipe")]
    public class Equipe
    {
        [Required, Column("Id")]
        public int EquipeId { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório"), Column("Nome"), MaxLength(80)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório"), Column("Senha"), MaxLength(10)]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "O campo senha deve ter no mínimo 3 e no máximo 10 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O campo descrição é obrigatório"), Column("Descricao")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo Area de atuação é obrigatório")]
        public AreaContratacao AreaContratacao { get; set; }

        [Required]
        public DateTime DataCriacao { get; set; }

        //N:1
        public ICollection<Usuario>? Usuarios { get; set; }

        // N:1
        public ICollection<Tarefa>? Tarefas { get; set; }


        public Equipe()
        {
            DataCriacao = DateTime.Now;
        }

    }

    public enum AreaContratacao
    {
        Web, Mobile, Frontend, Backend, Fullstack, Gestao, Outros
    }
}

using Projeto_FourTask.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_FourTask.Models
{
    [Table("Tbl_Tarefa")]
    public class Tarefa
    {
        [Required, Column("Id")]
        public int TarefaId { get; set; }

        [Required, MaxLength(50)]
        public string Titulo { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required, Column("Dt_Criacao"), Display(Name = "Data de Criação"), DataType(DataType.Date)]
        public DateTime DataCriacao { get; set; }

        [Required, Column("Dt_Limite"), Display(Name = "Data Limite"), DataType(DataType.Date)]
        public DateTime DataLimite { get; set; }

        //1:N
     
        public Equipe? Equipe { get; set; }

        public int? EquipeId { get; set; }


        //1:N
        public Usuario? Usuario { get; set; }

        public string? UsuarioId { get; set; }


        public Tarefa() 
        {
            DataCriacao = DateTime.Now;
        }
    }

}

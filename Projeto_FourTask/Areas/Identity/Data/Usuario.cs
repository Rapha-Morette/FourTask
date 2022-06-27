using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Projeto_FourTask.Models;

namespace Projeto_FourTask.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Usuario class
public class Usuario : IdentityUser
{
    [Required]
    public string Nome { get; set; }

    [Required]
    public DateTime DataNascimento { get; set; }

    //1:N
    public Equipe? Equipe { get; set; }

    public int? EquipeId { get; set; }

    public ICollection<Tarefa>? Tarefas { get; set; }

}


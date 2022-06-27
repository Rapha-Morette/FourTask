using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projeto_FourTask.Areas.Identity.Data;
using Projeto_FourTask.Models;
using Projeto_FourTask.Repositories;
using Projeto_FourTask.ViewModels;

namespace Projeto_FourTask.Controllers
{
    [Authorize]
    public class TarefaController : Controller
    {

        private UserManager<Usuario> _userManager;
        private IEquipeRepository _equipeRepository;
        private ITarefaRepository _tarefaRepository;
        private IUsuarioRepository _usuarioRepository;

        public TarefaController(UserManager<Usuario> userManager,
                                IEquipeRepository equipeRepository,
                                ITarefaRepository tarefaRepository,
                                IUsuarioRepository usuarioRepository)
        {
            _userManager = userManager;
            _equipeRepository = equipeRepository;
            _tarefaRepository = tarefaRepository;
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //Pegar Usuario logado
            Usuario? usuario = _usuarioRepository.BuscarPor(_userManager.GetUserId(User));


            //Listagem de tarefas 
            EquipeViewModel viewModel = new EquipeViewModel();
            viewModel.ListaTarefa = _tarefaRepository.Listar();

            //Exibir a lista de Equipe no cadastro de tarefa para relacionamento
            var equipes = _equipeRepository.ListarEquipesEmTarefas();
            ViewBag.equipes = new SelectList(equipes, "EquipeId", "Nome");

            return View(viewModel);

        }

        [HttpPost]
        public IActionResult CadastrarTarefa(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                _tarefaRepository.Cadastrar(tarefa);
                _tarefaRepository.Salvar();
                TempData["msgTarefa"] = "Tarefa cadastrada com sucesso!";

                return RedirectToAction("Index");

            }
            TempData["CadastroInvalido"] = "Cadastro inválido, Confira se todos os campos estão corretos";
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            //Exibir a lista de Equipe no cadastro de tarefa para relacionamento
            var equipes = _equipeRepository.ListarEquipesEmTarefas();
            ViewBag.equipes = new SelectList(equipes, "EquipeId", "Nome");

            EquipeViewModel eq = new EquipeViewModel();
            eq.Tarefa = _tarefaRepository.BuscarPorId(id);
            return View(eq);
        }

        [HttpPost]
        public IActionResult Editar(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                _tarefaRepository.Atualizar(tarefa);

                _tarefaRepository.Salvar();
                TempData["msgEditar"] = "Tarefa editada com sucesso!";
                return RedirectToAction("Index");
            }
            TempData["EdicaoInvalido"] = "Edição inválido, Confira se todos os campos estão corretos";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult remover(int id)
        {
            _tarefaRepository.Remover(id);

            _tarefaRepository.Salvar();
            TempData["msgRemover"] = "Tarefa removida com sucesso!";

            return RedirectToAction("Index");
        }

    }
}

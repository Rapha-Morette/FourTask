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
    public class EquipeController : Controller
    {
        private UserManager<Usuario> _userManager;
        private IEquipeRepository _equipeRepository;
        private IUsuarioRepository _usuarioRepository;
        private ITarefaRepository _tarefaRepository;

        public EquipeController(UserManager<Usuario> userManager,
                                IEquipeRepository equipeRepository,
                                IUsuarioRepository usuarioRepository,
                                ITarefaRepository tarefaRepository)
        {
            _userManager = userManager;
            _equipeRepository = equipeRepository;
            _usuarioRepository = usuarioRepository;
            _tarefaRepository = tarefaRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //Pegar Usuario logado
            Usuario? usuario = _usuarioRepository.BuscarPor(_userManager.GetUserId(User));

            //Listagem da Equipes 
            EquipeViewModel viewModel = new EquipeViewModel();

            //Condição para exibição somente da Equipe que o usuário faz parte
            if (usuario.EquipeId != null)
            {
                TempData["msgJaPossuiEquipe"] = "Você ja está na equipe:";
                viewModel.ListaEquipe = _equipeRepository.BuscarPor(e => e.EquipeId == usuario.EquipeId);

            }
            //Condição para exibição das Equipes para o usuário que não possui equipe
            else
            {
                viewModel.ListaEquipe = _equipeRepository.Listar();
            }

            //Condição para listage somente das tarefas da Equipe
            if (usuario.EquipeId == null)
            {
                TempData["UsuarioSemEquipe"] = "Você ainda não entrou em nenhuma Equipe";
            }

            //Listagem de Tarefas da equipe
            viewModel.ListaTarefa = _tarefaRepository.BuscarPor(t => t.EquipeId == usuario.EquipeId);


            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Equipe equip)
        {
            if (ModelState.IsValid)
            {
                _equipeRepository.CadastrarEquipe(equip);
                _equipeRepository.Salvar();
                TempData["msgCadastrouEquipe"] = "Equipe cadastrada com sucesso!";
                return RedirectToAction("Index");
            }
            return View();
        }



        [HttpPost]
        public IActionResult EntrarEquipe(int id, string senha)
        {
            Equipe? equipe = _equipeRepository.BuscarPorId(id);
            if (equipe.Senha == senha)
            {
                Usuario? usuario = _usuarioRepository.BuscarPor(_userManager.GetUserId(User));

                usuario.EquipeId = id;

                _usuarioRepository.Atualizar(usuario);
                _usuarioRepository.Salvar();

                TempData["msgEntrouEquipe"] = "Parabens! Agora você faz parte do time";
            }
            else
            {
                TempData["senhaIncorreta"] = "Senha inválida";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AceitarTarefa(int id)
        {
            Tarefa tarefa = _tarefaRepository.BuscarPorId(id);

            tarefa.UsuarioId = _userManager.GetUserId(User);

            _tarefaRepository.Atualizar(tarefa);
            _tarefaRepository.Salvar();

            TempData["msgTarefaAceita"] = "Tarefa aceita com sucesso";
            return RedirectToAction("Index");
        }

    }
}

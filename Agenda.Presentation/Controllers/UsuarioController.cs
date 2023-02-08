using Agenda.Data.Repositories;
using Agenda.Presentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Agenda.Presentation.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        public IActionResult MinhaConta()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MinhaConta(UsuarioMinhaContaModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var json = User.Identity.Name;
                    var auth = JsonConvert.DeserializeObject<AuthenticationModel>(json);

                    var usuarioRepository = new UsuarioRepository();
                    usuarioRepository.Update(auth.IdUsuario, model.NovaSenha);

                    TempData["MensagemSucesso"] = "Sua nova senha foi atualizada com sucesso!";
                }

                catch (Exception e)
                {
                    TempData["MensagemErro"] = $"Ocorreu um erro: {e.Message}";
                }
            }

            else
            {
                TempData["MensagemAlerta"] = "Ocorreram erros no preenchimento do formulário, " +
                    "por favor verifique.";
            }
            return View();
        }
    }
}
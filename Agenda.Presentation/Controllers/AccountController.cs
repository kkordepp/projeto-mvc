using Agenda.Data.Entities;
using Agenda.Data.Repositories;
using Agenda.Messages;
using Agenda.Presentation.Models;
using Bogus;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace Agenda.Presentation.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AccountLoginModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var usuarioRepository = new UsuarioRepository();

                    var usuario = usuarioRepository.GetByEmailAndSenha(model.Email, model.Senha);

                    if (usuario == null)
                    {
                        TempData["Mensagem"] = "Acesso negado";
                    }
                    else
                    {
                        var authenticationModel = new AuthenticationModel
                        {
                            IdUsuario = usuario.IdUsuario,
                            Nome = usuario.Nome,
                            Email = usuario.Email,
                            DataHoraAcesso = DateTime.Now
                        };

                        var json = JsonConvert.SerializeObject(authenticationModel);

                        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, json) },
                            CookieAuthenticationDefaults.AuthenticationScheme);

                        var principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                        return RedirectToAction("Index", "Home");
                    }
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = $"Erro: {e.Message}";
                }
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(AccountRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var usuarioRepository = new UsuarioRepository();

                    if (usuarioRepository.GetByEmail(model.Email) != null)
                    {
                        TempData["Mensagem"] = "O email informado já foi cadastrado por outro usuário.";
                    }
                    else
                    {
                        var usuario = new Usuario()
                        {
                            IdUsuario = Guid.NewGuid(),
                            Nome = model.Nome,
                            Email = model.Email,
                            Senha = model.Senha,
                            DataCriacao = DateTime.Now
                        };

                        usuarioRepository.Create(usuario);

                        TempData["Mensagem"] = $"Parabéns {usuario.Nome}, sua conta foi criada com sucesso!";
                        ModelState.Clear();
                    }
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = $"Erro: {e.Message}";
                }
            }

            return View();
        }

        public IActionResult Password()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Password(AccountPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var usuarioRepository = new UsuarioRepository();
                    var usuario = usuarioRepository.GetByEmail(model.Email);

                    if (usuario != null)
                    {
                        #region gerando nova senha para o usuário

                        var faker = new Faker();
                        var novaSenha = $"@{faker.Internet.Password()}";

                        #endregion

                        #region Enviando um email contendo uma nova senha

                        var subject = "Recuperação de senha - Agenda de Contatos";
                        var body = @$"
                            <h3>Olá {usuario.Nome}</h3>
                            <p>Uma nova senha foi gerada para seu usuário.</p>
                            <p>Acesse a agenda com a senha: <strong>{novaSenha}</strong></p>
                            <p>Após acessar a agenda, você poderá utilizar o menu 'Minha Conta' para alterar sua senha.</p>
                            <br></br>
                            <p>Att, <br></br>Equipe Agenda de Contatos</p>
                            ";

                        var emailMessageService = new EmailMessageService();
                        emailMessageService.SendMessage(usuario.Email, subject, body);

                        #endregion

                        #region Atualizando a senha no banco de dados

                        usuarioRepository.Update(usuario.IdUsuario, novaSenha);

                        #endregion

                        TempData["Mensagem"] = "Uma nova senha foi gerada, por favor verifique sua conta de email.";
                        ModelState.Clear();
                    }

                    else
                    {
                        TempData["Mensagem"] = $"Email inválido. Usuário não encontrado.";
                    }
                }

                catch (Exception e)
                {
                    TempData["Mensagem"] = $"Falha ao recuperar senha: {e.Message}";
                }
            }

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Account");
        }
    }
}
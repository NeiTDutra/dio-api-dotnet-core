using Course.api.Business.Entities;
using Course.api.Filters;
using Course.api.Infrastructure.Data;
using Course.api.Models;
using Course.api.Models.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace Course.api.Controllers
{
    [Route("api/v1/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        /// <summary>
        /// teste
        /// </summary>
        /// <param name="loginViewModelInput">View model do login</param>
        /// <returns>Retorna status ok, dados do usuario e o token em caso de exiistir</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar usuario", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatorios", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoViewModel))]
        [HttpPost]
        [ValidacaoModelStateCustomizado]
        [Route("login")]
        public IActionResult Logar(LoginViewModelInput loginViewModelInput)
        {
            return Ok(loginViewModelInput);
        }

        /// <summary>
        /// teste1
        /// </summary>
        /// <param name="registroViewModelInput">View model do registro</param>
        /// <returns>Retorna status ok, dados do usuario e o token em caso de exiistir</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao registrar usuario", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatorios", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoViewModel))]
        [HttpPost]
        [ValidacaoModelStateCustomizado]
        [Route("registrar")]
        public IActionResult Registrar(RegistroViewModelInput registroViewModelInput)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CourseDbContext>();

            optionsBuilder.UseSqlServer("Server=localhost;Database=db_courseapi;user=nei;password=Senha#2020");
            CourseDbContext context = new CourseDbContext(optionsBuilder.Options);

            var aluno = new User();
            aluno.name = registroViewModelInput.Login;
            aluno.email = registroViewModelInput.Email;
            aluno.password = registroViewModelInput.Senha;
            context.User.Add(aluno);
            context.SaveChanges();

            return Created("", registroViewModelInput);
        }
    }
}

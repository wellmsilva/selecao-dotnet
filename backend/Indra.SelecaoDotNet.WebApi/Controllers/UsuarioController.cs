using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Indra.SelecaoDotNet.Application.Interfaces;
using Indra.SelecaoDotNet.Application.ViewModels;
using Indra.SelecaoDotNet.WebApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Indra.SelecaoDotNet.WebApi.Controllers
{
    /// <summary>
    /// Usuário/Estudante da plataforma
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private IUsuarioAppService _usuarioAppService;

        private readonly Guid userId;

        public UsuarioController(IOptions<AppSettings> appSettings, IUsuarioAppService usuarioAppService, IHttpContextAccessor httpContextAccessor)
        {
            _appSettings = appSettings.Value;
            _usuarioAppService = usuarioAppService;
            if (User != null)
                userId = httpContextAccessor.HttpContext.User != null ? Guid.Parse(httpContextAccessor.HttpContext.User.Identity.Name) : default;
        }

        /// <summary>
        /// Lista de alunos 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<UsuarioViewModel> Get()
        {
            return _usuarioAppService.ObtemTodos();
        }



        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult Login([FromBody]LoginModel model)
        {

            var user = _usuarioAppService.Login(model);
            if (user == null)
                return BadRequest(new { message = "Usuário e/ou senha incorretos" });


            GerarToken(user);
            return Ok(user);


        }

        private void GerarToken(UsuarioViewModel user)
        {
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
        }


        /// <summary>
        /// Registra-se na plataforma
        /// </summary>
        /// <param name="model"></param>
        /// 
        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult Registrar([FromBody]UsuarioViewModel model)
        {
            _usuarioAppService.Cadastrar(model);
            return Ok();
        }


        [HttpPost("[action]")]
        public IActionResult AdicionarCartao([FromBody]CartaoViewModel model)
        {
             var _id = Guid.Parse( User.Identity.Name);

            _usuarioAppService.AdicionarCartao(_id, model);
            return Ok();
        }


        /// <summary>
        /// Lista de alunos 
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public IEnumerable<CartaoViewModel> Cartoes()
        {
            var _id = Guid.Parse(User.Identity.Name);
            return _usuarioAppService.ObtemCartoes(_id);
        }


        /// <summary>
        /// Lista de alunos 
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]/{cartaoId}")]
        public void CartaoPadrao(Guid cartaoId)
        {

            _usuarioAppService.CartaoPadrao(userId);
        }
    }
}
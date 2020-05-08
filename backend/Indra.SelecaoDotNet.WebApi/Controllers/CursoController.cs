using Indra.SelecaoDotNet.Application.Interfaces;
using Indra.SelecaoDotNet.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indra.SelecaoDotNet.WebApi.Controllers
{
    /// <summary>
    /// Cursos oferecidos pela plataforma
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CursoController : ControllerBase
    {
        private ICursoAppService _cursoAppService;

        public CursoController(ICursoAppService cursoAppService)
        {
            _cursoAppService = cursoAppService;
        }

        /// <summary>
        /// Lista de cursos 
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<CursoViewModel> Get()
        {
            return _cursoAppService.ObtemTodos();
        }



        /// <summary>
        /// Lista de cursos 
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public CursoViewModel Get(Guid id)
        {
            return _cursoAppService.Obtem(id);
        }


        /// <summary>
        /// Lista de cursos 
        /// </summary>
        /// <returns></returns>
        [HttpPost("{id}/[action]")]
        public MatriculaViewModel RealizarMatricula(Guid id)
        {
            var userId = Guid.Parse(User.Identity.Name);
            return _cursoAppService.RealizarMatricula(userId, id);
        }


        /// <summary>
        /// Lista de cursos 
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]/{id}")]
        public MatriculaViewModel EfetuarPagamento(Guid id)
        {
            var userId = Guid.Parse(User.Identity.Name);
          return  _cursoAppService.EfetuarPagamento(userId, id);
        }
    }
}

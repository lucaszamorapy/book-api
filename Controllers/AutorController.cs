﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi8.Models;
using WebApi8.Services.Autor;

namespace WebApi8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorInterface _autorinterface;
        public AutorController(IAutorInterface autorInterface) 
        {
            _autorinterface = autorInterface;   
        }

        [HttpGet("ListarAutores")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
        {
             var autores = await _autorinterface.ListarAutores();
             return Ok(autores);
        }
    }
}

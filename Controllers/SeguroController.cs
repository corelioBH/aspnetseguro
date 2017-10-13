using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using aspnet_seguro.Models;
using aspnet_seguro.Models.AccountViewModels;
using aspnet_seguro.Services;

namespace aspnet_seguro.Controllers
{
    [Authorize(Roles="admin")]
    [Route("api/[controller]")]
    /*
    Este é um controlador com acesso seguro. 
    Apenas usuarios com o papel de administador podem acessar este recurso.
    Para que este codigo funcione eh necessario que o banco de dados tenha:
     - O papel admin cadastrado na tabela AspNetRoles
     - O relacionamento entre o usuario e o papel cadastrado na tabela AspNetUserRoles
     - Neste exemplo o usuario chamado usuario1@empresa.com.br esta vinculado ao papel admin.
     - Já o usuario chamado usuario2@empresa.com.br nao tem esta vinculacao.
     - As senhas destes usuarios para teste são respectivamenteß Usuario1! e Usuario2!
     */
    public class SeguroController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Ei. Este é um acesso apenas para administradores");
        }
    }

}

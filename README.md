# aspnetseguro
Exemplo simples de uso de autenticação e autorização em ASP.NET Core 2

O projeto foi gerado através do seguinte scaffolding de linha de comando:
dotnet new mvc --auth Individual

O código gerado cria um conjunto de tabelas em um banco de dados SQLite para uso pelo Identity.
Este banco de dados está contido fisicamente no arquivo App.db.

Com o projeto gerado, criamos um controlador de teste de autorizado chamado SeguroController. 
Ele é descrito abaixo.

```C#
namespace aspnet_seguro.Controllers
{
    [Authorize(Roles="admin")]
    [Route("api/[controller]")]
    /*
    Este é um controlador com acesso seguro. Apenas usuarios com o papel de administador podem acessar este recurso.

    Neste exemplo ja criamos um banco de dados com o usuario chamado usuario1@empresa.com.br, vinculado ao papel admin.
    Tambem temos o usuario chamado usuario2@empresa.com.br, que nao tem esta vinculacao.
    
    As senhas destes usuarios para teste são respectivamentee Usuario1! e Usuario2!
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
```

Para criar novos papéis basta inserir dados na tabela AspNetRoles.
Para fazer a vinculacao de um usuario a um papel basta inserir o dado na tabela AspNetUserRoles.

E para documentação mais específica para usar este recurso, veja o site da Microsoft aqui:
https://docs.microsoft.com/en-us/aspnet/core/security/authorization/roles




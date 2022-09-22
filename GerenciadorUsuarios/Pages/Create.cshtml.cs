using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace GerenciadorUsuarios.Pages
{
    public class CreateModel : PageModel
    {
        public UsuariosInfo usuariosInfo = new UsuariosInfo();
        public String errorMessage = "";
        public String sucessMessage = "";

        public void OnGet()
        {

        }

        public void OnPost()
        {
            usuariosInfo.id = Request.Form["id"];
            usuariosInfo.nome = Request.Form["nome"];
            usuariosInfo.sobrenome = Request.Form["sobrenome"];
            usuariosInfo.email = Request.Form["email"]; 
            usuariosInfo.dataNascimento = Request.Form["dataNascimento"];
            usuariosInfo.escolaridade = Request.Form["escolaridade"];

            if (usuariosInfo.id == 0 || usuariosInfo.nome == 0 || usuariosInfo.sobrenome == 0 || usuariosInfo.email == 0 || usuariosInfo.dataNascimento == 0 || usuariosInfo.escolaridade == 0)
            {
                errorMessage = "All the fields are required";
                return;

            }

            // salvar no banco

            usuariosInfo.id = ""; usuariosInfo.nome = ""; usuariosInfo.sobrenome = ""; usuariosInfo.email = ""; usuariosInfo.dataNascimento = ""; usuariosInfo.escolaridade = "";


        }
    }  

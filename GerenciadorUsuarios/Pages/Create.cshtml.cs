using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;


namespace GerenciadorUsuarios.Pages.Clients
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
            usuariosInfo.nome = Request.Form["nome"];
            usuariosInfo.sobrenome = Request.Form["sobrenome"];
            usuariosInfo.email = Request.Form["email"];
            usuariosInfo.dataNascimento = Request.Form["dataNascimento"];
            usuariosInfo.escolaridade = Request.Form["escolaridade"];

            if (usuariosInfo.nome.Length == 0 || usuariosInfo.sobrenome.Length == 0 || usuariosInfo.email.Length == 0 || usuariosInfo.dataNascimento.Length == 0 || usuariosInfo.escolaridade.Length == 0)
            {
                errorMessage = "Todos os campos são obrigatórios";
                return;
            }

            // salvar o novo usuario no banco

            try
            {
                String connectionString = "Data Source=DESKTOP-748SHP9\\SQLDANTAS;Initial Catalog=Gerenciador;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO Usuarios " +
                                "(Nome, Sobrenome, Email, DataNascimento, Escolaridade ) VALUES " +
                                "(@nome, @sobrenome, @email, @dataNascimento, @escolaridade);";

                    using(SqlCommand comand = new SqlCommand(sql, connection))
                    {
                        comand.Parameters.AddWithValue("@nome", usuariosInfo.nome);
                        comand.Parameters.AddWithValue("@sobrenome", usuariosInfo.sobrenome);
                        comand.Parameters.AddWithValue("@email", usuariosInfo.email);
                        comand.Parameters.AddWithValue("@dataNascimento", usuariosInfo.dataNascimento);
                        comand.Parameters.AddWithValue("@escolaridade", usuariosInfo.escolaridade);

                        comand.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                errorMessage = ex.Message;
                return;

            }

            usuariosInfo.nome = ""; usuariosInfo.sobrenome = ""; usuariosInfo.email = ""; usuariosInfo.dataNascimento = ""; usuariosInfo.escolaridade = "";
            sucessMessage = "Novo usuário cadastrado";

            Response.Redirect("/Clients/Usuario");
            
        }
    }
}

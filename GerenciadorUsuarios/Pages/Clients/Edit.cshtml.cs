using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace GerenciadorUsuarios.Pages.Clients
{
    public class EditModel : PageModel
    {
        public UsuariosInfo usuariosInfo = new UsuariosInfo();
        public String errorMessage = "";
        public String sucessMessage = "";

        public void OnGet()
        {
            String id = Request.Query["id"];

            try
            {
                String connectionString = "Data Source=DESKTOP-748SHP9\\SQLDANTAS;Initial Catalog=Gerenciador;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Usuarios WHERE id=@id";
                    
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id",id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                usuariosInfo.id = reader.GetInt32(0);
                                usuariosInfo.nome = reader.GetString(1);
                                usuariosInfo.sobrenome = reader.GetString(2);
                                usuariosInfo.email = reader.GetString(3);
                                usuariosInfo.dataNascimento = reader.GetString(4);
                                usuariosInfo.escolaridade = reader.GetString(5);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;

            }
        }

        public void OnPost()
        {
            String id = Request.Query["id"];
            usuariosInfo.id =int.Parse(id);
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

            // edita o usuario no banco

            try
            {
                String connectionString = "Data Source=DESKTOP-748SHP9\\SQLDANTAS;Initial Catalog=Gerenciador;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "UPDATE Usuarios SET " +
                                "Nome=@nome, Sobrenome=@sobrenome, Email=@email, DataNascimento=@dataNascimento, Escolaridade=@escolaridade " +
                                "WHERE id=@id";
                   
                    using (SqlCommand comand = new SqlCommand(sql, connection))
                    {
                        comand.Parameters.AddWithValue("@id", usuariosInfo.id);
                        comand.Parameters.AddWithValue("@nome", usuariosInfo.nome);
                        comand.Parameters.AddWithValue("@sobrenome", usuariosInfo.sobrenome);
                        comand.Parameters.AddWithValue("@email", usuariosInfo.email);
                        comand.Parameters.AddWithValue("@dataNascimento", usuariosInfo.dataNascimento);
                        comand.Parameters.AddWithValue("@escolaridade", usuariosInfo.escolaridade);


                        comand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;

            }

            Response.Redirect("/Clients/Usuarios");

        }
    }
}

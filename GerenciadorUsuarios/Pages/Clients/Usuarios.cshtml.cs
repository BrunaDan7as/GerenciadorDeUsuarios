using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace GerenciadorUsuarios.Pages.Clients
{
    public class UsuariosModel : PageModel
    {
        public List<UsuariosInfo> listUsuarios = new List<UsuariosInfo>();
        public void OnGet()
        {
            try
            {  // CONEXÃO COM BANCO
                string connectionString = "Data Source=DESKTOP-748SHP9\\SQLDANTAS;Initial Catalog=Gerenciador;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Usuarios"; // sql query
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UsuariosInfo usuariosInfo = new UsuariosInfo();
                                usuariosInfo.id = reader.GetInt32(0);
                                usuariosInfo.nome = reader.GetString(1);
                                usuariosInfo.sobrenome = reader.GetString(2);
                                usuariosInfo.email = reader.GetString(3);
                                usuariosInfo.dataNascimento = reader.GetString(4);
                                usuariosInfo.escolaridade = reader.GetString(5);
                                usuariosInfo.created_at = reader.GetDateTime(6).ToString() ;

                                listUsuarios.Add(usuariosInfo); // adicionar objeto na lista
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }

    public class UsuariosInfo
    {
        public int id;
        public string nome;
        public string sobrenome;
        public string email;
        public string dataNascimento;
        public string escolaridade;
        public string created_at;

    }
}
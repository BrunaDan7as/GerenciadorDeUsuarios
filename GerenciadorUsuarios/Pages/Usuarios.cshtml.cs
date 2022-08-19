using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace GerenciadorUsuarios.Pages
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
                                UsuariosInfo usuarios = new UsuariosInfo();
                                usuarios.id = reader.GetInt32(0);
                                usuarios.nome = reader.GetString(1);
                                usuarios.sobrenome = reader.GetString(2);
                                usuarios.email = reader.GetString(3);
                                usuarios.dataNascimento = reader.GetString(4);
                                usuarios.escolaridade = reader.GetString(5);

                                listUsuarios.Add(usuarios); // adicionar objeto na lista
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

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

    }
}
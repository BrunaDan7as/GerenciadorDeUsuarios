using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace GerenciadorUsuarios.Pages
{
    public class CreateModel : PageModel
    {
        public void OnGet()
        {
            try
            {  // CONEXÃO COM BANCO
                string connectionString = "Data Source=DESKTOP-748SHP9\\SQLDANTAS;Initial Catalog=Gerenciador;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Usuarios"; // sql query
                }
            }
            catch (Exception)
            {

            }
            
         
        }
        protected void btncadastro(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
        }
    }    
}
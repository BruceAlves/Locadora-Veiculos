using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locadora_Veiculos.Conexao.usuario
{
    class Usuario : IUsuario
    {
        private readonly string conexao = ConfigurationManager.ConnectionStrings["dev"].ConnectionString;

        public bool VerificarLogin(string email, string senha)
        {
            bool validarUsuario = false;

            string query = $@"select * from tb_usuario where email = '{email}' and senha = '{senha}'";

            MySqlConnection mySqlConnection = new MySqlConnection(conexao);
            DataTable tbUsuario = new DataTable();

            try
            {
                mySqlConnection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, mySqlConnection);
                adapter.Fill(tbUsuario);

                if(tbUsuario.Rows.Count > 0)
                {
                    SessaoUsuario.Id = Convert.ToInt32(tbUsuario.Rows[0]["id"]);
                    SessaoUsuario.Email = tbUsuario.Rows[0]["email"].ToString();
                    SessaoUsuario.Nome = tbUsuario.Rows[0]["nome"].ToString();
                    SessaoUsuario.Senha = tbUsuario.Rows[0]["senha"].ToString();

                     validarUsuario = true;
                }


            }
            catch(Exception)
            {
                MessageBox.Show("Erro de conexão", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                mySqlConnection.Close();
            }

            return validarUsuario;
        }
    }
}

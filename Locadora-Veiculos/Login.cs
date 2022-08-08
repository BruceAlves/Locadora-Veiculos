using Locadora_Veiculos.Conexao.usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locadora_Veiculos
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            IUsuario conexao = new Usuario();
            bool validacaoUsuario = conexao.VerificarLogin(txtEmail.Text, txtSenha.Text);

            if (validacaoUsuario)
            {
                SessaoUsuario.Email = txtEmail.Text;
                SessaoUsuario.Senha = txtSenha.Text;

                IUsuario usuario = new Usuario();
                usuario.VerificarLogin(SessaoUsuario.Email, SessaoUsuario.Senha);

                MessageBox.Show("Usuário logado com sucesso!", "Pronto!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //txtEmail.Text = string.Empty;
                //txtSenha.Text = string.Empty;

            }
            else
            {
                MessageBox.Show("Usuário inválido", "Erro!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

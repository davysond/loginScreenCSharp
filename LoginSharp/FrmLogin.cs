using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoginSharp
{
    public partial class FrmLogin : Form
    {
        //Referência
        SqlConnection Conexao = new SqlConnection(@"Data Source=NITRODAVYSON;Initial Catalog=LoginCharp;Integrated Security=True");
        public FrmLogin()
        {
            InitializeComponent();
            txtUsuario.Select();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        //Verifica se os campos estão vazios.
        void verificarCamposVazio()
        {
            if(txtUsuario.Text == "" && txtSenha.Text == "")
            {
                MessageBox.Show("PREENCHA OS CAMPOS. POR GENTILEZA, TENTE NOVAMENTE!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Select();
             }
        }
        
        //Código relativo ao botão de "Entrar".
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Conexao.Open();
            verificarCamposVazio();
            string query = "SELECT * FROM Usuario  WHERE Username = '" + txtUsuario.Text + "' AND Password = '" + txtSenha.Text + "'";
            SqlDataAdapter dp = new SqlDataAdapter(query, Conexao);
            DataTable dt = new DataTable();
            dp.Fill(dt);

            try
            {
                if (dt.Rows.Count == 1)
                {
                    MessageBox.Show("BEM-VINDO(A) AO SISTEMA!");
                    txtUsuario.Text = "";
                    txtSenha.Text = "";
                    txtUsuario.Select();
                }
            }
            catch (Exception erro)
            {
                    MessageBox.Show("USUÁRIO OU SENHA INCORRETOS. POR GENTILEZA, TENTE NOVAMENTE!" +erro);
                    txtUsuario.Text = ""; //Limpa o campo do botão após o click.
                    txtSenha.Text = "";  //Limpa o campo do botão após o click.
                    txtUsuario.Select(); //O cursor volta para o primeiro campo após o click.
           
            }
            Conexao.Close();  //Fecha a conexão após a inserção dos dados correto.

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

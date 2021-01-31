using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CRUD_Alunos
{
    public partial class Form2 : Form
    {
        DatabaseStart databasestart = new DatabaseStart();
        public Form2()
        {
            InitializeComponent();
        }
        LoginData logindata = new LoginData();
        private void btEntrar_Click(object sender, EventArgs e)
        {
            var username = tbUsername.Text;
            var password = tbPassword.Text;
            
            if(logindata.ConfereLogin(username, password))
            {
                MessageBox.Show("Logado com sucesso!", "caption", MessageBoxButtons.OK);
                this.Hide();
                CrudWindow frmCrud = new CrudWindow();
                frmCrud.Show();
                
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {            
            databasestart.GetConnection();
        }

        private void btCadastro_Click(object sender, EventArgs e)
        {
            
            var username = tbUsername.Text;
            var password = tbPassword.Text;
            logindata.CadastraUsuario(username, password);
            MessageBox.Show("Usuário cadastrado com sucesso!");
        }
    }
}

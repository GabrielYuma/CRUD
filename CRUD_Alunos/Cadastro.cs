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
    public partial class Cadastro : Form
    {
        LoginData logindata = new LoginData();
        public Cadastro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var username = tbUserCad.Text;
            var password = tbPassCad.Text;
            var cargo = int.Parse(ddCad.Text);
            logindata.CadastraUsuario(username, password, cargo);
            MessageBox.Show("Usuário cadastrado com sucesso!");
            Form2 form = new Form2();
            this.Hide();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            this.Hide();
            form.Show();
        }
    }
}

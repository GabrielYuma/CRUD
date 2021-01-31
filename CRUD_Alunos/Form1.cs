using System;
using System.Windows.Forms;
using System.IO;

namespace CRUD_Alunos
{
    public partial class CrudWindow : Form
    {
        static Database database = new Database();
        public CrudWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string nome = tbNome.Text;
            float salario = float.Parse(tbSalario.Text);
            int tel = int.Parse(tbTelefone.Text);
            database.InsertData(nome, salario, tel);
            GetFuncionarioRecord();
            MessageBox.Show("Funcionário adicionado com sucesso!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            database.GetConnection();
            if (new FileInfo("database.sqlite3").Length > 0) { GetFuncionarioRecord(); }           
        }

        private void GetFuncionarioRecord()
        {
            FuncionarioDataGridView.DataSource = database.SelectCommand();
        }

        private void ClearFields()
        {            
            tbID.Clear();
            tbNome.Clear();
            tbSalario.Clear();
            tbTelefone.Clear();
        }

        private void FuncionarioDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbID.Text = FuncionarioDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            tbNome.Text = FuncionarioDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            tbSalario.Text = FuncionarioDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            tbTelefone.Text = FuncionarioDataGridView.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            database.UpdateData(int.Parse(tbID.Text), tbNome.Text, float.Parse(tbSalario.Text), int.Parse(tbTelefone.Text));
            GetFuncionarioRecord();
            ClearFields();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           switch(MessageBox.Show("Deseja mesmo deletar esse funcionário?", "caption", MessageBoxButtons.YesNo))
            {
                case DialogResult.Yes: database.DeleteData(int.Parse(tbID.Text));
                    GetFuncionarioRecord();
                    break;
                
            }
            ClearFields();
        }
    }
}

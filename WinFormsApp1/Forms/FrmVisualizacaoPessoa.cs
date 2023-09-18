using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm.Desktop.Services.Interfaces;
using WinFormsApp1.Entites;

namespace WinForm.Desktop.Forms
{
    public partial class FrmVisualizacaoPessoa : Form
    {

        Pessoa pessoa;

        public FrmVisualizacaoPessoa()
        {
            InitializeComponent();
            pessoa = new Pessoa();
        }

        internal void CarregarDadosGridPessoa(Pessoa pessoaDataGrid)
        {
            pessoa.Id = pessoaDataGrid.Id;
            pessoa.Nome = pessoaDataGrid.Nome;
            pessoa.Sobrenome = pessoaDataGrid.Sobrenome;
            pessoa.Data_Nascimento = pessoaDataGrid.Data_Nascimento;
            pessoa.Sexo = pessoaDataGrid.Sexo;


            textBox3.Text = pessoa.Id.ToString();
            textBox1.Text = pessoa.Nome;
            textBox2.Text = pessoa.Sobrenome;
            dateTimePicker1.Text = pessoa.Data_Nascimento.ToString("dd/MM/yyyy");

            if (pessoa.Sexo == "f")
                comboBox1.Text = "Feminimo";

            if (pessoa.Sexo == "m")
                comboBox1.Text = "Masculino";



        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

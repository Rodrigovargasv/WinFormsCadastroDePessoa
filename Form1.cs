
using System.Data;
using System.Windows.Forms;
using WinFormsApp1.Entites;
using WinFormsApp1.Interfaces;

namespace WinFormsApp1
{
    public partial class FrmCadastroPessoa : Form
    {

        private readonly IPessoaService _pessoaService;

        private readonly IErroProvider _erroProvider;


        public FrmCadastroPessoa()
        {
            InitializeComponent();

        }


        public FrmCadastroPessoa(IPessoaService pessoaService, IErroProvider erroProvider)
        {
            InitializeComponent();
            _pessoaService = pessoaService;
            _erroProvider = erroProvider;
            CarregarDadosFormulario();
            WindowState = FormWindowState.Maximized;


        }

        private void CadastrarPessoa_Click(object sender, EventArgs e)
        {
            var form2 = new Form2(_pessoaService, _erroProvider);
            form2.ShowDialog();

            CarregarDadosFormulario();
        }




        private async Task CarregarDadosFormulario()
        {

            var pessoaTask = _pessoaService.GetAllPessoasAsync();

            var pessoas = await pessoaTask;

            ConfiguracaoDataGridView(pessoas.ToList());
        }

        private void ConfiguracaoDataGridView(List<Pessoa> pessoas)
        {

            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Nome", typeof(string));
            dataTable.Columns.Add("Sobrenome", typeof(string));
            dataTable.Columns.Add("Data de Nacimento", typeof(DateTime));
            dataTable.Columns.Add("Sexo", typeof(string));

            foreach (var pessoa in pessoas)
            {
                dataTable.Rows.Add(new object[]
                {
                    pessoa.Id,
                    pessoa.Nome,
                    pessoa.Sobrenome,
                    pessoa.Data_Nascimento,
                    pessoa.Sexo
                });

            }

            dataGridView1.DataSource = dataTable;
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[3].Width = 150;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void SairCadastro_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

    }
}


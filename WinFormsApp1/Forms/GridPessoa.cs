
using System.Data;
using System.Windows.Forms;
using WinForm.Desktop.Forms;
using WinForm.Desktop.Services;
using WinForm.Desktop.Services.Interfaces;
using WinFormsApp1.Entites;

namespace WinFormsApp1
{
    public partial class GridPessoa : Form
    {

        private readonly IPessoaService _pessoaService;

        private readonly IErroProvider _erroProvider;



        private Pessoa pessoa;
        public GridPessoa()
        {

        }

        public GridPessoa(IPessoaService pessoaService, IErroProvider erroProvider)
        {
            InitializeComponent();
            _pessoaService = pessoaService;
            _erroProvider = erroProvider;
            CarregarDadosFormulario();
            pessoa = new Pessoa();
            WindowState = FormWindowState.Maximized;


        }

        private void BtnCadastrarPessoa_Click(object sender, EventArgs e)
        {
            var frmCadastroPessoa = new FrmCadastroPessoa(_pessoaService, _erroProvider);
            frmCadastroPessoa.ShowDialog();

            CarregarDadosFormulario();
        }

        private void BtnEditarPessoa_Click(object sender, EventArgs e)
        {

            try
            {
                var frmEditarPessoa = new FrmEditarPessoa(_pessoaService, _erroProvider);

                frmEditarPessoa.CarregarDadosGridPessoa(pessoa);

                frmEditarPessoa.ShowDialog();
                CarregarDadosFormulario();

            }
            catch
            {
                DataGridViewRow firstRow = dataGridView1.Rows[0];

                pessoa.Id = Convert.ToInt32(firstRow.Cells["Id"].Value);
                pessoa.Nome = Convert.ToString(firstRow.Cells["Nome"].Value);
                pessoa.Sobrenome = Convert.ToString(firstRow.Cells["Sobrenome"].Value);
                pessoa.Data_Nascimento = Convert.ToDateTime(firstRow.Cells["Data de Nacimento"].Value);
                pessoa.Sexo = Convert.ToString(firstRow.Cells["Sexo"].Value);

                var frmEditarPessoa = new FrmEditarPessoa(_pessoaService, _erroProvider);
                frmEditarPessoa.CarregarDadosGridPessoa(pessoa);

                frmEditarPessoa.ShowDialog();
                CarregarDadosFormulario();


            }


        }
        private void BtnVisualizacaoPessoa_Click(object sender, EventArgs e)
        {
            try
            {
                var frmVizualizacaoPessoa = new FrmVisualizacaoPessoa();

                frmVizualizacaoPessoa.CarregarDadosGridPessoa(pessoa);

                frmVizualizacaoPessoa.ShowDialog();

            }
            catch
            {
                DataGridViewRow firstRow = dataGridView1.Rows[0];

                pessoa.Id = Convert.ToInt32(firstRow.Cells["Id"].Value);
                pessoa.Nome = Convert.ToString(firstRow.Cells["Nome"].Value);
                pessoa.Sobrenome = Convert.ToString(firstRow.Cells["Sobrenome"].Value);
                pessoa.Data_Nascimento = Convert.ToDateTime(firstRow.Cells["Data de Nacimento"].Value);
                pessoa.Sexo = Convert.ToString(firstRow.Cells["Sexo"].Value);

                var frmVizualizacaoPessoa = new FrmVisualizacaoPessoa();
                frmVizualizacaoPessoa.CarregarDadosGridPessoa(pessoa);

                frmVizualizacaoPessoa.ShowDialog();

            }

        }

        private void BtnExcluirPessoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ter certeza que deseja continuar?", "Excluir Pessoa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                

                if(pessoa.Id == null)
                {
                    DataGridViewRow firstRow = dataGridView1.Rows[0];
                    pessoa.Id = Convert.ToInt32(firstRow.Cells["Id"].Value);


                    _pessoaService.DeletePessoaAsync(Convert.ToInt32(pessoa.Id));

                }
                else
                {
                    _pessoaService.DeletePessoaAsync(Convert.ToInt32(pessoa.Id));
                }


                CarregarDadosFormulario();
            }
            else if (result == DialogResult.No)
            {
                Console.WriteLine("Usuário escolheu 'Não'");
               this.Hide();
            }
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

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    pessoa.Id = Convert.ToInt32(row.Cells["Id"].Value);
                    pessoa.Nome = Convert.ToString(row.Cells["Nome"].Value);
                    pessoa.Sobrenome = Convert.ToString(row.Cells["Sobrenome"].Value);
                    pessoa.Data_Nascimento = Convert.ToDateTime(row.Cells["Data de Nacimento"].Value);
                    pessoa.Sexo = Convert.ToString(row.Cells["Sexo"].Value);
                }
            }
            catch
            {
                return;
            }


        }


        private void SairCadastro_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}


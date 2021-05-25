using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Repositorio;

namespace TrabDesktop
{
    public partial class Form2 : Form
    {
        usuario model;

        public Form2()
        {
            InitializeComponent();
        }
        void carregaProp()
        {
            model.usu_nome = txtnome.Text;
            model.usu_cpf = txtcpf.Text;
            model.usu_email = txtemail.Text;
            model.usu_telefone = txttelefone.Text;
            model.usu_senha = txtsenha.Text;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtnome.Text != "" && txtcpf.Text != "" && txttelefone.Text != "" && txtemail.Text != "" && txtsenha.Text != "")
                {
                    carregaProp();
                    (new UsuarioRepositorio()).AddUsuario(model);
                    System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
                    t.SetApartmentState(ApartmentState.STA);
                    t.IsBackground = true;
                    t.Start();
                    MessageBox.Show("Salvo com sucesso!");
                }
                else
                {
                    MessageBox.Show("Favor, informar todos os campos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void ThreadProc()
        {
            Application.Run(new Form1());
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            model = new usuario();
        }
    }
}

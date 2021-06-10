using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using Repositorio;

namespace TrabDesktop
{
    public partial class Form4 : Form
    {
        usuario usuario = new usuario();
        public Form4()
        {
            InitializeComponent();
        }
        private void btnlistar_Click(object sender, EventArgs e)
        {
            GetAllUsuarios();
        }
        string URI = "https://notepadeng.herokuapp.com/view/usuario/";
        private async void GetAllUsuarios()
        {
            URI += "listar.php";
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        //clienteUri = response.Headers.Location;
                        var ConteudoJsonString = await response.Content.ReadAsStringAsync();
                        dgvDados.DataSource = JsonConvert.DeserializeObject<usuario[]>(ConteudoJsonString);

                    }
                    else
                    {
                        MessageBox.Show("Não foi possível obter o usuario : " + response.StatusCode);
                    }
                }
            }
            URI = "https://notepadeng.herokuapp.com/view/usuario/";

        }
        int codigoUsuario = 1;
        private void InputBox()
        {
            /* usando a função VB.Net para exibir um prompt para o usuário informar a senha */
            string Prompt = "Informe o código do usuario.";
            string Titulo = "Aula de Engenharia";
            string Resultado = Microsoft.VisualBasic.Interaction.InputBox(Prompt, Titulo, "9", 600, 350);
            /* verifica se o resultado é uma string vazia o que indica que foi cancelado. */
            if (Resultado != "")
            {
                codigoUsuario = Convert.ToInt32(Resultado);
            }
            else
            {
                codigoUsuario = -1;
            }
        }
        private async void UpdateUsuario(int codUsuario)
        {
            URI += "editar.php";
            usuario usu = new usuario();
            usu.usu_codigo = codUsuario;
            usu.usu_nome = "Teste";
            usu.usu_senha = "123";
            usu.usu_email = "Teste@gmail.com";
            usu.usu_cpf = "321234132";
            usu.usu_telefone = "1244554";

            using (var client = new HttpClient())
            {
                HttpResponseMessage responseMessage = await client.PutAsJsonAsync(URI, usu);
                if (responseMessage.IsSuccessStatusCode)
                {
                    MessageBox.Show("Usuario atualizado");
                }
                else
                {
                    MessageBox.Show("Falha ao atualizar o Usuario : " + responseMessage.StatusCode);
                }
            }
            URI = "https://notepadeng.herokuapp.com/view/usuario/";
            GetAllUsuarios();
        }

        private void btnalterar_Click(object sender, EventArgs e)
        {
            InputBox();
            if (codigoUsuario != -1)
            {
                UpdateUsuario(codigoUsuario);
            }
        }
        private async void DeleteUsuario(int codUsuario)
        {
            URI += "excluir.php";
            int usu_codigo = codUsuario;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URI);
                HttpResponseMessage responseMessage = await client.DeleteAsync(String.Format("{0}/{1}", URI, usu_codigo));
                if (responseMessage.IsSuccessStatusCode)
                {
                    MessageBox.Show("Usuario excluído com sucesso");
                }
                else
                {
                    MessageBox.Show("Falha ao excluir o Usuario  : " + responseMessage.StatusCode);
                }
            }
            URI = "https://notepadeng.herokuapp.com/view/usuario/";
            GetAllUsuarios();
        }
        private void btnexcluir_Click(object sender, EventArgs e)
        {
            InputBox();
            if (codigoUsuario != -1)
            {
                DeleteUsuario(codigoUsuario);
            }

        }
        
    }
}

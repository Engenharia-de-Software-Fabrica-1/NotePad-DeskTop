using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;


namespace Repositorio
{
    public class UsuarioRepositorio
    {
        public void inserir(usuario u)
        {
            using (notepadengEntities db = new notepadengEntities())
            {
                db.InserirUsuario(u.usu_nome, u.usu_cpf, u.usu_email, u.usu_telefone, u.usu_senha);
                db.SaveChanges();
            }
        }

        string URI = "https://notepadeng.herokuapp.com/view/usuario/";

        public async void AddUsuario(usuario u)
        {
            try
            {
                URI += "inserir.php";
                usuario usu = new usuario();
                //prod.Id = codProduto;
                usu.usu_nome = u.usu_nome;
                usu.usu_email = u.usu_email;
                usu.usu_cpf = u.usu_cpf;
                usu.usu_senha = u.usu_senha;
                usu.usu_telefone = u.usu_telefone;

                using (var client = new HttpClient())
                {
                    var serializedUsuario = JsonConvert.SerializeObject(usu);
                    var content = new StringContent(serializedUsuario, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync(URI, content);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

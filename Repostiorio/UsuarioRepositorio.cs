using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class UsuarioRepositorio
    {
        public void inserir(usuario u)
        {
            using (notepadengEntities db = new notepadengEntities())
            {
                db.InsereUsuario(u.usu_nome, u.usu_cpf, u.email, u.telefone);
                db.SaveChanges();
            }
        }
    }
}

using MarcaPlantao.Aplicacao.Dados.Profissionais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Dados.Usuario
{
    public class UsuarioDados
    {
        public UsuarioDados()
        {
        }

        public UsuarioDados(bool bloqueado, string email, string token, bool master, ProfissionalDados profissional)
        {
            Bloqueado = bloqueado;
            Email = email;
            Token = token;
            Master = master;
            Profissional = profissional;
        }

        public bool Bloqueado { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }

        public bool Master { get; set; }

        public Guid? ClinicaId { get; set; }

        public ProfissionalDados Profissional { get; set; }
    }
}

using MarcaPlantao.Dominio.Profissionais;
using MarcaPlantao.Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Infra.Repositorios.Profissionais
{
    public class ProfissionalRepositorio : Repository<Profissional>, IProfissionalRepositorio
    {
        public ProfissionalRepositorio(ContextoMarcaPlantao db) : base(db) { }

        public async Task<bool> ValidarProfissional(string crm, string cpf)
        {
           return (await Buscar(x => crm.Equals(x.CRM) && cpf.Equals(x.CPF))).Count() > 0;
        }
    }
}

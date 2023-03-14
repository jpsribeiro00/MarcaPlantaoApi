using MarcaPlantao.Dominio.Profissionais;
using MarcaPlantao.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Profissional> ObterProfissionalPorUsuario(string UsuarioId)
        {
            return await Db.Profissionais
                .Include(x => x.Especializacoes)
                .Where(x => x.UserId == UsuarioId)
                .FirstOrDefaultAsync();
        }

        public async Task<Profissional> ObterProfissionalPorId(Guid id)
        {
            return await Db.Profissionais
                .Include(x => x.Especializacoes)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Profissional>> ObterTodosProfissionais()
        {
            return await Db.Profissionais
                .Include(x => x.Especializacoes)
                .ToListAsync();
        }

        public async Task<bool> ValidarProfissional(string crm, string cpf)
        {
           return (await Buscar(x => crm.Equals(x.CRM) && cpf.Equals(x.CPF))).Count() > 0;
        }
    }
}

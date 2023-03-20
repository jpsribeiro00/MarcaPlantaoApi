using MarcaPlantao.Dominio.Clinicas;
using MarcaPlantao.Infra.Contexto;
using MarcaPlantao.Infra.Repositorios.Enderecos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Infra.Repositorios.Clinicas
{
    public class ClinicaRepositorio : Repository<Clinica>, IClinicaRepositorio
    {
        public ClinicaRepositorio(ContextoMarcaPlantao db) : base(db)
        {
        }

        public async Task<Clinica> ObterClinicaEnderecoPorId(Guid id)
        {
            return await Db.Clinicas.AsNoTracking()
                .Include(x => x.Endereco)
                .Include(x => x.Avaliacoes).ThenInclude(x => x.Profissional)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Clinica>> ObterTodasClinicaEndereco()
        {
            return await Db.Clinicas.AsNoTracking()
                .Include(x => x.Endereco)
                .Include(x => x.Avaliacoes).ThenInclude(x => x.Profissional)
                .ToListAsync();
        }
    }
}

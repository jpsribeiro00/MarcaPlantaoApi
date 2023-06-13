using MarcaPlantao.Dominio.Alertas;
using MarcaPlantao.Dominio.Profissionais;
using MarcaPlantao.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Infra.Repositorios.Alertas
{
    public class AlertaRepositorio : Repository<Alerta>, IAlertaRepositorio
    {
        public AlertaRepositorio(ContextoMarcaPlantao db) : base(db)
        {
        }

        public async Task<List<Alerta>> ObterAlertaPorUsuario(Guid profissionalId)
        {
            var y = await Db.Profissionais.AsNoTracking().Where(x => x.Id == profissionalId).FirstOrDefaultAsync();

            return await Db.Alertas.AsNoTracking().Where(x => x.UserId == y.UserId).ToListAsync();
        }

        public async Task<List<Alerta>> ObterAlertaPorClinica(Guid ClinicaId)
        {
            return await Db.Alertas.AsNoTracking().Where(x => x.ClinicaId == ClinicaId).ToListAsync();
        }
    }
}

using MarcaPlantao.Dominio.Alertas;
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

        public async Task<List<Alerta>> ObterAlertaPorUsuario(string UsuarioId)
        {
            return await Db.Alertas.AsNoTracking().Where(x => x.UserId == UsuarioId).ToListAsync();
        }

        public async Task<List<Alerta>> ObterAlertaPorClinica(Guid ClinicaId)
        {
            return await Db.Alertas.AsNoTracking().Where(x => x.ClinicaId == ClinicaId).ToListAsync();
        }
    }
}

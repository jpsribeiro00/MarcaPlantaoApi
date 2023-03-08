using MarcaPlantao.Dominio.Clinicas;
using MarcaPlantao.Infra.Contexto;
using MarcaPlantao.Infra.Repositorios.Enderecos;
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
    }
}

using MarcaPlantao.Dominio.Enderecos;
using MarcaPlantao.Dominio.Profissionais;
using MarcaPlantao.Infra.Contexto;
using MarcaPlantao.Infra.Repositorios.Profissionais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Infra.Repositorios.Enderecos
{
    public class EnderecoRepositorio : Repository<Endereco>, IEnderecoRepositorio
    {
        public EnderecoRepositorio(ContextoMarcaPlantao db) : base(db)
        {
        }
    }
}

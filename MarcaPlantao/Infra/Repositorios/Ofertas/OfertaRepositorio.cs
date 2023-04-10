using MarcaPlantao.Aplicacao.Dados.Ofertas;
using MarcaPlantao.Dominio.Ofertas;
using MarcaPlantao.Dominio.Plantoes;
using MarcaPlantao.Dominio.Profissionais;
using MarcaPlantao.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Infra.Repositorios.Ofertas
{
    public class OfertaRepositorio : Repository<Oferta>, IOfertaRepositorio
    {
        public OfertaRepositorio(ContextoMarcaPlantao db) : base(db) { }

        public async Task<Oferta> ObterOfertaModificarProfissionalPorId(Guid id)
        {
            return await Db.Ofertas
                .Include(x => x.Profissionais)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Oferta> ObterOfertaProfissionalEspecializacaoPorId(Guid id)
        {
            return await Db.Ofertas.AsNoTracking()
                .Include(x => x.Profissionais)
                .Include(x => x.Especializacoes)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Oferta>> ObterTodasOfertaProfissionalEspecializacao()
        {
            return await Db.Ofertas.AsNoTracking()
                .Include(x => x.Profissionais)
                .Include(x => x.Especializacoes)
                .ToListAsync();
        }

        public async Task<List<Oferta>> ObterOfertasAbertasParaProfissional()
        {
            List<Oferta> listaOfertas = await Db.Ofertas.AsNoTracking()
                .Include(x => x.Profissionais)
                .Include(x => x.Especializacoes)
                .Include(x => x.Clinica).ThenInclude(x => x.Endereco)
                .ToListAsync();

            return listaOfertas.Where(x => Db.Plantoes.AnyAsync(y => y.OfertaId != x.Id).Result).ToList();
        }
    }
}

﻿using MarcaPlantao.Aplicacao.Dados.Ofertas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Servicos.Ofertas
{
    public interface IOfertaServicoApp
    {
        Task<ObterOfertaDados> AdicionarAsync(AdicionarOfertaDados OfertaDados);

        Task<bool> AtualizarAsync(AtualizarOfertaDados OfertaDados);

        Task<bool> RemoverAsync(Guid id);

        Task<bool> AdicionarProfissionalOfertaAsync(Guid profissionalId, Guid ofertaId);

        Task<bool> RemoverProfissionalOfertaAsync(Guid profissionalId, Guid ofertaId);

        Task<ObterOfertaDados> ObterPorId(Guid id);

        Task<List<ObterOfertaDados>> ObterTodos(DateTime? dataInicio, DateTime? dataFinal, double? valorInicial, double? valorFinal, string? turno);
    }
}

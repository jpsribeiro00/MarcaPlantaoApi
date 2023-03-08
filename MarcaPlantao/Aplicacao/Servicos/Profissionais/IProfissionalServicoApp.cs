﻿using MarcaPlantao.Aplicacao.Dados.Profissionais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Servicos.Profissionais
{
    public interface IProfissionalServicoApp
    {
        Task<bool> AdicionarAsync(ProfissionalDados foto);

        Task<bool> AtualizarAsync(ProfissonalArquivoDados foto);

        Task<bool> RemoverAsync(Guid id);

        Task<ProfissionalDados> ObterPorId(Guid idUsuario);

        Task<List<ProfissionalDados>> ObterTodos();
    }
}

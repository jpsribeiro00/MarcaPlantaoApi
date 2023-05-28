using AutoMapper;
using MarcaPlantao.Aplicacao.Comandos.AvaliacaoComandos;
using MarcaPlantao.Aplicacao.Comandos.PlantaoComandos;
using MarcaPlantao.Dominio.Avaliacao;
using MarcaPlantao.Dominio.Plantoes;
using MarcaPlantao.Infra.Repositorios.Avaliacao;
using MarcaPlantao.Infra.Repositorios.Ofertas;
using MarcaPlantao.Infra.Repositorios.Plantoes;
using MarcaPlantao.Infra.Repositorios.Profissionais;
using MarcaPlantao_Infraestrutura.Comunicacao.Mediador;
using MarcaPlantao_Infraestrutura.Mensagens;
using MarcaPlantao_Infraestrutura.Mensagens.Notificacao;
using MarcaPlantao_Infraestrutura.ObjetoDominio;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Comandos
{
    public class AvaliacaoCommandHandler :
        IRequestHandler<AdicionarAvaliacaoProfissionalClinicaComando, bool>
    {
        private readonly IMediatorHandler mediadorHandler;
        private readonly IMapper mapper;
        private readonly IAvaliacaoProfissionalRepositorio avaliacaoProfissionalRepositorio;

        public AvaliacaoCommandHandler(IMediatorHandler mediadorHandler, IMapper mapper, IAvaliacaoProfissionalRepositorio avaliacaoProfissionalRepositorio)
        {
            this.mediadorHandler = mediadorHandler;
            this.mapper = mapper;
            this.avaliacaoProfissionalRepositorio = avaliacaoProfissionalRepositorio;
        }

        public async Task<bool> Handle(AdicionarAvaliacaoProfissionalClinicaComando request, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidarComando(request)) return false;

                if(!(await avaliacaoProfissionalRepositorio.ObterPorPlantaoId(request.PlantaoId)).Any()) 
                {
                    AvaliacaoProfissional avaliacaoProfissional = new AvaliacaoProfissional();
                    avaliacaoProfissional.ClinicaId = request.ClinicaId;
                    avaliacaoProfissional.PlantaoId = request.PlantaoId;
                    avaliacaoProfissional.ProfissionalId = request.ProfissionalId;
                    avaliacaoProfissional.DataAvaliacao = new DateTime();
                    avaliacaoProfissional.Nota = request.Nota;
                    avaliacaoProfissional.Descricao = request.Descricao;
                }

                await mediadorHandler.PublicarNotificacao(new NotificacaoDominio(request.Tipo, "Já existe avaliação para esse Plantão!"));
                return false;
            }
            catch (DominioException ex)
            {
                await mediadorHandler.PublicarNotificacao(new NotificacaoDominio(request.Tipo, ex.Message));
                return false;
            }
            catch (Exception ex)
            {
                await mediadorHandler.PublicarNotificacao(new NotificacaoDominio(request.Tipo, ex.Message));
                return false;
            }
        }

        private bool ValidarComando(Comando mensagem)
        {
            if (mensagem.EhValido()) return true;

            foreach (var error in mensagem.ResultadoValidacao.Errors)
            {
                mediadorHandler.PublicarNotificacao(new NotificacaoDominio(mensagem.Tipo, error.ErrorMessage));
            }

            return false;
        }
    }
}

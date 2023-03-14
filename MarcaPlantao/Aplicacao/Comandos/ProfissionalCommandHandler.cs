using AutoMapper;
using MarcaPlantao.Aplicacao.Comandos.ProfissionalComandos;
using MarcaPlantao.Aplicacao.Dados.Especializacoes;
using MarcaPlantao.Dominio.Especializacoes;
using MarcaPlantao.Dominio.Ofertas;
using MarcaPlantao.Dominio.Profissionais;
using MarcaPlantao.Infra.Repositorios.Especializacoes;
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
    public class ProfissionalCommandHandler :
        IRequestHandler<AtualizarProfissionalComando, bool>,
        IRequestHandler<RemoverProfissionalComando, bool>,
        IRequestHandler<AdicionarProfissionalComando, bool>
    {
        private readonly IMediatorHandler mediadorHandler;
        private readonly IProfissionalRepositorio profissionalRepositorio;
        private readonly IEspecializacaoRepositorio especializacaoRepositorio;
        private readonly IMapper mapper;

        public ProfissionalCommandHandler(IMediatorHandler mediadorHandler, IProfissionalRepositorio profissionalRepositorio, IEspecializacaoRepositorio especializacaoRepositorio, IMapper mapper)
        {
            this.mediadorHandler = mediadorHandler;
            this.profissionalRepositorio = profissionalRepositorio;
            this.especializacaoRepositorio = especializacaoRepositorio;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(AdicionarProfissionalComando request, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidarComando(request)) return false;

                var profissional = new Profissional();
                profissional.UserId = request.UserId;
                profissional.Genero = request.Genero;
                profissional.Telefone = request.Telefone;
                profissional.DataNascimento = request.DataNascimento;
                profissional.Nome = request.Nome;
                profissional.Imagem = request.Imagem;
                profissional.CRM = request.CRM;
                profissional.CPF = request.CPF;
                profissional.Ofertas = mapper.Map<ICollection<Oferta>>(request.Ofertas);
                profissional.Especializacoes = await BuscarEspecializacoes(request.Especializacoes);

                await profissionalRepositorio.Adicionar(profissional);

                return true;

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

        public async Task<bool> Handle(AtualizarProfissionalComando request, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidarComando(request)) return false;

                var profissional = new Profissional();
                profissional.Id = request.Id;
                profissional.UserId = request.UserId;
                profissional.Genero = request.Genero;
                profissional.Telefone = request.Telefone;
                profissional.DataNascimento = request.DataNascimento;
                profissional.Nome = request.Nome;
                profissional.Imagem = request.Imagem;
                profissional.CRM = request.CRM;
                profissional.CPF = request.CPF;
                profissional.Ofertas = mapper.Map<ICollection<Oferta>>(request.Ofertas);
                profissional.Especializacoes = await BuscarEspecializacoes(request.Especializacoes);

                await profissionalRepositorio.Atualizar(profissional);

                return true;

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

        public async Task<bool> Handle(RemoverProfissionalComando request, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidarComando(request)) return false;

                await profissionalRepositorio.Remover(request.Id);

                return true;
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

        private async Task<List<Especializacao>> BuscarEspecializacoes(List<EspecializacaoSimplificadoDados> especializacoesId)
        {
            var Especializacoes = new List<Especializacao>();

            foreach (EspecializacaoSimplificadoDados item in especializacoesId)
            {
                var especializacaoBanco = await especializacaoRepositorio.ObterPorId(item.Id);

                if (especializacaoBanco != null)
                {
                    Especializacoes.Add(especializacaoBanco);
                }
            }

            return Especializacoes;
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

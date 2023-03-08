using AutoMapper;
using MarcaPlantao.Aplicacao.Comandos.EnderecoComandos;
using MarcaPlantao.Dominio.Enderecos;
using MarcaPlantao.Dominio.Profissionais;
using MarcaPlantao.Infra.Repositorios.Enderecos;
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
    public class EnderecoCommandHandler :
        IRequestHandler<AtualizarEnderecoComando, bool>,
        IRequestHandler<RemoverEnderecoComando, bool>,
        IRequestHandler<AdicionarEnderecoComando, bool>
    {
        private readonly IMediatorHandler mediadorHandler;
        private readonly IEnderecoRepositorio enderecoRepositorio;
        private readonly IMapper mapper;

        public EnderecoCommandHandler(IMediatorHandler mediadorHandler, IEnderecoRepositorio enderecoRepositorio, IMapper mapper)
        {
            this.mediadorHandler = mediadorHandler;
            this.enderecoRepositorio = enderecoRepositorio;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(AdicionarEnderecoComando request, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidarComando(request)) return false;

                var endereco = new Endereco();
                endereco.Bairro = request.Bairro;
                endereco.Cidade = request.Cidade;
                endereco.Cep = request.Cep;
                endereco.Rua = request.Rua;
                endereco.UF = (UF)request.UF;

                await enderecoRepositorio.Adicionar(endereco);

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

        public async Task<bool> Handle(AtualizarEnderecoComando request, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidarComando(request)) return false;

                var endereco = new Endereco();
                endereco.Id = request.Id;
                endereco.Bairro = request.Bairro;
                endereco.Cidade = request.Cidade;
                endereco.Cep = request.Cep;
                endereco.Rua = request.Rua;
                endereco.UF = (UF)request.UF;

                await enderecoRepositorio.Atualizar(endereco);

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

        public async Task<bool> Handle(RemoverEnderecoComando request, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidarComando(request)) return false;

                await enderecoRepositorio.Remover(request.Id);

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

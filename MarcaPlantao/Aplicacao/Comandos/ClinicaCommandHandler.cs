using AutoMapper;
using MarcaPlantao.Aplicacao.Comandos.ClinicaComandos;
using MarcaPlantao.Infra.Repositorios.Clinicas;
using MarcaPlantao.Infra.Repositorios.Enderecos;
using MarcaPlantao_Infraestrutura.Comunicacao.Mediador;
using MarcaPlantao_Infraestrutura.Mensagens.Notificacao;
using MarcaPlantao_Infraestrutura.Mensagens;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarcaPlantao.Dominio.Enderecos;
using MarcaPlantao_Infraestrutura.ObjetoDominio;
using MarcaPlantao.Dominio.Clinicas;
using MarcaPlantao.Dominio.Ofertas;
using MarcaPlantao.Dominio.Profissionais;

namespace MarcaPlantao.Aplicacao.Comandos
{
    public class ClinicaCommandHandler :
        IRequestHandler<AtualizarClinicaComando, bool>,
        IRequestHandler<RemoverClinicaComando, bool>,
        IRequestHandler<AdicionarClinicaComando, bool>
    {
        private readonly IMediatorHandler mediadorHandler;
        private readonly IClinicaRepositorio clinicaRepositorio;
        private readonly IMapper mapper;

        public ClinicaCommandHandler(IMediatorHandler mediadorHandler, IClinicaRepositorio clinicaRepositorio, IMapper mapper)
        {
            this.mediadorHandler = mediadorHandler;
            this.clinicaRepositorio = clinicaRepositorio;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(AdicionarClinicaComando request, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidarComando(request)) return false;

                var clinica = new Clinica();
                clinica.RazaoSocial = request.RazaoSocial;
                clinica.Endereco = mapper.Map<Endereco>(request.Endereco);
                clinica.Imagem = request.Imagem;

                await clinicaRepositorio.Adicionar(clinica);

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

        public async Task<bool> Handle(AtualizarClinicaComando request, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidarComando(request)) return false;

                var clinica = new Clinica();
                clinica.Id = request.Id;
                clinica.RazaoSocial = request.RazaoSocial;
                clinica.Endereco = mapper.Map<Endereco>(request.Endereco);
                clinica.Imagem = request.Imagem;

                await clinicaRepositorio.Atualizar(clinica);

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

        public async Task<bool> Handle(RemoverClinicaComando request, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidarComando(request)) return false;

                await clinicaRepositorio.Remover(request.Id);

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

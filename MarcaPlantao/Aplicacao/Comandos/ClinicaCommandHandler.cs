﻿using AutoMapper;
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
using MarcaPlantao.Infra.Repositorios.Ofertas;
using MarcaPlantao.Infra.Repositorios.Avaliacao;
using MarcaPlantao.Dominio.Avaliacao;
using MarcaPlantao.Dominio.Plantoes;

namespace MarcaPlantao.Aplicacao.Comandos
{
    public class ClinicaCommandHandler :
        IRequestHandler<AtualizarClinicaComando, bool>,
        IRequestHandler<RemoverClinicaComando, bool>,
        IRequestHandler<AdicionarClinicaComando, bool>, 
        IRequestHandler<AdicionarAvaliacaoClinicaComando, bool>
    {
        private readonly IMediatorHandler mediadorHandler;
        private readonly IClinicaRepositorio clinicaRepositorio;
        private readonly IAvaliacaoClinicaRepositorio avaliacaoClinicaRepositorio;
        private readonly IMapper mapper;

        public ClinicaCommandHandler(IMediatorHandler mediadorHandler, IClinicaRepositorio clinicaRepositorio, IAvaliacaoClinicaRepositorio avaliacaoClinicaRepositorio, IMapper mapper)
        {
            this.mediadorHandler = mediadorHandler;
            this.clinicaRepositorio = clinicaRepositorio;
            this.mapper = mapper;
            this.avaliacaoClinicaRepositorio = avaliacaoClinicaRepositorio;
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

                var clinicaExiste = await clinicaRepositorio.ObterPorId(request.Id);

                if (clinicaExiste == null)
                {
                    await mediadorHandler.PublicarNotificacao(new NotificacaoDominio(request.Tipo, "Clinica informada não encontrada."));
                    return false;
                }

                clinicaExiste.RazaoSocial = request.RazaoSocial;
                clinicaExiste.Endereco = mapper.Map<Endereco>(request.Endereco);
                clinicaExiste.Imagem = request.Imagem;
                clinicaExiste.Sobre = request.Sobre;

                await clinicaRepositorio.Atualizar(clinicaExiste);

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

        public async Task<bool> Handle(AdicionarAvaliacaoClinicaComando request, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidarComando(request)) return false;

                var clinicaExiste = await clinicaRepositorio.ObterPorId(request.ClinicaId);

                if (clinicaExiste == null)
                {
                    await mediadorHandler.PublicarNotificacao(new NotificacaoDominio(request.Tipo, "Clinica informada não encontrada."));
                    return false;
                }

                var avaliacaoClinica = new AvaliacaoClinica();
                avaliacaoClinica.Nota = request.Nota;
                avaliacaoClinica.Descricao = request.Descricao;
                avaliacaoClinica.DataAvaliacao = request.DataAvaliacao;
                avaliacaoClinica.ClinicaId = request.ClinicaId;
                avaliacaoClinica.ProfissionalId = request.ProfissionalId;
                avaliacaoClinica.PlantaoId = request.PlantaoId;

                await avaliacaoClinicaRepositorio.Adicionar(avaliacaoClinica);

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

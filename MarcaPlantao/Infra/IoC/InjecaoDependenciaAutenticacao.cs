using MarcaPlantao.Aplicacao.Comandos;
using MarcaPlantao.Aplicacao.Comandos.AlertaComandos;
using MarcaPlantao.Aplicacao.Comandos.AvaliacaoComandos;
using MarcaPlantao.Aplicacao.Comandos.ClinicaComandos;
using MarcaPlantao.Aplicacao.Comandos.EnderecoComandos;
using MarcaPlantao.Aplicacao.Comandos.OfertaComandos;
using MarcaPlantao.Aplicacao.Comandos.PlantaoComandos;
using MarcaPlantao.Aplicacao.Comandos.ProfissionalComandos;
using MarcaPlantao.Aplicacao.Consultas.Alertas;
using MarcaPlantao.Aplicacao.Consultas.AvaliacaoPlantao;
using MarcaPlantao.Aplicacao.Consultas.Clinicas;
using MarcaPlantao.Aplicacao.Consultas.Enderecos;
using MarcaPlantao.Aplicacao.Consultas.Especializacoes;
using MarcaPlantao.Aplicacao.Consultas.EventosClinica;
using MarcaPlantao.Aplicacao.Consultas.EventosProfissionais;
using MarcaPlantao.Aplicacao.Consultas.Ofertas;
using MarcaPlantao.Aplicacao.Consultas.Plantoes;
using MarcaPlantao.Aplicacao.Consultas.Profissionais;
using MarcaPlantao.Aplicacao.Servicos.Acesso;
using MarcaPlantao.Aplicacao.Servicos.Alertas;
using MarcaPlantao.Aplicacao.Servicos.Avaliacao;
using MarcaPlantao.Aplicacao.Servicos.Clinicas;
using MarcaPlantao.Aplicacao.Servicos.Enderecos;
using MarcaPlantao.Aplicacao.Servicos.Ofertas;
using MarcaPlantao.Aplicacao.Servicos.Plantoes;
using MarcaPlantao.Aplicacao.Servicos.Profissionais;
using MarcaPlantao.Dominio.Autorizacao;
using MarcaPlantao.Dominio.Ofertas;
using MarcaPlantao.Dominio.Usuarios;
using MarcaPlantao.Infra.Contexto;
using MarcaPlantao.Infra.Repositorios.Alertas;
using MarcaPlantao.Infra.Repositorios.Avaliacao;
using MarcaPlantao.Infra.Repositorios.Clinicas;
using MarcaPlantao.Infra.Repositorios.Consultas.EventosClinica;
using MarcaPlantao.Infra.Repositorios.Consultas.EventosProfissional;
using MarcaPlantao.Infra.Repositorios.Enderecos;
using MarcaPlantao.Infra.Repositorios.Especializacoes;
using MarcaPlantao.Infra.Repositorios.Ofertas;
using MarcaPlantao.Infra.Repositorios.Plantoes;
using MarcaPlantao.Infra.Repositorios.Profissionais;
using MarcaPlantao_Infraestrutura.Comunicacao.Mediador;
using MarcaPlantao_Infraestrutura.Mensagens.Notificacao;
using MarcaPlantao_Infraestrutura.ObjetoDominio;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Infra.IoC
{
    public class InjecaoDependenciaAutenticacao
    {
        public static void RegistrarServicos(IServiceCollection servicos)
        {
            // ASP.NET HttpContext dependency
            servicos.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // ASP.NET Authorization Polices
            servicos.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Domain Bus (Mediator)
            servicos.AddScoped<IMediatorHandler, MediatorHandler>();

            // Domain - Events
            servicos.AddScoped<INotificationHandler<NotificacaoDominio>, NotificacaoDominioHandler>();

            // Infra - Data
            servicos.AddDbContext<ContextoMarcaPlantao>();

            servicos.AddDbContext<AppDbContext>();
            servicos.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            // Infra - Identity
            servicos.AddScoped<Dominio.Interfaces.IUsuarioAplicacao, UsuarioAplicacao>();

            servicos.AddScoped<IAutenticacaoServico, AutenticacaoServico>();

            //Repositorio
            servicos.AddScoped<IProfissionalRepositorio, ProfissionalRepositorio>();

            servicos.AddScoped<IEnderecoRepositorio, EnderecoRepositorio>();

            servicos.AddScoped<IClinicaRepositorio, ClinicaRepositorio>();

            servicos.AddScoped<IOfertaRepositorio, OfertaRepositorio>();

            servicos.AddScoped<IEspecializacaoRepositorio, EspecializacaoRepositorio>();

            servicos.AddScoped<IPlantaoRepositorio, PlantaoRepositorio>();

            servicos.AddScoped<IEventoClinicaRepositorio, EventoClinicaRepositorio>();

            servicos.AddScoped<IEventosProfissionalRepositorio, EventosProfissionalRepositorio>();

            servicos.AddScoped<IAvaliacaoProfissionalRepositorio, AvaliacaoProfissionalRepositorio>();

            servicos.AddScoped<IAvaliacaoClinicaRepositorio, AvaliacaoClinicaRepositorio>();

            servicos.AddScoped<IAlertaRepositorio, AlertaRepositorio>();

            //Servicos
            servicos.AddScoped<IProfissionalServicoApp, ProfissionalServicoApp>();

            servicos.AddScoped<IEnderecoServicoApp, EnderecoServicoApp>();

            servicos.AddScoped<IClinicaServicoApp, ClinicaServicoApp>();

            servicos.AddScoped<IOfertaServicoApp, OfertaServicoApp>();

            servicos.AddScoped<IPlantaoServicoApp, PlantaoServicoApp>();

            servicos.AddScoped<IAlertaServicoApp, AlertaServicoApp>();

            servicos.AddScoped<IAvaliacaoServicoApp, AvaliacaoServicoApp>();

            //Consultas
            servicos.AddScoped<IProfissionalConsultaApp, ProfissionalConsultaApp>();

            servicos.AddScoped<IEnderecoConsultaApp, EnderecoConsultaApp>();

            servicos.AddScoped<IClinicaConsultaApp, ClinicaConsultaApp>();

            servicos.AddScoped<IOfertaConsultaApp, OfertaConsultaApp>();

            servicos.AddScoped<IEspecializacaoConsultaApp, EspecializacaoConsultaApp>();

            servicos.AddScoped<IPlantaoConsultaApp, PlantaoConsultaApp>();

            servicos.AddScoped<IEventoClinicaConsultaApp, EventoClinicaConsultaApp>();

            servicos.AddScoped<IEventoProfissionalConsultaApp, EventoProfissionalConsultaApp>();

            servicos.AddScoped<IAlertaConsultaApp, AlertaConsultaApp>(); 

            servicos.AddScoped<IAvaliacaoPlantaoConsultaApp, AvaliacaoPlantaoConsultaApp>();

            //Comandos
            servicos.AddScoped<IRequestHandler<AdicionarProfissionalComando, bool>, ProfissionalCommandHandler>();
            servicos.AddScoped<IRequestHandler<AtualizarProfissionalComando, bool>, ProfissionalCommandHandler>();
            servicos.AddScoped<IRequestHandler<RemoverProfissionalComando, bool>, ProfissionalCommandHandler>();

            servicos.AddScoped<IRequestHandler<AdicionarEnderecoComando, bool>, EnderecoCommandHandler>();
            servicos.AddScoped<IRequestHandler<AtualizarEnderecoComando, bool>, EnderecoCommandHandler>();
            servicos.AddScoped<IRequestHandler<RemoverEnderecoComando, bool>, EnderecoCommandHandler>();

            servicos.AddScoped<IRequestHandler<AdicionarClinicaComando, bool>, ClinicaCommandHandler>();
            servicos.AddScoped<IRequestHandler<AtualizarClinicaComando, bool>, ClinicaCommandHandler>();
            servicos.AddScoped<IRequestHandler<RemoverClinicaComando, bool>, ClinicaCommandHandler>();
            servicos.AddScoped<IRequestHandler<AdicionarAvaliacaoClinicaComando, bool>, ClinicaCommandHandler>();

            servicos.AddScoped<IRequestHandler<AdicionarOfertaComando, Entidade>, OfertaCommandHandler>();
            servicos.AddScoped<IRequestHandler<AtualizarOfertaComando, bool>, OfertaCommandHandler>();
            servicos.AddScoped<IRequestHandler<RemoverOfertaComando, bool>, OfertaCommandHandler>();
            servicos.AddScoped<IRequestHandler<AdicionarProfissionalOfertaComando, bool>, OfertaCommandHandler>();
            servicos.AddScoped<IRequestHandler<RemoverProfissionalOfertaComando, bool>, OfertaCommandHandler>();

            servicos.AddScoped<IRequestHandler<AdicionarPlantaoComando, Entidade>, PlantaoCommandHandler>();
            servicos.AddScoped<IRequestHandler<AtualizarPlantaoComando, bool>, PlantaoCommandHandler>();
            servicos.AddScoped<IRequestHandler<RemoverPlantaoComando, bool>, PlantaoCommandHandler>();
            servicos.AddScoped<IRequestHandler<AtualizarStatusPlantaoComando, bool>, PlantaoCommandHandler>();
            servicos.AddScoped<IRequestHandler<EncerrarPlantaoComando, bool>, PlantaoCommandHandler>();

            servicos.AddScoped<IRequestHandler<RemoverAlertaComando, bool>, AlertaCommandHandler>();

            servicos.AddScoped<IRequestHandler<AdicionarAvaliacaoProfissionalClinicaComando, bool>, AvaliacaoCommandHandler>();
        }
    }
}

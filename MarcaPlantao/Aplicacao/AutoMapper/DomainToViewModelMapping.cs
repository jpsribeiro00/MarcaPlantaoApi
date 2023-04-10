using AutoMapper;
using MarcaPlantao.Aplicacao.Dados.Acesso;
using MarcaPlantao.Aplicacao.Dados.Avaliacoes;
using MarcaPlantao.Aplicacao.Dados.Clinicas;
using MarcaPlantao.Aplicacao.Dados.Endereco;
using MarcaPlantao.Aplicacao.Dados.Especializacoes;
using MarcaPlantao.Aplicacao.Dados.EventosClinica;
using MarcaPlantao.Aplicacao.Dados.EventosProfissionais;
using MarcaPlantao.Aplicacao.Dados.Ofertas;
using MarcaPlantao.Aplicacao.Dados.Plantoes;
using MarcaPlantao.Aplicacao.Dados.Profissionais;
using MarcaPlantao.Aplicacao.Dados.Usuario;
using MarcaPlantao.Dominio.Avaliacao;
using MarcaPlantao.Dominio.Clinicas;
using MarcaPlantao.Dominio.Consultas;
using MarcaPlantao.Dominio.Enderecos;
using MarcaPlantao.Dominio.Especializacoes;
using MarcaPlantao.Dominio.Ofertas;
using MarcaPlantao.Dominio.Plantoes;
using MarcaPlantao.Dominio.Profissionais;
using MarcaPlantao.Dominio.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.AutoMapper
{
    class DomainToViewModelMapping : Profile
    {
        public DomainToViewModelMapping() 
        {

            CreateMap<ApplicationUser, AdministratorUserDados>()
                .ForMember(d => d.Master, o => o.MapFrom(sess => sess.Master));

            CreateMap<ApplicationUser, UsuarioDados>()
                .ForMember(d => d.Email, o => o.MapFrom(sess => sess.Email))
                .ForMember(d => d.Bloqueado, o => o.MapFrom(sess => !sess.LockoutEnabled))
                .ForMember(d => d.Master, o => o.MapFrom(sess => sess.Master));

            CreateMap<Profissional, ProfissionalDados>()
                .ForMember(d => d.Imagem, o => o.MapFrom(sess => sess.Imagem)); 

            CreateMap<Profissional, ObterProfissionalDados>()
                .ForMember(d => d.Imagem, o => o.MapFrom(sess => sess.Imagem));

            CreateMap<Endereco, EnderecoDados>();

            CreateMap<Oferta, OfertaDados>();

            CreateMap<Clinica, ClinicaDados>()
                .ForMember(d => d.Imagem, o => o.MapFrom(sess => sess.Imagem));

            CreateMap<Especializacao, EspecializacaoDados>();

            CreateMap<Plantao, PlantaoDados>();

            CreateMap<EventoClinica, EventoClinicaDados>();
            CreateMap<EventoProfissional, EventoProfissionalDados>();

            CreateMap<Especializacao, EspecializacaoSimplificadoDados>()
                .ForMember(d => d.Id, o => o.MapFrom(sess => sess.Id))
                .ForMember(d => d.Descricao, o => o.MapFrom(sess => sess.Descricao));

            CreateMap<Profissional, ProfissionalSimplificadoDados>()
                .ForMember(d => d.Id, o => o.MapFrom(sess => sess.Id))
                .ForMember(d => d.Nome, o => o.MapFrom(sess => sess.Nome))
                .ForMember(d => d.Imagem, o => o.MapFrom(sess => sess.Imagem));

            CreateMap<Oferta, ObterOfertaDados>();

            CreateMap<Oferta, ListaOfertasAbertasProfissional>()
                .ForMember(d => d.Id, o => o.MapFrom(sess => sess.Id))
                .ForMember(d => d.ClinicaId, o => o.MapFrom(sess => sess.ClinicaId))
                .ForMember(d => d.Titulo, o => o.MapFrom(sess => sess.Titulo))
                .ForMember(d => d.RazaoSocial, o => o.MapFrom(sess => sess.Clinica.RazaoSocial))
                .ForMember(d => d.ImagemClinica, o => o.MapFrom(sess => sess.Clinica.Imagem))
                .ForMember(d => d.DataInicial, o => o.MapFrom(sess => sess.DataInicial))
                .ForMember(d => d.DataFinal, o => o.MapFrom(sess => sess.DataFinal))
                .ForMember(d => d.Valor, o => o.MapFrom(sess => sess.Valor))
                .ForMember(d => d.ValorHoraExtra, o => o.MapFrom(sess => sess.ValorHoraExtra))
                .ForMember(d => d.Pagamento, o => o.MapFrom(sess => sess.Pagamento))
                .ForMember(d => d.Endereco, o => o.MapFrom(sess => sess.Clinica.Endereco))
                .ForMember(d => d.Especializacoes, o => o.MapFrom(sess => sess.Especializacoes));

            CreateMap<Profissional, ObterUsuarioProfissional>()
                .ForMember(d => d.Id, o => o.MapFrom(sess => sess.Id))
                .ForMember(d => d.Nome, o => o.MapFrom(sess => sess.Nome))
                .ForMember(d => d.Imagem, o => o.MapFrom(sess => sess.Imagem))
                .ForMember(d => d.Especializacoes, o => o.MapFrom(sess => sess.Especializacoes));

            CreateMap<ApplicationUser, ObterUsuarioAdministrador>()
                .ForMember(d => d.Id, o => o.MapFrom(sess => sess.Id))
                .ForMember(d => d.Master, o => o.MapFrom(sess => sess.Master))
                .ForMember(d => d.Email, o => o.MapFrom(sess => sess.Email))
                .ForMember(d => d.ClinicaId, o => o.MapFrom(sess => sess.ClinicaId));

            CreateMap<AvaliacaoProfissional, AvaliacaoProfissionalSimplificadoDados>()
                .ForMember(d => d.Clinica, o => o.MapFrom(sess => sess.Clinica.RazaoSocial));

            CreateMap<AvaliacaoClinica, AvaliacaoClinicaSimplificadoDados>()
                .ForMember(d => d.Profissional, o => o.MapFrom(sess => sess.Profissional.Nome));
        }
    }
}

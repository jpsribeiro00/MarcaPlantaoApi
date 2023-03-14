using AutoMapper;
using MarcaPlantao.Aplicacao.Comandos.ClinicaComandos;
using MarcaPlantao.Aplicacao.Comandos.EnderecoComandos;
using MarcaPlantao.Aplicacao.Comandos.OfertaComandos;
using MarcaPlantao.Aplicacao.Comandos.PlantaoComandos;
using MarcaPlantao.Aplicacao.Comandos.ProfissionalComandos;
using MarcaPlantao.Aplicacao.Dados.Acesso;
using MarcaPlantao.Aplicacao.Dados.Clinicas;
using MarcaPlantao.Aplicacao.Dados.Endereco;
using MarcaPlantao.Aplicacao.Dados.Especializacoes;
using MarcaPlantao.Aplicacao.Dados.Ofertas;
using MarcaPlantao.Aplicacao.Dados.Plantoes;
using MarcaPlantao.Aplicacao.Dados.Profissionais;
using MarcaPlantao.Aplicacao.Dados.Usuario;
using MarcaPlantao.Dominio.Clinicas;
using MarcaPlantao.Dominio.Enderecos;
using MarcaPlantao.Dominio.Especializacoes;
using MarcaPlantao.Dominio.Ofertas;
using MarcaPlantao.Dominio.Plantoes;
using MarcaPlantao.Dominio.Profissionais;
using MarcaPlantao.Dominio.Usuarios;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.AutoMapper
{
    class ViewModelToDomainMapping : Profile
    {
        public ViewModelToDomainMapping()
        {
            CreateMap<ApplicationUserDados, ApplicationUser>()
                .ConstructUsing(u => new ApplicationUser()
                {
                    UserName = u.Email,
                    Email = u.Email,
                    EmailConfirmed = true,
                });

            CreateMap<AdministratorUserDados, ApplicationUser>()
                .ConstructUsing(u => new ApplicationUser()
                {
                    UserName = u.Email,
                    Email = u.Email,
                    EmailConfirmed = true,
                    Master = u.Master
                });

            CreateMap<UsuarioDados, ApplicationUser>()
                .ConstructUsing(u => new ApplicationUser()
                {
                    UserName = u.Email,
                    Email = u.Email,
                    EmailConfirmed = true,
                    Master = u.Master,
                });

            CreateMap<ProfissionalDados, AdicionarProfissionalComando>()
                .ConstructUsing(x => new AdicionarProfissionalComando( 
                    x.Id,
                    x.Nome,
                    x.DataNascimento,
                    x.Genero,
                    x.Telefone,
                    x.Imagem,
                    x.CRM,
                    x.CPF,
                    x.UserId,
                    x.Ofertas,
                    x.Especializacoes
                ));

            CreateMap<ProfissionalDados, AtualizarProfissionalComando>()
                .ConstructUsing(x => new AtualizarProfissionalComando(
                    x.Id,
                    x.Nome,
                    x.DataNascimento,
                    x.Genero,
                    x.Telefone,
                    x.Imagem,
                    x.CRM,
                    x.CPF,
                    x.UserId,
                    x.Ofertas,
                    x.Especializacoes
                ));

            CreateMap<ProfissionalDados, RemoverProfissionalComando>()
                .ConstructUsing(x => new RemoverProfissionalComando(
                    x.Id
                ));

            CreateMap<ProfissionalDados, Profissional>();

            CreateMap<ProfissonalArquivoDados, ProfissionalDados>()
                .ForMember(d => d.Imagem, o => o.MapFrom(sess => FormatarImagemArquivoByte(sess.Imagem)));

            CreateMap<ClinicaArquivoDados, ClinicaDados>()
                .ForMember(d => d.Imagem, o => o.MapFrom(sess => FormatarImagemArquivoByte(sess.Imagem))); ;

            CreateMap<AdicionarOfertaDados, AdicionarOfertaComando>()
                .ConstructUsing(x => new AdicionarOfertaComando(
                    x.Id,
                    x.Titulo,
                    x.Descricao,
                    x.DataInicial,
                    x.DataFinal,
                    x.Turno,
                    x.Valor,
                    x.ValorHoraExtra,
                    x.DataCadastro,
                    x.Pagamento,
                    x.Especializacoes,
                    x.ClinicaId
                ));

            CreateMap<AtualizarOfertaDados, AtualizarOfertaComando>()
                .ConstructUsing(x => new AtualizarOfertaComando(
                    x.Id,
                    x.Titulo,
                    x.Descricao,
                    x.DataInicial,
                    x.DataFinal,
                    x.Turno,
                    x.Valor,
                    x.ValorHoraExtra,
                    x.DataCadastro,
                    x.Pagamento
                ));

            CreateMap<OfertaDados, RemoverOfertaComando>()
                .ConstructUsing(x => new RemoverOfertaComando(
                    x.Id
                ));

            CreateMap<OfertaDados, Oferta>();

            CreateMap<EnderecoDados, AdicionarEnderecoComando>()
                .ConstructUsing(x => new AdicionarEnderecoComando(
                    x.Id,
                    x.Bairro,
                    x.Cidade,
                    x.Rua,
                    x.Cep,
                    x.UF
                ));

            CreateMap<EnderecoDados, AtualizarEnderecoComando>()
                .ConstructUsing(x => new AtualizarEnderecoComando(
                    x.Id,
                    x.Bairro,
                    x.Cidade,
                    x.Rua,
                    x.Cep,
                    x.UF
                ));

            CreateMap<EnderecoDados, RemoverEnderecoComando>()
                .ConstructUsing(x => new RemoverEnderecoComando(
                    x.Id
                ));

            CreateMap<EnderecoDados, Endereco>();

            CreateMap<ClinicaDados, AdicionarClinicaComando>()
                .ConstructUsing(x => new AdicionarClinicaComando(
                    x.Id,
                    x.RazaoSocial,
                    x.Endereco,
                    x.Imagem
                ));

            CreateMap<ClinicaDados, AtualizarClinicaComando>()
                .ConstructUsing(x => new AtualizarClinicaComando(
                    x.Id,
                    x.RazaoSocial,
                    x.Endereco,
                    x.Imagem
                ));

            CreateMap<ClinicaDados, RemoverClinicaComando>()
                .ConstructUsing(x => new RemoverClinicaComando(
                    x.Id
                ));

            CreateMap<ClinicaDados, Clinica>();

            CreateMap<EspecializacaoDados, Especializacao>();

            CreateMap<GerarPlantaoDados, AdicionarPlantaoComando>()
                .ConstructUsing(x => new AdicionarPlantaoComando(
                    x.OfertaId,
                    x.ProfissionalId
                ));

            CreateMap<PlantaoDados, AtualizarPlantaoComando>()
                .ConstructUsing(x => new AtualizarPlantaoComando(
                    x.Id,
                    x.Status,
                    x.DataInicial,
                    x.DataFinal,
                    x.ValorTotal,
                    x.HoraExtra,
                    x.Desconto,
                    x.StatusPagamento,
                    x.DataPagamento,
                    x.Comprovante,
                    x.DataCadastro,
                    x.Profissional,
                    x.Oferta
                ));

            CreateMap<PlantaoDados, RemoverPlantaoComando>()
                .ConstructUsing(x => new RemoverPlantaoComando(
                    x.Id
                ));

            CreateMap<PlantaoDados, Plantao>();
        }

        public byte[] FormatarImagemArquivoByte(IFormFile arquivo) 
        {
            if (arquivo != null && arquivo.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    arquivo.CopyTo(ms);
                    return ms.ToArray();
                }
            }

            return null;
        }
    }
}

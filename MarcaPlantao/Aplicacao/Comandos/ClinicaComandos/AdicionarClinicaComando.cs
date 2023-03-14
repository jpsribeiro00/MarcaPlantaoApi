using FluentValidation;
using MarcaPlantao.Aplicacao.Comandos.EnderecoComandos;
using MarcaPlantao.Aplicacao.Dados.Endereco;
using MarcaPlantao.Aplicacao.Dados.Ofertas;
using MarcaPlantao.Dominio.Ofertas;
using MarcaPlantao_Infraestrutura.Mensagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Comandos.ClinicaComandos
{
    public class AdicionarClinicaComando : Comando
    {
        public Guid Id { get; set; }
        public string RazaoSocial { get; set; }
        public EnderecoDados Endereco { get; set; }
        public byte[]? Imagem { get; set; }

        public AdicionarClinicaComando(Guid id, string razaoSocial, EnderecoDados endereco, byte[]? imagem)
        {
            Id = id;
            RazaoSocial = razaoSocial;
            Endereco = endereco;
            Imagem = imagem;
        }

        public override bool EhValido()
        {
            ResultadoValidacao = new AdicionarClinicaValidacao().Validate(this);
            return ResultadoValidacao.IsValid;
        }
    }

    public class AdicionarClinicaValidacao : AbstractValidator<AdicionarClinicaComando>
    {
        public AdicionarClinicaValidacao()
        {

            RuleFor(c => c.RazaoSocial)
                .NotEmpty()
                .WithMessage("Razão Social não foi informado.");

            RuleFor(c => c.Endereco)
                .NotEmpty()
                .WithMessage("Endereço não foi informado.");
        }
    }
}

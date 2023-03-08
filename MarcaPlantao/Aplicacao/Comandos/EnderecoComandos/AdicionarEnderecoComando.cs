using FluentValidation;
using MarcaPlantao.Aplicacao.Comandos.ProfissionalComandos;
using MarcaPlantao_Infraestrutura.Mensagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Comandos.EnderecoComandos
{
    public class AdicionarEnderecoComando : Comando
    {
        public Guid Id { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Rua { get; set; }
        public string Cep { get; set; }
        public int UF { get; set; }

        public AdicionarEnderecoComando(Guid id, string bairro, string cidade, string rua, string cep, int uF)
        {
            Id = id;
            Bairro = bairro;
            Cidade = cidade;
            Rua = rua;
            Cep = cep;
            UF = uF;
        }

        public override bool EhValido()
        {
            ResultadoValidacao = new AdicionarEnderecoValidacao().Validate(this);
            return ResultadoValidacao.IsValid;
        }
    }

    public class AdicionarEnderecoValidacao : AbstractValidator<AdicionarEnderecoComando>
    {
        public AdicionarEnderecoValidacao()
        {

            RuleFor(c => c.Bairro)
                .NotEmpty()
                .WithMessage("Bairro não foi informado.");

            RuleFor(c => c.Cidade)
                .NotEmpty()
                .WithMessage("Cidade não foi informado.");

            RuleFor(c => c.Rua)
                .NotEmpty()
                .WithMessage("Rua não foi informado.");

            RuleFor(c => c.Cep)
                .NotEmpty()
                .WithMessage("Cep não foi informado.");
        }
    }
}

using FluentValidation;
using MarcaPlantao_Infraestrutura.Mensagens;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.Comandos.ProfissionalComandos
{
    public class RemoverProfissionalComando : Comando
    {
        public Guid Id { get; set; }

        public RemoverProfissionalComando(Guid id)
        {
            Id = id;
        }

        public override bool EhValido()
        {
            ResultadoValidacao = new RemoverProfissionalValidacao().Validate(this);
            return ResultadoValidacao.IsValid;
        }
    }

    public class RemoverProfissionalValidacao : AbstractValidator<RemoverProfissionalComando>
    {
        public RemoverProfissionalValidacao()
        {

            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Id não foi informado.");
        }
    }
}

﻿using FluentValidation;
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
    public class AtualizarClinicaComando : Comando
    {
        public Guid Id { get; set; }
        public string RazaoSocial { get; set; }
        public EnderecoDados Endereco { get; set; }
        public byte[]? Imagem { get; set; }
        public string Sobre { get; set; }

        public AtualizarClinicaComando(Guid id, string razaoSocial, EnderecoDados endereco, byte[]? imagem, string sobre)
        {
            Id = id;
            RazaoSocial = razaoSocial;
            Endereco = endereco;
            Imagem = imagem;
            Sobre = sobre;
        }

        public override bool EhValido()
        {
            ResultadoValidacao = new AtualizarClinicaValidacao().Validate(this);
            return ResultadoValidacao.IsValid;
        }
    }

    public class AtualizarClinicaValidacao : AbstractValidator<AtualizarClinicaComando>
    {
        public AtualizarClinicaValidacao()
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

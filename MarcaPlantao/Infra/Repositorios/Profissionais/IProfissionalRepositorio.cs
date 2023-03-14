using MarcaPlantao.Dominio.Profissionais;
using MarcaPlantao_Infraestrutura.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Infra.Repositorios.Profissionais
{
    public interface IProfissionalRepositorio : IRepositorio<Profissional>
    {
        Task<bool> ValidarProfissional(string crm, string cpf);

        Task<Profissional> ObterProfissionalPorUsuario(string UsuarioId);
    }
}

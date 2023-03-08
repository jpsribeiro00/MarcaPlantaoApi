using MarcaPlantao.Aplicacao.AutoMapper;
using MarcaPlantao.Aplicacao.Servicos.Acesso;

namespace MarcaPlantao_Api.Configuracao
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection servicos)
        {
            if (servicos == null) throw new ArgumentNullException(nameof(servicos));

            servicos.AddAutoMapper(typeof(AutenticacaoServico));

            AutoMapperConfiguracao.RegisterMappings();

        }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Aplicacao.AutoMapper
{
    public class AutoMapperConfiguracao
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainToViewModelMapping());
                cfg.AddProfile(new ViewModelToDomainMapping());
            });
        }
    }
}

using AutoMapper;
using BazarTemTudo.Application.ViewModels;
using BazarTemTudo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.InfraData.Mapping
{
    public class MapperClienteConfig
    {
        public static Mapper InitializeAutomapper()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                 //Configuring Employee and EmployeeDTO
                cfg.CreateMap<Clientes, ClientesViewModel>()
                .ForMember(des => des.Nome, map => map.MapFrom(orig => orig.Nome))
                .ForMember(des => des.Email, map => map.MapFrom(orig => orig.Email))
                .ForMember(des => des.CPF, map => map.MapFrom(orig => orig.CPF))
                .ForMember(des => des.DataNascimento, map => map.MapFrom(orig => orig.DataNascimento))
                .IncludeAllDerived();

                cfg.CreateMap<ClientesViewModel, Clientes>()
                .ForMember(des => des.Nome, map => map.MapFrom(orig => orig.Nome))
                .ForMember(des => des.Email, map => map.MapFrom(orig => orig.Email))
                .ForMember(des => des.CPF, map => map.MapFrom(orig => orig.CPF))
                .ForMember(des => des.DataNascimento, map => map.MapFrom(orig => orig.DataNascimento))
                .IncludeAllDerived();

            });
            //Create an Instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}

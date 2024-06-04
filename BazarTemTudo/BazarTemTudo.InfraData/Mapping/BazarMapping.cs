using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BazarTemTudo.Application.DTO;
using BazarTemTudo.Domain.Entities;

namespace BazarTemTudo.InfraData.Mapping
{
    public class BazarMapping : Profile
    {
        public BazarMapping() 
        {
            CreateMap<Clientes, ClientesViewModel>()
               .ForMember(des => des.Nome, map => map.MapFrom(orig => orig.Nome))
               .ForMember(des => des.Email, map => map.MapFrom(orig => orig.Email))
               .ForMember(des => des.CPF, map => map.MapFrom(orig => orig.CPF))
               .ForMember(des => des.DataNascimento, map => map.MapFrom(orig => orig.DataNascimento))
               .IncludeAllDerived();

            CreateMap<ClientesViewModel, Clientes>()
               .ForMember(des => des.Nome, map => map.MapFrom(orig => orig.Nome))
               .ForMember(des => des.Email, map => map.MapFrom(orig => orig.Email))
               .ForMember(des => des.CPF, map => map.MapFrom(orig => orig.CPF))
               .ForMember(des => des.DataNascimento, map => map.MapFrom(orig => orig.DataNascimento))
               .IncludeAllDerived();


        }
    }
}

using AutoMapper;
using BazarTemTudo.Application.ViewModels;
using BazarTemTudo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.Application.Mapping
{
    public class ClienteMapping : Profile
    {
        public ClienteMapping() { ClienteMap(); }

        private void ClienteMap()
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
            // .ForMember(dest => dest.IsAtivo, opt => opt.Ignore());

        }
    }
}

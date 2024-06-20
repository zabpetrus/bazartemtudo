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
    public class BazarTemTudoMapping : Profile
    {
        public BazarTemTudoMapping()
        {
            CreateMap<Clientes, ClientesViewModel>();
            CreateMap<ClientesViewModel, Clientes>();
        }
    }
}

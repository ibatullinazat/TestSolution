using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CreditAPI.Dtos;
using CreditAPI.Models;


namespace CreditAPI.MappingProfiles
{
    public class ApplicationMappings : Profile
    {
        public ApplicationMappings()
        {
            CreateMap<Application, ApplicationDto>().ReverseMap();
            CreateMap<Application, ApplicationCreateResultDto>().ReverseMap();
            CreateMap<Application, ApplicationStatusDto>().ReverseMap();
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<RequestedCredit, RequestedCreditDto>().ReverseMap();
        }
    }
}

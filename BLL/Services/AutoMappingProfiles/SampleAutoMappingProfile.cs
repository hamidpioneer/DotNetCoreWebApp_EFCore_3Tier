using AutoMapper;
using BLL.Services.Dtos;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.AutoMappingProfiles
{
    public class SampleAutoMappingProfile : Profile
    {
        public SampleAutoMappingProfile()
        {
            // Source -> Target
            CreateMap<Sample, SampleReadDto>();
            CreateMap<SampleReadDto, Sample>();
            
            CreateMap<Applicant, ApplicantCreateDto>();
            CreateMap<ApplicantCreateDto, Applicant>();

            CreateMap<Applicant, ApplicantReadDto>()
                .ForMember(target => target.DateOfBirthString, source => source.MapFrom(z => z.DateOfBirth.ToString("dd/MM/yyyy")));

            CreateMap<ApplicantReadDto, Applicant>();

            CreateMap<ApplicationCreateDto, Application>();


        }
    }
}

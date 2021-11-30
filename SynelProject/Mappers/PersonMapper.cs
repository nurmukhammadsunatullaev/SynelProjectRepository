using AutoMapper;
using BusinessLevel.Models;
using DatabaseLevel.EntityModels;
using SynelProject.Models;

namespace SynelProject.Mappers
{
    public class PersonMapper : Profile
    {
        public PersonMapper()
        {
            CreateMap<PersonDtoModel, PersonEntityModel>();

            CreateMap<PersonEntityModel, PersonDtoModel>();

            CreateMap<PersonDtoModel,PersonViewModel>()
                 .ForMember(x => x.Payroll, y => y.MapFrom(x => x.PayrollNumber))
                 .ForMember(x => x.Start, y => y.MapFrom(x => x.StartDate));

            CreateMap< PersonViewModel, PersonDtoModel>()
                 .ForMember(x => x.PayrollNumber, y => y.MapFrom(x => x.Payroll))
                 .ForMember(x => x.StartDate, y => y.MapFrom(x => x.Start));


            CreateMap<PersonDtoModel, PersonCSVModel>()
                 .ForMember(x => x.Payroll_Number, y => y.MapFrom(x => x.PayrollNumber))
                 .ForMember(x => x.Forenames, y => y.MapFrom(x => x.Name))
                 .ForMember(x => x.Date_of_Birth, y => y.MapFrom(x => x.Birthday))
                 .ForMember(x => x.EMail_Home, y => y.MapFrom(x => x.Email))
                 .ForMember(x => x.Telephone, y => y.MapFrom(x => x.Phone))
                 .ForMember(x => x.Start_Date, y => y.MapFrom(x => x.StartDate));

            CreateMap<PersonCSVModel, PersonDtoModel>()
                 .ForMember(x => x.PayrollNumber, y => y.MapFrom(x => x.Payroll_Number))
                 .ForMember(x => x.Name, y => y.MapFrom(x => x.Forenames))
                 .ForMember(x => x.Birthday, y => y.MapFrom(x => x.Date_of_Birth))
                 .ForMember(x => x.Email, y => y.MapFrom(x => x.EMail_Home))
                 .ForMember(x => x.Phone, y => y.MapFrom(x => x.Telephone))
                 .ForMember(x => x.StartDate, y => y.MapFrom(x => x.Start_Date));
        }
    }
}

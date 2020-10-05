using AutoMapper;
using Scaffolding.Models;
using Scaffolding.ViewModels;

namespace Scaffolding.Application.AutoMapper
{
    public class ViewModelToModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToModelMappings"; }
        }

        public ViewModelToModelMappingProfile()
        {
            #region [Mapper: Every model]
            CreateMap<string, string>().ConvertUsing(str => (str != null ? str.Trim() : str));
            #endregion [Mapper: Every model]
        }
    }
}

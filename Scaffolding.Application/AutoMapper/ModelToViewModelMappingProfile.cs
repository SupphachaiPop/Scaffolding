using AutoMapper;
using Scaffolding.Models;
using Scaffolding.ViewModels;
using Scaffolding.Common;
using System.Globalization;
using System.Linq;

namespace Scaffolding.Application.AutoMapper
{
    public class ModelToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ModelToViewModelMappings"; }
        }

        private readonly string _magentoImageBaseURL;

        public readonly ConfigurationCommon _config;
        public readonly UtilityCommon _util;
        public ModelToViewModelMappingProfile()
        {
            this._config = new ConfigurationCommon();
            this._util = new UtilityCommon();

            #region [Mapper: Every model]
            CreateMap<string, string>().ConvertUsing(str => (str != null ? str.Trim() : str));
            #endregion [Mapper: Every model]


            CreateMap<user, VMRESULT_LOGIN>();
                //.ForMember(vm => vm.TEXT, map => map.MapFrom(domain => domain.rol))
                //.ForMember(vm => vm.role, map => map.MapFrom(domain => this._securityCommon.EncryptDataUrlEncoder(domain.COMPANY_ID, this._appSettings.DATA_ID_ENCRYPTION_KEY)));
        }
    }
}

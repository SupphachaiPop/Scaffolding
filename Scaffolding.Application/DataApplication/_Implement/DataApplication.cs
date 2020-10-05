using Scaffolding.Domain;
using Scaffolding.Models;
using Scaffolding.Common;
using Scaffolding.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Globalization;


namespace Scaffolding.Application
{
    public partial interface IDataApplication
    { }

    // Implement Domain
    public partial class DataApplication : IDataApplication
    {
        #region [Private Vars ReadOnly]
        private readonly string _dateFormat;
        private readonly string _datetimeFormat;
        private readonly CultureInfo _dateCulture;
        #endregion [Private Vars ReadOnly]

        #region [Private Members]
        private readonly INLogCommon _nLog;
        private readonly IUtilityCommon _util;
        private readonly IMapper _mapper;
        private readonly IDataDomain _dataDomain;
        private readonly IConfigurationCommon _config;
        #endregion [Private Members]

        #region [Constructor]
        public DataApplication(
                INLogCommon nLog,
                IUtilityCommon util,
                IMapper mapper,
                IDataDomain dataDomain,
                IConfigurationCommon config
            )
        {
            this._nLog = nLog;
            this._util = util;
            this._mapper = mapper;
            this._dataDomain = dataDomain;
            this._config = config;

            this._dateFormat = this._config.Setting<string>("Scaffolding.ResponseDateFormat");
            this._datetimeFormat = this._config.Setting<string>("Scaffolding.ResponseDatetimeFormat");
            this._dateCulture = CultureInfo.InvariantCulture;
        }
        #endregion [Constructor]
    }
}

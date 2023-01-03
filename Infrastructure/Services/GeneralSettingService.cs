using Application.Services;
using Domain.Enums;

namespace Infrastructure.Services
{
    public class GeneralSettingService : IGeneralSettingService
    {
        private readonly IDatabaseService _databaseService;
        private readonly ILogManagmentService _log;

        public GeneralSettingService(IDatabaseService databaseService, ILogManagmentService log)
        {
            _databaseService = databaseService;
            _log = log;
        }

        public string GetTechnoLifeLaptopBaseUrl()
        {
            return GetValueOfKey(GeneralSettingKeys.TechnoLifeLaptopBaseUrl);
        }

        private string GetValueOfKey(GeneralSettingKeys key)
        {
            var result = string.Empty;
            try
            {
                var generalSetting = _databaseService.GeneralSettings.SingleOrDefault(g => g.Key == key.ToString());
                if (generalSetting != null)
                {
                    result = generalSetting.Value;
                }
            }
            catch (Exception ex)
            {
                _log.Log(ex, this, System.Reflection.MethodBase.GetCurrentMethod());
                throw new Exception($"Can not read {key} from general setting table", ex);
            }

            return result;
        }
    }
}

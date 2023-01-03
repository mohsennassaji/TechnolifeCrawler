using Application.Services;

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

        public string GetCamundaServerUrl()
        {
            throw new NotImplementedException();
        }
    }
}

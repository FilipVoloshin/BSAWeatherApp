using BSAWeatherApp.Models.DTO;
using System.Collections.Generic;

namespace BSAWeatherApp.Services
{
    public interface IHistoryService
    {
        void AddHistory(CityHistoryDTO history);
        void ClearHistory();
        IEnumerable<CityHistoryDTO> GetAllHistoryEntries();
        void Dispose();
    }
}

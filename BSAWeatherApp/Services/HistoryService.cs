using System.Collections.Generic;
using BSAWeatherApp.Models.DTO;
using BSAWeatherApp.DataService;
using AutoMapper;
using BSAWeatherApp.Models;

namespace BSAWeatherApp.Services
{
    public class HistoryService : IHistoryService
    {
        IUnitOfWork DataBase { get; set; }
        public HistoryService(IUnitOfWork uow)
        {
            DataBase = uow;
        }
        public void AddHistory(CityHistoryDTO history)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CityHistoryDTO, CityHistory>());
            DataBase.Repository<CityHistory>().Create(Mapper.Map<CityHistoryDTO, CityHistory>(history));
            DataBase.Save();
        }

        public IEnumerable<CityHistoryDTO> GetAllHistoryEntries()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CityHistory, CityHistoryDTO>());
            return Mapper.Map<IEnumerable<CityHistory>, List<CityHistoryDTO>>(DataBase.Repository<CityHistory>().GetAll());
        }

        public void ClearHistory()
        {
            var historyDto = GetAllHistoryEntries();
            Mapper.Initialize(cfg => cfg.CreateMap<CityHistoryDTO, CityHistory>());
            var history = Mapper.Map<IEnumerable<CityHistoryDTO>, IEnumerable<CityHistory>>(historyDto);
            foreach(var entry in history)
            {
                DataBase.Repository<CityHistory>().Delete(entry.Id);
            }
            DataBase.Save();
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }
    }
}
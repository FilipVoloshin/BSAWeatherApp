using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace BSAWeather.UWP.Services
{

    public interface IClientService<T> where T : class
    {
        Task<ObservableCollection<T>> GetCollectionAsync(string apiPath);
        //Task<T> GetItemAsync(string apiPath,T settings);
        Task PostItemAsync(string apiPath, T postValue);
        Task PutItemAsync(string apiPath, T putValue);
        Task DeleteItemByIdAsync(string apiPath, int id);
    }
}

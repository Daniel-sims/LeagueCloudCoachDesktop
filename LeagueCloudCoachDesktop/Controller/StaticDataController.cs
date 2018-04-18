using LeagueCloudCoachDesktop.Controller.Interfaces;
using LeagueCloudCoachDesktop.HttpRequest;
using LeagueCloudCoachDesktop.Dto.StaticData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeagueCloudCoachDesktop.Controller
{
    public class StaticDataController : IStaticDataController
    {
        private const string GetChampionListStaticEndpoint = "/StaticData/Champions";
        private const string GetItemsListStaticEndpoint = "/StaticData/Items";
        private const string GetSummonerSpellsListStaticEndpoint = "/StaticData/SummonerSpells";
        private const string GetRunesListStaticEndpoint = "/StaticData/Runes";

        private readonly IHttpRequestWrapper _httpRequestWrapper;

        public StaticDataController()
        {
            _httpRequestWrapper = new HttpRequestWrapper(new TokenBasedRequestWrapper());
        }

        public async Task<IEnumerable<ChampionDto>> GetChampionData()
        {
            return await _httpRequestWrapper.SendRequestAsync<List<ChampionDto>>(GetChampionListStaticEndpoint);
        }

        public async Task<IEnumerable<ItemDto>> GetItemData()
        {
            return await _httpRequestWrapper.SendRequestAsync<List<ItemDto>>(GetItemsListStaticEndpoint);
        }

        public async Task<IEnumerable<SummonerSpellDto>> GetSummonerSpellData()
        {
            return await _httpRequestWrapper.SendRequestAsync<List<SummonerSpellDto>>(GetSummonerSpellsListStaticEndpoint);
        }

        public async Task<IEnumerable<RuneDto>> GetRuneData()
        {
            return await _httpRequestWrapper.SendRequestAsync<List<RuneDto>>(GetRunesListStaticEndpoint);
        }
    }
}

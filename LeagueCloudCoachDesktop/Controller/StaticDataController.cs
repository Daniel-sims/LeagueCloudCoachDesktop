using LeagueCloudCoachDesktop.Controller.Interfaces;
using LeagueCloudCoachDesktop.HttpRequest;
using LeagueCloudCoachDesktop.Models.StaticData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeagueCloudCoachDesktop.Controller
{
    public class StaticDataController : IStaticDataController
    {
        private const string GetChampionListStaticEndpoint = "/StaticData/Champions";
        private const string GetItemsListStaticEndpoint = "/StaticData/Items";
        private const string GetSummonerSpellsListStaticEndpoint = "/StaticData/SummonerSpells";
        private const string GetRunesListStaticEndpoint = "/StaticData/SummonerSpells";

        private readonly IHttpRequestWrapper _httpRequestWrapper;

        public StaticDataController()
        {
            _httpRequestWrapper = new HttpRequestWrapper(new TokenBasedRequestWrapper());
        }

        public async Task<IEnumerable<Champion>> GetChampionData()
        {
            return await _httpRequestWrapper.SendRequestAsync<List<Champion>>(GetChampionListStaticEndpoint);
        }

        public async Task<IEnumerable<Item>> GetItemData()
        {
            return await _httpRequestWrapper.SendRequestAsync<List<Item>>(GetItemsListStaticEndpoint);
        }

        public async Task<IEnumerable<SummonerSpell>> GetSummonerSpellData()
        {
            return await _httpRequestWrapper.SendRequestAsync<List<SummonerSpell>>(GetSummonerSpellsListStaticEndpoint);
        }

        public async Task<IEnumerable<Rune>> GetRuneData()
        {
            return await _httpRequestWrapper.SendRequestAsync<List<Rune>>(GetRunesListStaticEndpoint);
        }
    }
}

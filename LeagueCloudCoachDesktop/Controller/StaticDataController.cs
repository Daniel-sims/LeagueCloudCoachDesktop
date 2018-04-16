using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LeagueCloudCoachDesktop.Controller.Interfaces;
using LeagueCloudCoachDesktop.HttpRequest;
using LeagueCloudCoachDesktop.Models.StaticData;

namespace LeagueCloudCoachDesktop.Controller
{
    public class StaticDataController : IStaticDataController
    {
        private const string GET_CHAMPION_LIST_STATIC_ENDPOINT = "/StaticData/Champions";
        private const string GET_ITEMS_LIST_STATIC_ENDPOINT = "/StaticData/Items";
        private const string GET_SUMMONER_SPELLS_LIST_STATIC_ENDPOINT = "/StaticData/SummonerSpells";

        private IHttpRequestWrapper _httpRequestWrapper;

        public StaticDataController()
        {
            _httpRequestWrapper = new HttpRequestWrapper(new TokenBasedRequestWrapper());
        }

        public async Task<List<Champion>> GetChampionData()
        {
            var getChampionDataInformationUrl = new StringBuilder();
            getChampionDataInformationUrl.AppendFormat(GET_CHAMPION_LIST_STATIC_ENDPOINT);
            
            return await _httpRequestWrapper.SendRequestAsync<List<Champion>>(getChampionDataInformationUrl.ToString());
        }

        //public async Task<List<Item>> GetItemData()
        //{
        //    StringBuilder getItemDataInformationUrl = new StringBuilder();
        //    getItemDataInformationUrl.AppendFormat(GET_ITEMS_LIST_STATIC_ENDPOINT);

        //    return await _httpRequestWrapper.SendRequestAsync<List<Item>>(getItemDataInformationUrl.ToString());
        //}

        //public async Task<List<SummonerSpell>> GetSummonerSpellData()
        //{
        //    StringBuilder getSummonerSpellDataInformation = new StringBuilder();
        //    getSummonerSpellDataInformation.AppendFormat(GET_SUMMONER_SPELLS_LIST_STATIC_ENDPOINT);

        //    return await _httpRequestWrapper.SendRequestAsync<List<SummonerSpell>>(getSummonerSpellDataInformation.ToString());
        //}

        //public async Task<List<Rune>> GetSummonerSpellData()
        //{
        //    StringBuilder getSummonerSpellDataInformation = new StringBuilder();
        //    getSummonerSpellDataInformation.AppendFormat(GET_SUMMONER_SPELLS_LIST_STATIC_ENDPOINT);

        //    return await _httpRequestWrapper.SendRequestAsync<List<Rune>>(getSummonerSpellDataInformation.ToString());
        //}
    }
}

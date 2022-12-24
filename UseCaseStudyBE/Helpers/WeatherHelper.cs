using System.Net;
using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;
using UseCaseStudyBE.Enums;
using UseCaseStudyBE.Models.Dto;

namespace UseCaseStudyBE.Helpers;

public class WeatherHelper
{
    private IMemoryCache _memoryCache;

    public WeatherHelper(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public List<WeatherDTO>? GetWeatherDatas()
    {
        var mDatas = _memoryCache.Get<List<WeatherDTO>>(MemoryCacheKey.WeatherDatas.ToString());
        if (mDatas == null || mDatas.Count == 0)
        {
            return FetchWeatherDatas();
        }
        else
        {
            return mDatas;
        }
    }

    private List<WeatherDTO>? FetchWeatherDatas()
    {
        try
        {
            WebRequest tRequest =
                WebRequest.Create("https://api.collectapi.com/weather/getWeather?data.lang=tr&data.city=istanbul");

            tRequest.Method = "get";
            tRequest.ContentType = "application/json";
            tRequest.Headers.Add("authorization", "apikey 2SBnzMZ4wuYlQxRe5xKOJM:45FmQjOk3xTwRkpaoiPMP9");

            using WebResponse tResponse = tRequest.GetResponse();

            using Stream dataStreamResponse = tResponse.GetResponseStream();
            using StreamReader tReader = new StreamReader(dataStreamResponse);
            String sResponseFromServer = tReader.ReadToEnd();
            var datas = JsonSerializer.Deserialize<WeatherApiResult>(sResponseFromServer);

            _memoryCache.Set(MemoryCacheKey.WeatherDatas.ToString(), datas.result,TimeSpan.FromHours(1));
            return datas.result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
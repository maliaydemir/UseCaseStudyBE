using MediatR;
using UseCaseStudyBE.Helpers;
using UseCaseStudyBE.Models.Dto;
using UseCaseStudyBE.CQRS.Queries.WeatherQueries;

namespace UseCaseStudyBE.CQRS.Handlers.WeatherHandlers;

public class GetTodayWeatherHandler: IRequestHandler<GetTodayWeatherQuery,WeatherDTO>
{
    private readonly WeatherHelper _weatherHelper;
    public GetTodayWeatherHandler(NEDbContext neDbContext, WeatherHelper weatherHelper)
    {
        _weatherHelper = weatherHelper;
    }
    public Task<WeatherDTO?> Handle(GetTodayWeatherQuery request, CancellationToken cancellationToken)
    {
        var datas = _weatherHelper.GetWeatherDatas();
        if (datas == null)
        {
            return Task.FromResult(new WeatherDTO());
        }
        var todayData = datas.FirstOrDefault(e => e.ParsedDate == DateTime.Now.Date);
        return Task.FromResult(todayData);
    }
}
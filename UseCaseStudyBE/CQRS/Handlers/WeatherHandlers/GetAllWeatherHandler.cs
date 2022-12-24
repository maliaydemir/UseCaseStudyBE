using MediatR;
using UseCaseStudyBE.Helpers;
using UseCaseStudyBE.Models.Dto;
using UseCaseStudyBE.CQRS.Queries.WeatherQueries;

namespace UseCaseStudyBE.CQRS.Handlers.WeatherHandlers;

public class GetAllWeatherHandler : IRequestHandler<GetAllWeatherQuery, List<WeatherDTO>>
{
    private readonly WeatherHelper _weatherHelper;

    public GetAllWeatherHandler(NEDbContext neDbContext, WeatherHelper weatherHelper)
    {
        _weatherHelper = weatherHelper;
    }

    public Task<List<WeatherDTO>> Handle(GetAllWeatherQuery request, CancellationToken cancellationToken)
    {
        var datas = _weatherHelper.GetWeatherDatas();
        return Task.FromResult(datas);
    }
}
using MediatR;
using UseCaseStudyBE.Models.Dto;

namespace UseCaseStudyBE.CQRS.Queries.WeatherQueries;

public record GetAllWeatherQuery():IRequest<List<WeatherDTO>>;
using MediatR;
using UseCaseStudyBE.Models;

namespace UseCaseStudyBE.CQRS.Queries.ActivityQueries;

public record GetActivityByIdQuery(string id) : IRequest<Activity>;
using MediatR;
using UseCaseStudyBE.Models;

namespace UseCaseStudyBE.CQRS.Queries.ActivityQueries;

public record GetActivityListQuery() : IRequest<List<Activity>>;
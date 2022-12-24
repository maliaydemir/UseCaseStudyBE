using MediatR;
using UseCaseStudyBE.Models;
using UseCaseStudyBE.CQRS.Queries.ActivityQueries;

namespace UseCaseStudyBE.CQRS.Handlers.ActivityHandlers;

public class GetActivityListHandler: IRequestHandler<GetActivityListQuery,List<Activity>>
{
    private readonly NEDbContext _neDbContext;
    public GetActivityListHandler(NEDbContext neDbContext)
    {
        _neDbContext = neDbContext;
    }
    public Task<List<Activity>> Handle(GetActivityListQuery request, CancellationToken cancellationToken)
    {
        var a = _neDbContext.Activities.ToList();
        return Task.FromResult(_neDbContext.Activities.ToList());
    }
}
using MediatR;
using UseCaseStudyBE.Models;
using UseCaseStudyBE.CQRS.Queries.ActivityQueries;

namespace UseCaseStudyBE.CQRS.Handlers.ActivityHandlers;


public class GetActivityByIdHandler: IRequestHandler<GetActivityByIdQuery,Activity>
{
    private readonly NEDbContext _neDbContext;
    public GetActivityByIdHandler(NEDbContext neDbContext)
    {
        _neDbContext = neDbContext;
    }
    public Task<Activity> Handle(GetActivityByIdQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_neDbContext.Activities.FirstOrDefault(e=>e.Id.ToString()==request.id));
    }
}
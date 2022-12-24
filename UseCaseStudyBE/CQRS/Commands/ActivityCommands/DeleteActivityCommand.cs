using MediatR;
using UseCaseStudyBE.Models;

namespace UseCaseStudyBE.CQRS.Commands.ActivityCommands;

public record DeleteActivityCommand(string id):IRequest<Activity>;
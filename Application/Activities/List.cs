using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>> {}

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken token)
            {
                return await _context.Activities.ToListAsync();
            }

            // public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            // {
            ////     it's not common to have a long request like this one
            //     try
            //     {
            //         for (var i = 0; i < 10; i++)
            //         {
            //             cancellationToken.ThrowIfCancellationRequested();
            //             await Task.Delay(1000, cancellationToken);
            //             _logger.LogInformation($"Task {i} has completed");
            //         }
            //     }
            //     catch (System.Exception)
            //     {
            //         _logger.LogInformation("Task was cancelled");
            //     }

            //     return await _context.Activities.ToListAsync();
            // }
        }
    }
}
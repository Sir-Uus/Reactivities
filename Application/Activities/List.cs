using Application.Core;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<Result<List<ActivityDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<ActivityDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            private readonly IUserAcessor _userAcessor;

            public Handler(DataContext context, IMapper mapper, IUserAcessor userAcessor)
            {
                _mapper = mapper;
                _userAcessor = userAcessor;
                _context = context;
            }

            public async Task<Result<List<ActivityDto>>> Handle(
                Query request,
                CancellationToken cancellationToken
            )
            {
                var activities = await _context
                    .Activities.ProjectTo<ActivityDto>(
                        _mapper.ConfigurationProvider,
                        new { currentUsername = _userAcessor.GetUsername() }
                    )
                    .ToListAsync(cancellationToken);

                return Result<List<ActivityDto>>.Success(activities);
            }
        }
    }
}

using AutoMapper;
using Inventory.Application.Features.User.Commands.CreateUserCommand;
using Inventory.Application.Features.User.Commands.DeleteUserCommand;
using Inventory.Application.Features.User.Commands.UpdateUserCommand;
using Inventory.Application.Features.User.Queries.GetActiveUsersQuery;
using Inventory.Application.Features.User.Queries.GetUsersQuery;
using Inventory.Domain.DomainObjects;

namespace Business.Configurations.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            //Request Mapper(s)
            CreateMap<CreateUserCommand, UserDO>();
            CreateMap<UpdateUserCommand, UserDO>();
            CreateMap<DeleteUserCommand, UserDO>();

            //Response Mapper(s)
            CreateMap<UserDO, GetActiveUsersQueryResult>();
            CreateMap<UserDO, GetUsersQueryResult>();
        }
    }
}

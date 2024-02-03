using GloboTickets.Application.Dtos.Events;
using GloboTickets.Domain.Entities;
using Mapster;

namespace GloboTickets.Application.Profiles;

public class MappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        
        // config.NewConfig<EventDto, Event>();

        // config.NewConfig<Event, EventDto>();
        // config.NewConfig<Event, EventDetailDto>();
        // config.NewConfig<Category, CategoryDto>();
        //
        // config.NewConfig<Category, GloboTickets.Application.Features.Categories.Queries.GetCategoryList.CategoryDto>();
        
    }
}
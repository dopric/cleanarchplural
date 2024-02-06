namespace GloboTickets.Application.Responses.Category;

public class CreateCategoryCommandResponse : BaseResponse
{
    public CreateCategoryCommandResponse() : base()
    {
        
    }

    public CreateCategoryDto Category { get; set; } = default!;
}

// just for test

public class CreateCategoryDto
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
}
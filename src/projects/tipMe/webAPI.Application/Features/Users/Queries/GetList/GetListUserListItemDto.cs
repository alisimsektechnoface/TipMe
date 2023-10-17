using Application.Features.Stores.Queries.GetById;
using Core.Application.Dtos;
using static Core.Domain.ComplexTypes.Enums;

namespace Application.Features.Users.Queries.GetList;

public class GetListUserListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid StoreId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public RecordStatu Status { get; set; }
    public GetByIdStoreResponse Store { get; set; }

    public GetListUserListItemDto()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
    }

    public GetListUserListItemDto(Guid id, string firstName, string lastName, string email, RecordStatu status, Guid storeId, GetByIdStoreResponse store)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Status = status;
        StoreId = storeId;
        Store = store;
    }
}

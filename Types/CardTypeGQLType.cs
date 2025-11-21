using Arkham.API.Entities;

namespace Arkham.API.Types;

public class CardTypeGQLType : ObjectType<CardType>
{
    protected override void Configure(IObjectTypeDescriptor<CardType> descriptor)
    {
        descriptor.Field(t => t.Id).Type<IdType>();
        descriptor.Field(t => t.Code).Type<StringType>();
        descriptor.Field(t => t.Name).Type<StringType>();
    }
}

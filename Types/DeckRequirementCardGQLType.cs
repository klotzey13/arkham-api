
using Arkham.API.Entities;

namespace Arkham.API.Types;

public class DeckRequirementCardGQLType : ObjectType<DeckRequirementCard>
{
    protected override void Configure(IObjectTypeDescriptor<DeckRequirementCard> descriptor)
    {
        descriptor.Field(t => t.Id).Type<IdType>();
        descriptor.Field(t => t.CardCode).Type<StringType>();
    }
}

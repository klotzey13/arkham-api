
using Arkham.API.Entities;

namespace Arkham.API.Types;

public class DeckRequirementCardChoiceGQLType : ObjectType<DeckRequirementCardChoice>
{
    protected override void Configure(IObjectTypeDescriptor<DeckRequirementCardChoice> descriptor)
    {
        descriptor.Field(t => t.Id).Type<IdType>();
        descriptor.Field(t => t.Cards).Type<ListType<DeckRequirementCardGQLType>>();
    }
}

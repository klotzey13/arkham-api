
using Arkham.API.Entities;

namespace Arkham.API.Types;

public class DeckRequirementGQLType : ObjectType<DeckRequirement>
{
    protected override void Configure(IObjectTypeDescriptor<DeckRequirement> descriptor)
    {
        descriptor.Field(t => t.Id).Type<IdType>();
        descriptor.Field(t => t.CardChoices).Type<ListType<DeckRequirementCardChoiceGQLType>>();
        descriptor.Field(t => t.Randoms).Type<ListType<DeckRequirementRandomGQLType>>();
    }
}


using Arkham.API.Entities;

namespace Arkham.API.Types;

public class DeckRequirementRandomGQLType : ObjectType<DeckRequirementRandom>
{
    protected override void Configure(IObjectTypeDescriptor<DeckRequirementRandom> descriptor)
    {
        descriptor.Field(t => t.Id).Type<IdType>();
        descriptor.Field(t => t.Target).Type<StringType>();
        descriptor.Field(t => t.Value).Type<StringType>();
    }
}

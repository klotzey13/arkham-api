
using Arkham.API.Entities;

namespace Arkham.API.Types;

public class DeckOptionGQLType : ObjectType<DeckOption>
{
    protected override void Configure(IObjectTypeDescriptor<DeckOption> descriptor)
    {
        descriptor.Field(t => t.Id).Type<IdType>();
        descriptor.Field(t => t.LevelMin).Type<IntType>();
        descriptor.Field(t => t.LevelMax).Type<IntType>();
        descriptor.Field(t => t.Limit).Type<IntType>();
        descriptor.Field(t => t.Not).Type<BooleanType>();
        descriptor.Field(t => t.Factions).Type<ListType<FactionGQLType>>();
        descriptor.Field(t => t.Traits).Type<ListType<TraitGQLType>>();
    }
}

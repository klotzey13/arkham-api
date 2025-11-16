
using Arkham.API.Entities;

namespace Arkham.API.Types;

public class TraitGQLType : ObjectType<Trait>
{
    protected override void Configure(IObjectTypeDescriptor<Trait> descriptor)
    {
        descriptor.Field(t => t.Id).Type<IdType>();
        descriptor.Field(t => t.Name).Type<StringType>();
    }
}

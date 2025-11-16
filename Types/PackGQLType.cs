
using Arkham.API.Entities;

namespace Arkham.API.Types;

public class PackGQLType : ObjectType<Pack>
{
    protected override void Configure(IObjectTypeDescriptor<Pack> descriptor)
    {
        descriptor.Field(t => t.Id).Type<IdType>();
        descriptor.Field(t => t.Code).Type<StringType>();
        descriptor.Field(t => t.Name).Type<StringType>();
    }
}


using Arkham.API.Entities;

namespace Arkham.API.Types;

public class SubTypeGQLType : ObjectType<SubType>
{
    protected override void Configure(IObjectTypeDescriptor<SubType> descriptor)
    {
        descriptor.Field(t => t.Id).Type<IdType>();
        descriptor.Field(t => t.Code).Type<StringType>();
        descriptor.Field(t => t.Name).Type<StringType>();
    }
}

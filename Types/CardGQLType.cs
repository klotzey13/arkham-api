using Arkham.API.Entities;

namespace Arkham.API.Types;

public class CardGQLType : ObjectType<Card>
{
    protected override void Configure(IObjectTypeDescriptor<Card> descriptor)
    {
        descriptor.Field(t => t.Id).Type<IdType>();
        descriptor.Field(t => t.Code).Type<StringType>();
        descriptor.Field(t => t.Name).Type<StringType>();
        descriptor.Field(t => t.RealName).Type<StringType>();
        descriptor.Field(t => t.SubName).Type<StringType>();
        descriptor.Field(t => t.Text).Type<StringType>();
        descriptor.Field(t => t.RealText).Type<StringType>();
        descriptor.Field(t => t.Quantity).Type<IntType>();
        descriptor.Field(t => t.SkillWillpower).Type<IntType>();
        descriptor.Field(t => t.SkillIntellect).Type<IntType>();
        descriptor.Field(t => t.SkillCombat).Type<IntType>();
        descriptor.Field(t => t.SkillAgility).Type<IntType>();
        descriptor.Field(t => t.SkillWild).Type<IntType>();
        descriptor.Field(t => t.Health).Type<IntType>();
        descriptor.Field(t => t.HealthPerInvestigator).Type<BooleanType>();
        descriptor.Field(t => t.Sanity).Type<IntType>();
        descriptor.Field(t => t.DeckLimit).Type<IntType>();
        descriptor.Field(t => t.Slot).Type<StringType>();
        descriptor.Field(t => t.RealSlot).Type<StringType>();
        descriptor.Field(t => t.Traits).Type<ListType<TraitGQLType>>();
        descriptor.Field(t => t.DeckOptions).Type<ListType<DeckOptionGQLType>>();
        descriptor.Field(t => t.DeckRequirement).Type<DeckRequirementGQLType>();
        descriptor.Field(t => t.Flavor).Type<StringType>();
        descriptor.Field(t => t.Illustrator).Type<StringType>();
        descriptor.Field(t => t.IsUnique).Type<BooleanType>();
        descriptor.Field(t => t.Permanent).Type<BooleanType>();
        descriptor.Field(t => t.DoubleSided).Type<BooleanType>();
        descriptor.Field(t => t.BackText).Type<StringType>();
        descriptor.Field(t => t.BackFlavor).Type<StringType>();
        descriptor.Field(t => t.OctgnId).Type<StringType>();
        descriptor.Field(t => t.Url).Type<StringType>();
        descriptor.Field(t => t.ImageSrc).Type<StringType>();
        descriptor.Field(t => t.BackImageSrc).Type<StringType>();
        descriptor.Field(t => t.Cost).Type<IntType>();
        descriptor.Field(t => t.Xp).Type<IntType>();
        descriptor.Field(t => t.Position).Type<IntType>();
        descriptor.Field(t => t.Exceptional).Type<BooleanType>();
        descriptor.Field(t => t.Myriad).Type<BooleanType>();
        descriptor.Field(t => t.DeckSize).Type<IntType>();

        descriptor.Field(t => t.Pack).Type<PackGQLType>();
        descriptor.Field(t => t.Type).Type<CardTypeGQLType>();
        descriptor.Field(t => t.Faction).Type<FactionGQLType>();
        descriptor.Field(t => t.Faction2).Type<FactionGQLType>();
        descriptor.Field(t => t.SubType).Type<SubTypeGQLType>();
    }
}

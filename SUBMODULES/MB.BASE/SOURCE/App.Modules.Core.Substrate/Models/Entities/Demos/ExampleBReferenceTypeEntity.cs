using App.Base.Shared.Attributes;
using App.Base.Shared.Models.Entities.Base;

namespace App.Base.Shared.Models.Entities.Demos
{
    /// <summary>
    /// A demonstration of a Reference Type Entity
    /// used to describe an instance of
    /// <see cref="ExampleBEntity"/>
    /// </summary>
    [ForDemoOnly]
    public class ExampleBReferenceTypeEntity : 
        UntenantedAuditedRecordStatedTimestampedGuidIdReferenceDataEntityBase
    {

    }
}

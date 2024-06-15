using App.Base.Shared.Attributes;
using App.Base.Shared.Models.Entities.Demos;

namespace App.Base.Shared.Factories.Demo
{


    /// <summary>
    /// Static Factory to develop simple
    /// <see cref="ExampleBEntity"/> entities
    /// that have scalar properties, and
    /// child single referenced/category records and
    /// collections of records
    /// </summary>
    [ForDemoOnly]
    internal static class ExampleBEntityFactory
    {

        /// <summary>
        /// Static method to build a
        /// <see cref="ExampleBEntity"/>
        /// and return it.
        /// </summary>
        /// <param name="index"></param>
        public static ExampleBEntity Build(int index)
        {
            ExampleBReferenceTypeEntity categoryRecord = ExampleCEntityFactory.Build(index);


            var result = new ExampleBEntity() {
                //Timestamp
                RecordState = Models.Entities.RecordPersistenceState.Active,
                Id = index.ToGuid(),
                CreatedByPrincipalId = "{P-whatever}",
                CreatedOnUtc=DateTime.UtcNow,
                LastModifiedByPrincipalId="{P-whatever}",
                LastModifiedOnUtc=DateTime.UtcNow, 
                //DeletedByPrincipalId  
                //DeletedOnUtc
                 Title="Some Title...",
                 Description="Some Description...",
                //----- 
                SingleProperty= categoryRecord,
                 SinglePropertyFK=categoryRecord.Id,
                //----- 
            };

            return result;

        }
    }
}

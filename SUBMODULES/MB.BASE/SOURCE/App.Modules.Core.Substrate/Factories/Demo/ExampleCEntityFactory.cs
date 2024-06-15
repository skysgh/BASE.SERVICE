﻿using App.Base.Shared.Attributes;
using App.Base.Shared.Models.Entities.Demos;

namespace App.Base.Shared.Factories.Demo
{
    /// <summary>
    /// Static Factory to develop simple
    /// <see cref="ExampleBReferenceTypeEntity"/> entities
    /// that have just scalar properties, and no
    /// child records or collections of records
    /// </summary>
    [ForDemoOnly]
    internal static class ExampleCEntityFactory
    {
        
        /// <summary>
        /// Static method to build a
        /// <see cref="ExampleBReferenceTypeEntity"/>
        /// and return it.
        /// </summary>
        /// <param name="index"></param>
        public static ExampleBReferenceTypeEntity Build(int index)
        {
            ExampleBReferenceTypeEntity categoryRecord = new()
            {
                //Timestamp
                RecordState = Models.Entities.RecordPersistenceState.Active,
                Id = (100 + index).ToGuid(),
                CreatedByPrincipalId = "{P-whatever}",
                CreatedOnUtc = DateTime.UtcNow,
                LastModifiedByPrincipalId = "{P-whatever}",
                LastModifiedOnUtc = DateTime.UtcNow,
                //DeletedByPrincipalId  
                //DeletedOnUtc
                Enabled = true,
                Title = "Some Category Title...",
                Description = "Some Category Decription...",
                ImageUrl = "{some url}",
                DisplayOrderHint = 0,
                DisplayStyleHint = ""
            };
            return categoryRecord;
        }
    }
}

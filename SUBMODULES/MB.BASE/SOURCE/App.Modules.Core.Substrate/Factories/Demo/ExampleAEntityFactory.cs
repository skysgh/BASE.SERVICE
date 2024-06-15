using App.Base.Shared.Attributes;
using App.Base.Shared.Models.Entities.Demos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Base.Domain.Services.Implementations
{
    /// <summary>
    /// Static Factory to develop simple
    /// <see cref="ExampleAEntity"/> entities
    /// that have just scalar properties, and no
    /// child records or collections of records
    /// </summary>
    [ForDemoOnly]
    internal static partial class ExampleAEntityFactory
    {

        /// <summary>
        /// Static method to build a
        /// <see cref="ExampleAEntity"/>
        /// and return it.
        /// </summary>
        /// <param name="index"></param>
        public static ExampleAEntity Build(int index)
        {
            var result = new ExampleAEntity()
            {
                RecordState = Shared.Models.Entities.RecordPersistenceState.Active,
                Id = index.ToGuid(),
                Title = "Some Displayable Text",
                Description = "Some Description of the item...blah, blah...",
            };
            return result;
        }
    }
}

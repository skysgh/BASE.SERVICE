using App.Base.Shared.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Base.Shared.Models.Entities.Demos
{
    /// <summary>
    /// Example of an Item in a list that belongs
    /// to a parent object
    /// </summary>
    [ForDemoOnly]
    public class ExampleBCollectionItemElement
        : UntenantedAuditedRecordStatedTimestampedGuidIdEntityBase,
        IHasTitleAndDescription,
        IHasGenericValue<int>,
        IHasOwnerFK

    {
        /// <summary>
        /// Gets the FK of the owner of this 
        /// collection item.
        /// </summary>
        public Guid OwnerFK { get; set; }   

        /// <inheritdoc/>
        public string Title { get; set; }
        /// <inheritdoc/>
        public string Description { get; set; }
        /// <inheritdoc/>
        public int Value { get; set; }

        /// <inheritdoc/>
        public Guid GetOwnerFk()
        {
            return OwnerFK;
        }
    }
}

namespace App.Modules.Core.Shared.Attributes
{
    using App.Base.Shared.Models.Entities;

    /// <summary>
    /// Attribute to attach to Models to *Hint* (it depends on additional factors too, but it's a start) 
    /// as to the risks associated to exposure.
    /// </summary>
    /// <remarks>
    /// Construtor
    /// </remarks>
    /// <param name="dataClassification"></param>
    public class DataClassificationAttribute(NZDataClassification dataClassification)
    {

        /// <summary>
        /// Get/Set the DataClassification of the type.
        /// </summary>
        public NZDataClassification DataClassification { get; set; } = dataClassification;
    }
}

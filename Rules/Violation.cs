using System;

namespace VisualAzureStudio.Rules
{
    public class Violation
    {
        /// <summary>
        /// Gets or sets the ID of the item the violation belongs to.
        /// </summary>
        public Guid ItemId { get; set; }

        /// <summary>
        /// Gets or sets the description of the violation.
        /// </summary>
        public string Description { get; set; }
    }
}

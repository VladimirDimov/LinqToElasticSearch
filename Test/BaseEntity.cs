using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public abstract class BaseEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [Keyword(Ignore = true)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the created UTC datetime for this metric.
        /// </summary>
        /// <value>
        /// The created UTC.
        /// </value>
        [Keyword(Name = "LastUpdatedUtc")]
        public DateTimeOffset? LastUpdatedUtc { get; set; }

        /// <summary>
        /// Gets or sets the created UTC.
        /// </summary>
        /// <value>
        /// The created UTC.
        /// </value>
        [Keyword(Name = "CreatedUtc")]
        public DateTimeOffset? CreatedUtc { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToolDepot.Core.Domain
{
    [Table("UnderConstruction")]
    public class UnderConstructionModel : BaseEntity
    {

        public UnderConstructionModel()
        {
            CreatedDate = DateTime.UtcNow;
        }
        public string EmailAddress { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endregion

namespace WestWindSystem.Entities
{
    [Table("Territories")]
    public class Territory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "TerritoryID is required and limited to 20 characters.")]
        public int TerritoryID { get; set; }

        [Required(ErrorMessage = "Territory Description is required.")]
        [StringLength(50, ErrorMessage = "Territory Description is limited to 50 characters.")]
        public string TerritoryDescription { get; set; }

        public int RegionID { get; set; }
    }
}

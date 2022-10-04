using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models
{
    /// <summary>
    /// Information of Category
    /// CreatedBy: ThiepTT(18/08/2022)
    /// </summary>
    public class Category
    {
        [Key]
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        [Required]
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order must be between 1 and 100 only.")]
        /// <summary>
        /// DisplayOrder
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// CreatedDateTime
        /// </summary>
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
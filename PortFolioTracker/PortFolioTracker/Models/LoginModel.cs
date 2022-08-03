using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortFolioTracker.Models
{
    [Table("Login")]
    public class Login
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string? FIRSTNAME { get; set; }
        public string? MIDDLENAME { get; set; }
        [Required]
        public string? LASTNAME { get; set; }
        [Required]
        public string? USERNAME { get; set; }
        [Required]
        public string? USEREMAIL { get; set; }
        [Required]
        public string? PASSWORD { get; set; }
        public DateTime? LOGIN_TIMESTAMP { get; set; }
        public DateTime LASTPASSWORDCHANGE { get; set; } = DateTime.Now;
        public int COUNTER { get; set; } = 0;
        [Required]
        public bool? STATUS { get; set; }
    }
}

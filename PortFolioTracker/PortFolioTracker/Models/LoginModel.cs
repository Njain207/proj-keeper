using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortFolioTracker.Models
{
    public class Login
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string? FIRSTNAME { get; set; }
        public string? MIDDLENAME { get; set; }
        public string? LASTNAME { get; set; }
        public string? USERNAME { get; set; }
        public string? PASSWORD { get; set; }
        public bool? STATUS { get; set; }
    }
}

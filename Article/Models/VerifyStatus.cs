
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AspireOverflow.Models
{

    public partial class VerifyStatus
    {
        public VerifyStatus()
        {
            Users = new HashSet<User>();
        }


        [Key]
        public int VerifyStatusID { get; set; }
        public string Name { get; set; }

        [InverseProperty("VerifyStatus")]
        public virtual ICollection<User> Users { get; set; }

        [InverseProperty("VerifyStatus")]
        public virtual ICollection<Article> Articles { get; set; }
    }
}

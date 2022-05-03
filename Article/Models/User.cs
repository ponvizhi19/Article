
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspireOverflow.Models.Interfaces;


namespace AspireOverflow.Models
{
   
    public partial class User 
    {
        public User()
        {

            Queries = new HashSet<Query>();
            QueryComments = new HashSet<QueryComment>();

        }


        [Key]
        public int UserId { get; set; }

        [StringLength(50)]
        public string FullName { get; set; } = null!;


        public int GenderId { get; set; }

        [StringLength(30)]
        public string AceNumber { get; set; } = null!;

        public string EmailAddress { get; set; } = null!;

        [StringLength(50)]
        public string Password { get; set; } = null!;


        public DateTime DateOfBirth { get; set; }

        public int VerifyStatusID { get; set; }=3;

        public bool IsReviewer{ get; set; }

        public int UserRoleId { get; set; }=2;


        public int DesignationId { get; set; }

        public DateTime CreatedOn { get; set; }=DateTime.Now;
     

        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }

        
        [ForeignKey("DesignationId")]
        [InverseProperty("Users")]

        public virtual Designation? Designation { get; set; } = null!;
        [ForeignKey("GenderId")]
        [InverseProperty("Users")]
        public virtual Gender? Gender { get; set; } = null!;

        [ForeignKey("UserRoleId")]
        [InverseProperty("Users")]
        public virtual UserRole? UserRole { get; set; } = null!;

        [ForeignKey("VerifyStatusID")]
        [InverseProperty("Users")]
        public virtual VerifyStatus? VerifyStatus { get; set; } = null!;

        [InverseProperty("User")]
        public virtual ICollection<Query> Queries { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<QueryComment> QueryComments { get; set; }

        [InverseProperty("Reviewer")]
        public virtual ICollection<Article> ArticleReviewers { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Article> ArticleUsers { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<ArticleComment> ArticleComments { get; set; }
    }
}

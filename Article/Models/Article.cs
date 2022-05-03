using AspireOverflow.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AspireOverflow.Models
{
    public partial class Article : IAuditField
    {

        /*public Article()
        {
            ArticleComments = new HashSet<ArticleComment>();
           // ArticleLikes = new HashSet<ArticleLike>();
        }*/

        [Key]
        public int ArtileId { get; set; }

        public string Title {get; set;}

        public string Content { get; set; }

        public byte[] Image { get ; set; }

        public DateTime Datetime { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
        
        [ForeignKey("VerifyStatusID")]
        [InverseProperty("Articles")]
        public virtual VerifyStatus VerifyStatus { get; set; } 

        [ForeignKey("ReviewerId")]
        [InverseProperty("ArticleReviewers")]
        public virtual User? Reviewer { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("ArticleUsers")]
        public virtual User User { get; set; } = null!;

        [InverseProperty("Article")]
        public virtual ICollection<ArticleComment> ArticleComments { get; set; }
        
    }
}
using Abp.Domain.Entities;

namespace proiectLicenta.DateStackOverflow
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Post: Entity
    {
        public int? AcceptedAnswerId { get; set; }

        public int? AnswerCount { get; set; }

        [Key]
        [Column(Order = 1)]
        public string Body { get; set; }

        public DateTime? ClosedDate { get; set; }

        public int? CommentCount { get; set; }

        public DateTime? CommunityOwnedDate { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime CreationDate { get; set; }

        public int? FavoriteCount { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime LastActivityDate { get; set; }

        public DateTime? LastEditDate { get; set; }

        [StringLength(40)]
        public string LastEditorDisplayName { get; set; }

        public int? LastEditorUserId { get; set; }

        public int? OwnerUserId { get; set; }

        public int? ParentId { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PostTypeId { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Score { get; set; }

        [StringLength(150)]
        public string Tags { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ViewCount { get; set; }
    }
}

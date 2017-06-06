using Abp.Domain.Entities;

namespace proiectLicenta.DateStackOverflow
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class UserStackOverflow: Entity
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string AboutMe { get; set; }

        public int? Age { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime CreationDate { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(40)]
        public string DisplayName { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DownVotes { get; set; }

        [StringLength(40)]
        public string EmailHash { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime LastAccessDate { get; set; }

        [StringLength(100)]
        public string Location { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Reputation { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UpVotes { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Views { get; set; }

        [StringLength(200)]
        public string WebsiteUrl { get; set; }

        public int? AccountId { get; set; }
    }
}

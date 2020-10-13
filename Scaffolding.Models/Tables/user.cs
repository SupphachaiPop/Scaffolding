using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Scaffolding.Models
{
    [Table("user")]
    public class user
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(@"user_id", Order = 1, TypeName = SQLSERVER_CONST.INT)]
        [Required]
        [Key]
        public int user_id { get; set; } // user_id (Primary key)

        [Column(@"role_id", Order = 2, TypeName = SQLSERVER_CONST.INT)]
        [Required]
        public int role_id { get; set; } // role_id

        [Column(@"username", Order = 3, TypeName = SQLSERVER_CONST.VARCHAR_300)]
        [Required]
        [MaxLength(300)]
        [StringLength(300)]
        public string username { get; set; } // username (length: 300)

        [Column(@"password", Order = 4, TypeName = SQLSERVER_CONST.VARCHAR_300)]
        [Required]
        [MaxLength(300)]
        [StringLength(300)]
        public string password { get; set; } // password (length: 300)

        [Column(@"first_name", Order = 5, TypeName = SQLSERVER_CONST.VARCHAR_300)]
        [MaxLength(300)]
        [StringLength(300)]
        public string first_name { get; set; } // first_name (length: 300)

        [Column(@"last_name", Order = 6, TypeName = SQLSERVER_CONST.VARCHAR_300)]
        [MaxLength(300)]
        [StringLength(300)]
        public string last_name { get; set; } // last_name (length: 300)

        [Column(@"nick_name", Order = 7, TypeName = SQLSERVER_CONST.VARCHAR_300)]
        [MaxLength(300)]
        [StringLength(300)]
        public string nick_name { get; set; } // nick_name (length: 300)

        [Column(@"address", Order = 8, TypeName = SQLSERVER_CONST.VARCHAR_300)]
        [MaxLength(300)]
        [StringLength(300)]
        public string address { get; set; } // address (length: 300)

        [Column(@"email", Order = 9, TypeName = SQLSERVER_CONST.VARCHAR_300)]
        [MaxLength(300)]
        [StringLength(300)]
        public string email { get; set; } // email (length: 300)

        [Column(@"phone", Order = 10, TypeName = SQLSERVER_CONST.VARCHAR_10)]
        [MaxLength(10)]
        [StringLength(10)]
        public string phone { get; set; } // phone (length: 10)

        [Column(@"comment", Order = 11, TypeName = SQLSERVER_CONST.VARCHAR_4000)]
        [MaxLength(4000)]
        [StringLength(4000)]
        public string comment { get; set; } // comment (length: 4000)

        [Column(@"created_by", Order = 12, TypeName = SQLSERVER_CONST.INT)]
        public int? created_by { get; set; } // created_by

        [Column(@"created_date", Order = 13, TypeName = SQLSERVER_CONST.DATETIME)]
        public System.DateTime? created_date { get; set; } // created_date

        [Column(@"modified_by", Order = 14, TypeName = SQLSERVER_CONST.INT)]
        public int? modified_by { get; set; } // modified_by

        [Column(@"modified_date", Order = 15, TypeName = SQLSERVER_CONST.DATETIME)]
        public System.DateTime? modified_date { get; set; } // modified_date

        [Column(@"is_referred", Order = 16, TypeName = SQLSERVER_CONST.BIT)]
        public bool? is_referred { get; set; } // is_referred

        [Column(@"is_active", Order = 17, TypeName = SQLSERVER_CONST.BIT)]
        public bool? is_active { get; set; } // is_active

        [Column(@"is_deleted", Order = 18, TypeName = SQLSERVER_CONST.BIT)]
        public bool? is_deleted { get; set; } // is_deleted

        public virtual role role { get; set; } // fk_user_role_role_id

    }
}


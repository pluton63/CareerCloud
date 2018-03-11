﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CareerCloud.Pocos
{
    [Table("Company_Locations")]
    public class CompanyLocationPoco : IPoco
    {
        private Guid varId;
        private Guid varCompany;
        private String varCountryCode;
        private String varProvince;
        private String varStreet;
        private String varCity;
        private String varPostalCode;
        private Byte[] varTimeStamp;
        [Key]
        public Guid Id { get { return varId; } set { varId = value; } }
        [ForeignKey("CompanyProfiles")]
        public Guid Company { get { return varCompany; } set { varCompany = value; } }
        [Column("Country_Code")]
        public String CountryCode { get { return varCountryCode; } set { varCountryCode = value; } }
        [Column("State_Province_Code")]
        public String Province{ get { return varProvince; } set { varProvince = value; } }
        [Column("Street_Address")]
        public String Street { get { return varStreet; } set { varStreet = value; } }
        [Column("City_Town")]
        public String City { get { return varCity; } set { varCity = value; } }
        [Column("Zip_Postal_Code")]
        public String PostalCode { get { return varPostalCode; } set { varPostalCode = value; } }
        [Column("Time_Stamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        [Timestamp]
        public Byte[] TimeStamp { get { return varTimeStamp; } set { varTimeStamp = value; } }
        public virtual CompanyProfilePoco CompanyProfiles { get; set; }
    }
}
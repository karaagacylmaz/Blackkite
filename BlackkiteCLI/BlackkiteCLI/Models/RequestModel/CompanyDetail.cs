using System;
using System.Collections.Generic;
using System.Text;

namespace BlackkiteCLI.Models.RequestModel
{
    public class CompanyDetail
    {
        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string DomainName { get; set; }
        public string Type { get; set; }
        public CyberRating CyberRating { get; set; }
        public Compliance Compliance { get; set; }
        public FinancialImpact FinancialImpact { get; set; }
        public string DashboardLink { get; set; }
        public List<Ecosystem> Ecosystems { get; set; }
        public Industry Industry { get; set; }
        public string Country { get; set; }
        public List<Tag> Tags { get; set; }
        public string ScanStatus { get; set; }
    }

    public class Compliance
    {
        public int? Rating { get; set; }
        public int? Confidence { get; set; }
        public int? Completeness { get; set; }
        //public DateTime LastUpdatedAt { get; set; }
    }

    public class CyberRating
    {
        public string GradeLetter { get; set; }
        public int? Cyberrating { get; set; }
        public double BreachIndex { get; set; }
        public double RansomwareIndex { get; set; }
        //public DateTime CyberRatingLastUpdatedAt { get; set; }
        //public DateTime RansomwareIndexLastUpdatedAt { get; set; }
        //public DateTime BreachIndexLastUpdatedAt { get; set; }
    }

    public class Ecosystem
    {
        public int? EcosystemId { get; set; }
        public string EcosystemName { get; set; }
        //public DateTime InsertDate { get; set; }
        public string InsertUser { get; set; }
    }

    public class FinancialImpact
    {
        public int? Rating { get; set; }
        public int? RatingMin { get; set; }
        public int? RatingMax { get; set; }
        public int? LossMagnitude { get; set; }
        public double LossEventFrequency { get; set; }
        //public DateTime LastUpdatedAt { get; set; }
    }

    public class Industry
    {
        public int? IndustryId { get; set; }
        public string IndustryName { get; set; }
    }

    public class Tag
    {
        public int? TagId { get; set; }
        public string TagName { get; set; }
        public DateTime InsertDate { get; set; }
        public string InsertUser { get; set; }
    }

}

using System;
using SFCDentalGame.DAL.Entities;
namespace SFCDentalGame.Models
{
    public class DentalPracticeItem
    {
        public int DentalPracticeItemID
        {
            get;
            set;
        }
        public Behaviour Behaviour { get; set; }
        public Double Score
        {
            get;
            set;
        }
        public string DentalPracticeId
        {
            get;
            set;
        }
        public string FrequencyName
        {
            get;
            set;
        }
    }
}

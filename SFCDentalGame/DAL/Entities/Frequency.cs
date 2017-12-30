using System;
namespace SFCDentalGame.DAL.Entities
{
    public class BehaviourFrequency:Behaviour
    {
        public BehaviourFrequency()
        {
        }
        public int FrequencyId
        {
            get;
            set;
        }
        public string FrequencyName
        {
            get;
            set;
        }
        public decimal FrequencyPoints
        {
            get;
            set;
        }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SFCDentalGame.DAL.Entities
{
    public enum Freq1{OnceADay, TwiceADay, ThreeTimesAday}
    public enum Freq2 {Occasionally, Frequently, Never}
    public enum Freq3{Monthly, Quaterly, Semiannualy, Annually }
    public enum Freq4{Lessthan2minutes, About2minutes, MoreThan2Minutes}
    public class Frequency
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FrequencyId
        {
            get;
            set;
        }
        public string FrequencyName { get; set; }
        public decimal points { get; set; }
        public FreqBehaviour BehaviourWithFreq { get; set; }
        public Freq1? UsageBehaviour { get; set; }
        public Freq2? OtherSupporting { get; set; }
        public Freq3? LongerPractices { get; set; }

        public static implicit operator string(Frequency v)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;

namespace SFCDentalGame.DAL.Entities
{


    public class FreqBehaviour:Behaviour
    {
        public enum Freq1 { OnceADay, TwiceADay, ThreeTimesAday }
        public enum Freq2 { Occasionally, Frequently, Never }
        public enum Freq3 { Monthly, Quaterly, Semiannualy, Annually }
        public enum Freq4 { Lessthan2minutes, About2minutes, MoreThan2Minutes }

    public Freq1 UsageBehaviour { get; set; }
    public Freq2 OtherSupporting { get; set; }
    public Freq3 LongerPractices { get; set; }
    }
}

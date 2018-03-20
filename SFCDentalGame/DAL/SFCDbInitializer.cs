using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using SFCDentalGame.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace SFCDentalGame.DAL
{
    public class SFCDbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SFCContext(
                serviceProvider.GetRequiredService<DbContextOptions<SFCContext>>()))
            {

                if (context.Categories.Any())
                {
                    return;
                }

                context.Categories.AddRange(
                    new Category
                    {
                        CategoryName = "Health",
                        CategoryDescription = "Health related practices",
                        CategoryId = 1
                    },
                    new Category
                    {
                        CategoryName = "Hyiegiene",
                        CategoryDescription = "Health related practices",
                        CategoryId = 2
                    },
                    new Category
                    {
                        CategoryName = "Education",
                        CategoryDescription = "Health related practices",
                        CategoryId = 3
                    },
                    new Category
                    {
                        CategoryName = "Nutrition",
                        CategoryDescription = "Health related practices",
                        CategoryId = 4
                    }
                );
                context.SaveChanges();
                if (context.Frequency.Any())
                {
                    return;
                }
                context.Frequency.AddRange(
                    new Frequency
                    {
                        FrequencyId = 1,
                        FrequencyName = "Once a day",
                        points = 33
                    },
                    new Frequency
                    {
                        FrequencyId = 2,
                        FrequencyName = "Twice a day",
                        points = 67

                    },
                    new Frequency
                    {
                        FrequencyId = 3,
                        FrequencyName = "More than 2 times a day",
                        points = 75

                    },
                    new Frequency
                    {
                        FrequencyId = 4,
                        FrequencyName = "Less than 2 mins",
                        points = 33

                    },
                    new Frequency
                    {
                        FrequencyId = 5,
                        FrequencyName = "2 minutes",
                        points = 100
                    },
                    new Frequency
                    {
                        FrequencyId = 6,
                        FrequencyName = "More than 2 mins",
                        points = 67
                    },
                    new Frequency
                    {
                        FrequencyId = 7,
                        FrequencyName = "Weekly",
                        points = 67
                    },
                    new Frequency
                    {
                        FrequencyId = 8,
                        FrequencyName = "Monthly",
                        points = 67
                    },
                    new Frequency
                    {
                        FrequencyId = 9,
                        FrequencyName = "Quartely",
                        points = 67
                    },
                    new Frequency
                    {
                        FrequencyId = 10,
                        FrequencyName = "SemiAnualy",
                        points = 67
                    },
                    new Frequency
                    {
                        FrequencyId = 11,
                        FrequencyName = "Yearly",
                        points = 33
                    },
                    new Frequency
                    {
                        FrequencyId = 12,
                        FrequencyName = "Ocasionally",
                        points = 33
                    },
                    new Frequency
                    {
                        FrequencyId = 13,
                        FrequencyName = "Frequently",
                        points = 33,

                    }

                );
                context.SaveChanges();
                //if(context.FrequencyBehaviours.Any()){
                //    return;
                //}
                //context.FrequencyBehaviours.AddRange(
                //    new FreqBehaviour{
                //    BehaviourName="toothBrush"
                //}
                //);

                if (context.FrequencyBehaviours.Any())
                {
                    return;
                }
                context.FrequencyBehaviours.AddRange(
                    new FreqBehaviour
                    {
                        BehaviourName = "ToothBrush",
                        BehaviourType = "Electric",
                        BehaviourDescription = "My daily tooth brush is electric",
                        CategoryId = 2,
                        ProffesionalComment = "",
                        ratings = Behaviour.Rating.EXCELLENT,
                        Points = 100,

                        ImageUrl = "https://photos-1.dropbox.com/t/2/AACuZUXeTj0Cy78Kkwa0pYzh1Lmy4ZoQTfG6Dn9A9KWP4Q/12/132617565/jpeg/32x32/1/_/1/2/electric-toothbrush.jpg/EL_E5mUYgAsgBygH/VXF3fnxndb8M2lpwRNhSvnnmxyWfRBAe66xvMAnQPGE?size=2048x1536&size_mode=3"
                    },
                    new FreqBehaviour
                    {
                        BehaviourName = "ToothBrush",
                        BehaviourType = "Regular",
                        BehaviourDescription = "My daily tooth brush is a regular one",
                        CategoryId = 2,
                        ratings = Behaviour.Rating.EXCELLENT,
                        ProffesionalComment = "You brush excellent",

                        Points = 100,

                        ImageUrl = "https://photos-5.dropbox.com/t/2/AADnd1qSU9ZX28qt-sDl9r2NZwqJ0Jd3beXOUhoNYyxiqQ/12/132617565/jpeg/32x32/1/_/1/2/toothbrushes.jpg/EL_E5mUYmQsgBygH/3dUFe3EIL1zHpC3oUd_HZVAjtbUXlt7RGuAB0eUmiqk?size=2048x1536&size_mode=3"
                    },
                    new FreqBehaviour
                    {
                        BehaviourName = "Flossing",
                        BehaviourDescription = "Do you floss everyday and how often you perform such practice."
                        ,
                        ratings = Behaviour.Rating.EXCELLENT,
                        ProffesionalComment = "",
                        UsageBehaviour = FreqBehaviour.Freq1.TwiceADay,
                        BehaviourType = "Flossing",
                        CategoryId = 2,
                        Points = 100,
                        ImageUrl = "https://photos-1.dropbox.com/t/2/AAC1rBN2s9DL5xgBNQhW_neIcXsmulQ0gdLItv6RDQGl1A/12/132617565/jpeg/32x32/1/_/1/2/flossing.jpg/EL_E5mUYgwsgBygH/-x445jVIMb190BiDHLWt7D7_f0VDkjplt0AFvuMoIe0?size=2048x1536&size_mode=3"

                    },
                    new FreqBehaviour
                    {
                        BehaviourName = "Flossing",
                        BehaviourDescription = "Do you floss everyday and how often you perform such practice."
                        ,
                        ratings = Behaviour.Rating.BETTER,
                        ProffesionalComment = "",
                        UsageBehaviour = FreqBehaviour.Freq1.OnceADay,
                        BehaviourType = "Flossing",
                        CategoryId = 2,
                        Points = 50,
                        ImageUrl = "https://photos-1.dropbox.com/t/2/AAC1rBN2s9DL5xgBNQhW_neIcXsmulQ0gdLItv6RDQGl1A/12/132617565/jpeg/32x32/1/_/1/2/flossing.jpg/EL_E5mUYgwsgBygH/-x445jVIMb190BiDHLWt7D7_f0VDkjplt0AFvuMoIe0?size=2048x1536&size_mode=3"

                    },
                    new FreqBehaviour
                    {
                        BehaviourName = "Unwaxed Floss",
                        BehaviourType = "Flossing",
                        BehaviourDescription = "My daily dental floss is unwaxed",
                        CategoryId = 2,
                        ratings = Behaviour.Rating.BETTER,

                        Points = 70,

                        ImageUrl = "https://photos-2.dropbox.com/t/2/AACY7FfpcbSqSNFjH0q_7H-1GpHpFMDUNNnRrOjjsN7atg/12/132617565/jpeg/32x32/1/_/1/2/unwaxedFloss.jpg/EL_E5mUYmwsgBygH/YqKlV39rx3RJTES1PPfJM6IMuRYQNPjgwRIcs6Em1YM?size=2048x1536&size_mode=3"
                    },
                    new FreqBehaviour
                    {
                        BehaviourName = "Waxed Floss",
                        BehaviourType = "Flossing",
                        BehaviourDescription = "My daily dental floss is waxed",
                        CategoryId = 2,
                        ratings = Behaviour.Rating.EXCELLENT,

                        Points = 100,

                        ImageUrl = "https://photos-1.dropbox.com/t/2/AACsrH-dWhzSfL82L7BExmwU46vU9JtP2RTE5Y6R8tl8TA/12/132617565/jpeg/32x32/1/_/1/2/waxedFloss.jpg/EL_E5mUYnQsgBygH/MzGaO7oSSvZTGbfWx1gZRrfzeCzi2HeQEdF2zEQszJE?size=2048x1536&size_mode=3"
                    },
                    new FreqBehaviour
                    {
                        BehaviourName = "Teflon",
                        BehaviourType = "Flossing",
                        BehaviourDescription = "Polytetrafluoroethylene",
                        CategoryId = 2,
                        ratings = Behaviour.Rating.EXCELLENT,

                        Points = 100,

                        ImageUrl = "https://photos-3.dropbox.com/t/2/AAAVeUJLgiJNwcDmoA-iRZOLtQVv2iTvUsw9XmwPXYt80g/12/132617565/jpeg/32x32/1/_/1/2/teflonFloss.jpg/EL_E5mUYmAsgBygH/oBN-EmmX5zRXfyjxKSowWc0Q3Iop8fGY_G9RcJk5Pjc?size=2048x1536&size_mode=3"
                    },
                    new FreqBehaviour
                    {
                        BehaviourName = "Interdental Brush",
                        BehaviourType = "Flossing",
                        BehaviourDescription = "I have interdental brush",
                        CategoryId = 2,
                        ratings = Behaviour.Rating.EXCELLENT,

                        Points = 125,

                        ImageUrl = "https://photos-1.dropbox.com/t/2/AAArvPR_0gFyhD0kv3AozgH8IjKeSZCaIj7LcNy1aarEEA/12/132617565/jpeg/32x32/1/_/1/2/interdentalFloss.jpg/EL_E5mUYhwsgBygH/CV9osTwQ4NCp9HJMb2A_Mm1WHM-CCp41xlbD24rtUXo?size=2048x1536&size_mode=3"
                    },
                    new FreqBehaviour
                    {
                        BehaviourName = "Single tuffed Brush",
                        BehaviourType = "Flossing",
                        BehaviourDescription = "I use tuffed brush for flossing daily",
                        CategoryId = 2,
                        ratings = Behaviour.Rating.BETTER,

                        Points = 100,

                        ImageUrl = "https://photos-3.dropbox.com/t/2/AABx_3mQSqesg8ECBdvXPq0jUt9ggXdhhRhfuSAX2IpM3Q/12/132617565/png/32x32/1/_/1/2/singleTufled.png/EL_E5mUYkQsgBygH/k30TkPz98Rlt9pF_muzBtxfGwUYpVyvStkFHVUUARoM?preserve_transparency=1&size=2048x1536&size_mode=3"
                    },
                    new FreqBehaviour
                    {
                        BehaviourName = "Tongue Scrapers",
                        BehaviourType = "Mouth Clean",
                        BehaviourDescription = "I clean my tongue using Scrapers",
                        CategoryId = 2,
                        ratings = Behaviour.Rating.EXCELLENT,

                        Points = 100,

                        ImageUrl = "https://photos-3.dropbox.com/t/2/AADpi3Cap_6xYEQ1g2YtkpxeToR5VkWWv9ElbdqXmdU0-A/12/132617565/jpeg/32x32/1/_/1/2/various-tongue-cleaners.jpg/EL_E5mUYnAsgBygH/AuvU7-pDP8OU_ZF7XZvrXCLW_r6Av0O1n4WYc08llQE?size=2048x1536&size_mode=3"
                    },
                    new FreqBehaviour
                    {
                        BehaviourName = "Oral Irrigation",
                        BehaviourType = "Food and Drinks",
                        BehaviourDescription = "I Frequently use colored Drinks Like Wine and beer",
                        CategoryId = 1,
                        ratings = Behaviour.Rating.EXCELLENT,

                        Points = 100,
                        ProffesionalComment = "",
                        ImageUrl = "https://photos-2.dropbox.com/t/2/AAB51foYKZMwxoFGPbXmDDvBF49XGf-yy24hTRbLUD4jNw/12/132617565/jpeg/32x32/1/_/1/2/oralIrrigation.jpg/EL_E5mUYjAsgBygH/LH68T5y0uF49pTMsbYpiJb1yDVxozkvgMfi2Ls2bqRY?size=2048x1536&size_mode=3"
                    },
                    new FreqBehaviour
                    {
                        BehaviourName = "Smoking",
                        BehaviourType = "Health",
                        BehaviourDescription = "I smoke regulary",
                        CategoryId = 2,
                        ratings = Behaviour.Rating.GOOD,
                        Points = 0,
                        OtherSupporting = FreqBehaviour.Freq2.Frequently,
                        ImageUrl = "https://photos-6.dropbox.com/t/2/AAAQmDdKInckUMsaTUANMMH60Qhks7y0GtKQ3gm2ESWEOQ/12/132617565/jpeg/32x32/1/_/1/2/smoking.jpg/EL_E5mUYkQsgBygH/6esAFvGrvWvvKoi6Gl9Yfo3GLTwsXZebqNfILIP8rrk?size=2048x1536&size_mode=3"
                    },
                    new FreqBehaviour
                    {
                        BehaviourName = "Smoking",
                        BehaviourType = "Health",
                        BehaviourDescription = "I smoke regulary",
                        CategoryId = 2,
                        ratings = Behaviour.Rating.BETTER,
                        Points = 33,
                        OtherSupporting = FreqBehaviour.Freq2.Occasionally,
                        ImageUrl = "https://photos-6.dropbox.com/t/2/AAAQmDdKInckUMsaTUANMMH60Qhks7y0GtKQ3gm2ESWEOQ/12/132617565/jpeg/32x32/1/_/1/2/smoking.jpg/EL_E5mUYkQsgBygH/6esAFvGrvWvvKoi6Gl9Yfo3GLTwsXZebqNfILIP8rrk?size=2048x1536&size_mode=3"
                    },
                    new FreqBehaviour
                    {
                        BehaviourName = "Smoking",
                        BehaviourType = "Health",
                        BehaviourDescription = "I smoke regulary",
                        CategoryId = 2,
                        ratings = Behaviour.Rating.EXCELLENT,
                        Points = 100,
                        OtherSupporting = FreqBehaviour.Freq2.Never,
                        ProffesionalComment = "",
                        ImageUrl = "https://photos-6.dropbox.com/t/2/AAAQmDdKInckUMsaTUANMMH60Qhks7y0GtKQ3gm2ESWEOQ/12/132617565/jpeg/32x32/1/_/1/2/smoking.jpg/EL_E5mUYkQsgBygH/6esAFvGrvWvvKoi6Gl9Yfo3GLTwsXZebqNfILIP8rrk?size=2048x1536&size_mode=3"
                    },
                    new FreqBehaviour
                    {
                        BehaviourName = "Heavy Drinks ",
                        BehaviourType = "Health",
                        BehaviourDescription = "My drinks are of high alcohol concentration ",
                        CategoryId = 1,
                        ratings = Behaviour.Rating.GOOD,
                        OtherSupporting = FreqBehaviour.Freq2.Frequently,
                        ProffesionalComment = "",
                        Points = 0,

                        ImageUrl = "https://photos-2.dropbox.com/t/2/AACyVo9YiX0gGRtvHl4u-7G7zgEGi6zZPLga3Aa4MXA-Vg/12/132617565/jpeg/32x32/1/_/1/2/drinking.jpg/EL_E5mUY_wogBygH/YPwjpqnVUZYH33-b7J1KoL-xsPwu-pUtPb3uPt__BQY?size=2048x1536&size_mode=3"
                    },
                    new FreqBehaviour
                    {
                        BehaviourName = "Heavy Drinks ",
                        BehaviourType = "Health",
                        BehaviourDescription = "My drinks are of high alcohol concentration ",
                        CategoryId = 1,
                        ratings = Behaviour.Rating.BETTER,
                        OtherSupporting = FreqBehaviour.Freq2.Occasionally,
                        ProffesionalComment = "",
                        Points = 33,
                        ImageUrl = "https://photos-2.dropbox.com/t/2/AACyVo9YiX0gGRtvHl4u-7G7zgEGi6zZPLga3Aa4MXA-Vg/12/132617565/jpeg/32x32/1/_/1/2/drinking.jpg/EL_E5mUY_wogBygH/YPwjpqnVUZYH33-b7J1KoL-xsPwu-pUtPb3uPt__BQY?size=2048x1536&size_mode=3"
                    },
                    new FreqBehaviour
                    {
                        BehaviourName = "Heavy Drinks ",
                        BehaviourType = "Health",
                        BehaviourDescription = "My drinks are of high alcohol concentration ",
                        CategoryId = 1,
                        ratings = Behaviour.Rating.EXCELLENT,
                        OtherSupporting = FreqBehaviour.Freq2.Never,
                        ProffesionalComment = "",
                        Points = 100,

                        ImageUrl = "https://photos-2.dropbox.com/t/2/AACyVo9YiX0gGRtvHl4u-7G7zgEGi6zZPLga3Aa4MXA-Vg/12/132617565/jpeg/32x32/1/_/1/2/drinking.jpg/EL_E5mUY_wogBygH/YPwjpqnVUZYH33-b7J1KoL-xsPwu-pUtPb3uPt__BQY?size=2048x1536&size_mode=3"
                    },
                    new FreqBehaviour
                    {
                        BehaviourName = "Saline mouth wash",
                        BehaviourType = "Mouth Wash",
                        BehaviourDescription = "I use saline mouth wash",
                        CategoryId = 2,
                        Points = 75,
                        ratings = Behaviour.Rating.BETTER,
                        ImageUrl = "https://photos-2.dropbox.com/t/2/AADl97h-mae-PS_GuUFKRGN6MqDXV2_09-St379ThENtig/12/132617565/jpeg/32x32/1/_/1/2/salineMouth.jpg/EL_E5mUYjgsgBygH/p_WzznjPqxIOwkfenJoPA82AzDV5D3iw588ZvqUS2EI?size=2048x1536&size_mode=3"
                    },
                    new FreqBehaviour
                    {
                        BehaviourName = "Essential oils mouth wash",
                        BehaviourType = "Mouth wash",
                        BehaviourDescription = "I use EO brands like Listerine ",
                        CategoryId = 2,
                        ratings = Behaviour.Rating.EXCELLENT,
                        ProffesionalComment = "",
                        Points = 100,
                        ImageUrl = "https://photos-1.dropbox.com/t/2/AACvl95JNNzP9KTU_recrKBahxXGv-R4L-E-fr3g-o327Q/12/132617565/jpeg/32x32/1/_/1/2/EOmouthwash.jpg/EL_E5mUYgQsgBygH/fCuUQaiA53EZgmTfpID5HAqRHgd9Q7us4_8QBfz707Y?size=2048x1536&size_mode=3"
                    },
                    new FreqBehaviour
                    {
                        BehaviourName = "CPC Mouth wash brand",
                        BehaviourType = "Electric",
                        BehaviourDescription = "I use CPC brads Like Colgate plax, crest pro, oral B rinse",
                        CategoryId = 2,
                        ratings = Behaviour.Rating.EXCELLENT,
                        ProffesionalComment = "",
                        Points = 100,
                        ImageUrl = "https://photos-4.dropbox.com/t/2/AABi3QQcPEM2GvY4kpnRAIAV6k7L7YjU-iDPNkwvYdyRfg/12/132617565/jpeg/32x32/1/_/1/2/CPC%20Mouthwash.jpg/EL_E5mUYngsgBygH/UaSTqD4CSi5ktQFA7pnbPjdqanWp0902LmyDwaWwU5s?size=2048x1536&size_mode=3"
                    },
                    new FreqBehaviour
                    {
                        BehaviourName = "Teeth Cleaning",
                        BehaviourType = "Health",
                        BehaviourDescription = "I occasionally get teeth cleaned by a dentist",
                        CategoryId = 1,
                        ratings = Behaviour.Rating.GOOD,
                        LongerPractices = FreqBehaviour.Freq3.Annually,
                        Points = 50,
                        ProffesionalComment = "",
                        ImageUrl = "https://photos-5.dropbox.com/t/2/AADnw02gu4D7wLNIWsEpmdf6C7DzYbTuYJJE0MvNggaPuQ/12/132617565/png/32x32/1/_/1/2/cleaning.png/EL_E5mUY-wogBygH/P2HdS4dQz_xc5t2ud0mL4iDUGWeClI6WZ1CjY8fKJxc?preserve_transparency=1&size=2048x1536&size_mode=3"
                    },
                    new FreqBehaviour
                    {
                        BehaviourName = "Teeth Cleaning",
                        BehaviourType = "Health",
                        BehaviourDescription = "I occasionally get teeth cleaned by a dentist",
                        CategoryId = 1,
                        ratings = Behaviour.Rating.EXCELLENT,
                        LongerPractices = FreqBehaviour.Freq3.Semiannualy,
                        Points = 100,
                        ProffesionalComment = "",
                        ImageUrl = "https://photos-5.dropbox.com/t/2/AADnw02gu4D7wLNIWsEpmdf6C7DzYbTuYJJE0MvNggaPuQ/12/132617565/png/32x32/1/_/1/2/cleaning.png/EL_E5mUY-wogBygH/P2HdS4dQz_xc5t2ud0mL4iDUGWeClI6WZ1CjY8fKJxc?preserve_transparency=1&size=2048x1536&size_mode=3"
                    },
                    new FreqBehaviour
                    {
                        BehaviourName = "Doctor visits",
                        BehaviourType = "Health",
                        BehaviourDescription = "I get oral examination by a dentist occasionally",
                        CategoryId = 1,
                        ratings = Behaviour.Rating.EXCELLENT,
                        Points = 100,
                        LongerPractices = FreqBehaviour.Freq3.Quaterly,
                        ImageUrl = "https://photos-5.dropbox.com/t/2/AAAILWlQdTm7y7Bw-lFPspo7hc_ZwWJinY_fKQ_xTpeUOg/12/132617565/png/32x32/1/_/1/2/doctorvisist.png/EL_E5mUY_gogBygH/TPD1JBRXWlq_hAPYJdKKUd5JGTj8W_zSiarm_TlmP9o?preserve_transparency=1&size=2048x1536&size_mode=3"
                    },
                    new FreqBehaviour
                    {
                        BehaviourName = "Basic teeth and moth cleaning training",
                        BehaviourType = "Mouth Cleaning",
                        BehaviourDescription = "I have been trained on proper dental hyiegiene and I practice one",
                        CategoryId = 3,
                        ratings = Behaviour.Rating.EXCELLENT,
                        Points = 100,
                        ProffesionalComment = "",
                        ImageUrl = "https://photos-2.dropbox.com/t/2/AADIlCE9nCz3iVcoJ6QqSoO0azC30t2uCddHwEq8p_Wt7w/12/132617565/jpeg/32x32/1/_/1/2/correct_tooth_brushing_technique.jpg/EL_E5mUY_AogBygH/TuI5hVnFoLSRhDNUd0wsMUUeleKzn6RJOGKi-8G2pvs?size=2048x1536&size_mode=3"
                    },
                    new FreqBehaviour
                    {
                        BehaviourName = "Best oral Hyiegine practices",
                        BehaviourType = "Electric",
                        BehaviourDescription = "I occasionally read or attend workshops on oral health",
                        CategoryId = 3,
                        ratings = Behaviour.Rating.EXCELLENT,
                        Points = 100,
                        ProffesionalComment = "",
                        ImageUrl = "https://photos-4.dropbox.com/t/2/AAAzW1PCHR1VF0lXvig27pLGIDb5-QHIEc_sSWHwyI-9Mw/12/132617565/png/32x32/1/_/1/2/happyteeth.png/EL_E5mUYhgsgBygH/aYtm1PAQp67kGzWIUw34qsU1jANHgDWOpGSsvhVPkAE?preserve_transparency=1&size=2048x1536&size_mode=3"
                    },
                new FreqBehaviour
                {
                    BehaviourName = "Teeth longenvity",
                    BehaviourType = "Longer health teeth",
                    BehaviourDescription = "I understand how to keep my teeth and oral health in check",
                    CategoryId = 3,
                    ratings = Behaviour.Rating.EXCELLENT,
                    Points = 100,
                    ProffesionalComment = "",
                    ImageUrl = "https://photos-1.dropbox.com/t/2/AAA41cdLUYPEw6N6RrXM6q2KmE9lB8_MNSq8dy7x_s7-TQ/12/132617565/jpeg/32x32/1/_/1/2/mouth.jpg/EL_E5mUYigsgBygH/DnvB8goP9ojyHwLy6NJilrMlltsQYZIjbGx9lAYGUgg?size=2048x1536&size_mode=3"
                }
                );

                context.SaveChanges();
  
            if(context.RangeBehaviours.Any()){
                    return;
                }
                context.RangeBehaviours.AddRange(
                    new RangeBehaviour
                    {
                        BehaviourName = "Fruits",
                        BehaviourType = "Food and Drinks",
                        BehaviourDescription = "My diet involves fruits",
                        CategoryId = 4, ratings=Behaviour.Rating.EXCELLENT, 
                        Points = 100, Range=RangeBehaviour.Ranges.greterathan60,

                        ImageUrl = "https://photos-5.dropbox.com/t/2/AACbFnSlo6QrQULJx7wL4ei-PMGllCWlz_JdsqeHoqpQUg/12/132617565/jpeg/32x32/1/_/1/2/fruits.jpg/EL_E5mUYhAsgBygH/qvaEdSWpeOZAmCWKPKphESNFv60Pm8OORAe8CUvTuX8?size=2048x1536&size_mode=3"
                    },
                    new RangeBehaviour
                      {
                          BehaviourName = "Fruits",
                          BehaviourType = "Food and Drinks",
                          BehaviourDescription = "My diet involves fruits",
                          CategoryId = 4,
                           ratings = Behaviour.Rating.BETTER,
                          Points = 67,
                            Range = RangeBehaviour.Ranges.Between40and60,

                          ImageUrl = "https://photos-5.dropbox.com/t/2/AACbFnSlo6QrQULJx7wL4ei-PMGllCWlz_JdsqeHoqpQUg/12/132617565/jpeg/32x32/1/_/1/2/fruits.jpg/EL_E5mUYhAsgBygH/qvaEdSWpeOZAmCWKPKphESNFv60Pm8OORAe8CUvTuX8?size=2048x1536&size_mode=3"
                      },
                    new RangeBehaviour
                      {
                          BehaviourName = "Fruits",
                          BehaviourType = "Food and Drinks",
                          BehaviourDescription = "My diet involves fruits",
                          CategoryId = 4,
                    ratings = Behaviour.Rating.GOOD,
                          Points = 34,
                    Range = RangeBehaviour.Ranges.Lessthan40,

                          ImageUrl = "https://photos-5.dropbox.com/t/2/AACbFnSlo6QrQULJx7wL4ei-PMGllCWlz_JdsqeHoqpQUg/12/132617565/jpeg/32x32/1/_/1/2/fruits.jpg/EL_E5mUYhAsgBygH/qvaEdSWpeOZAmCWKPKphESNFv60Pm8OORAe8CUvTuX8?size=2048x1536&size_mode=3"
                      },
                    new RangeBehaviour
                {
                    BehaviourName = "Balanced Diet",
                    BehaviourType = "Food and Drinks",
                    BehaviourDescription = "I eat healthy foods and balanced in nutrients",
                    CategoryId = 4, ratings=Behaviour.Rating.EXCELLENT, Range=RangeBehaviour.Ranges.greterathan60,

                    Points = 100,

                    ImageUrl = "https://photos-3.dropbox.com/t/2/AAC9lw_n-WBeTH0AiGu1zeu1KUatUHuGACRzvth3Qb5hWg/12/132617565/jpeg/32x32/1/_/1/2/balancedDiet.jpg/EL_E5mUY-gogBygH/t4zsbpNOA4J_hmesGUz-UbUUDZSzVenNXSPI7uWCRgw?size=2048x1536&size_mode=3"
                },
                    new RangeBehaviour
                       {
                           BehaviourName = "Balanced Diet",
                           BehaviourType = "Food and Drinks",
                           BehaviourDescription = "I eat healthy foods and balanced in nutrients",
                           CategoryId = 4,
                            ratings = Behaviour.Rating.GOOD,
                             Range = RangeBehaviour.Ranges.Lessthan40,

                           Points = 34,

                           ImageUrl = "https://photos-3.dropbox.com/t/2/AAC9lw_n-WBeTH0AiGu1zeu1KUatUHuGACRzvth3Qb5hWg/12/132617565/jpeg/32x32/1/_/1/2/balancedDiet.jpg/EL_E5mUY-gogBygH/t4zsbpNOA4J_hmesGUz-UbUUDZSzVenNXSPI7uWCRgw?size=2048x1536&size_mode=3"
                       },
                    new RangeBehaviour
                       {
                           BehaviourName = "Balanced Diet",
                           BehaviourType = "Food and Drinks",
                           BehaviourDescription = "I eat healthy foods and balanced in nutrients",
                           CategoryId = 4,
                           ratings = Behaviour.Rating.GOOD,
                    Range = RangeBehaviour.Ranges.Between40and60,

                    Points = 67, ProffesionalComment="",

                           ImageUrl = "https://photos-3.dropbox.com/t/2/AAC9lw_n-WBeTH0AiGu1zeu1KUatUHuGACRzvth3Qb5hWg/12/132617565/jpeg/32x32/1/_/1/2/balancedDiet.jpg/EL_E5mUY-gogBygH/t4zsbpNOA4J_hmesGUz-UbUUDZSzVenNXSPI7uWCRgw?size=2048x1536&size_mode=3"
                       },
                    new RangeBehaviour
                {
                    BehaviourName = "Milk and Cheese",
                    BehaviourType = "Food and Drinks",
                    BehaviourDescription = "I take food with cheese and milk",
                    CategoryId = 4, ProffesionalComment="", Range=RangeBehaviour.Ranges.Between40and60, ratings=Behaviour.Rating.BETTER,

                    Points = 100,

                    ImageUrl = "https://photos-5.dropbox.com/t/2/AAA8LnbC9DKztMPkPPb3AjPZyfJijiFG3xtBMJQ13CvEJA/12/132617565/jpeg/32x32/1/_/1/2/milk%20and%20cheese.jpg/EL_E5mUYiQsgBygH/5wgMLTHe20OrOPLxQBLfH6TJXo6gDkj7BOu8a_jPGYQ?size=2048x1536&size_mode=3"
                },

                    new RangeBehaviour
                {
                    BehaviourName = "Fiber rich foods",
                    BehaviourType = "Food and Drinks",
                    BehaviourDescription = "Foods that are rich in fiber",
                    CategoryId = 4,
                    ProffesionalComment="",
                    Points = 100,
                    ratings=Behaviour.Rating.EXCELLENT, Range=RangeBehaviour.Ranges.greterathan60,
                    ImageUrl = "https://photos-1.dropbox.com/t/2/AACeYoSnYhpYHuw1ehqjujHDClP0ecYtNAzyvS9_-47apg/12/132617565/jpeg/32x32/1/_/1/2/dietary-fiber.jpg/EL_E5mUY_QogBygH/lmDlBlvQegs6w9RcRpn_kZSKLxN5f6K-58cBiOjm_gY?size=2048x1536&size_mode=3"
                },
                    new RangeBehaviour
                        {
                            BehaviourName = "Fiber rich foods",
                            BehaviourType = "Food and Drinks",
                            BehaviourDescription = "Foods that are rich in fiber",
                            CategoryId = 4,
                            ProffesionalComment = "",
                            Points = 100,
                    ratings = Behaviour.Rating.BETTER,
                    Range = RangeBehaviour.Ranges.Between40and60,
                            ImageUrl = "https://photos-1.dropbox.com/t/2/AACeYoSnYhpYHuw1ehqjujHDClP0ecYtNAzyvS9_-47apg/12/132617565/jpeg/32x32/1/_/1/2/dietary-fiber.jpg/EL_E5mUY_QogBygH/lmDlBlvQegs6w9RcRpn_kZSKLxN5f6K-58cBiOjm_gY?size=2048x1536&size_mode=3"
                        },
                    new RangeBehaviour
                {
                    BehaviourName = "Sugars",
                    BehaviourType = "Food and Drinks",
                    BehaviourDescription = "I take sugars",
                    CategoryId = 4,
                    ratings=Behaviour.Rating.EXCELLENT,
                    Points = 10,
                    Range=RangeBehaviour.Ranges.Lessthan40,
                    ProffesionalComment="",
                    ImageUrl = "https://photos-4.dropbox.com/t/2/AAC2lg3mTYWfu2uFuyruuQXazBgpXT9mJFFQQehIzw5Ilw/12/132617565/jpeg/32x32/1/_/1/2/sugrars.jpg/EL_E5mUYlAsgBygH/5SzH_aOX7iY3t-j42l6Oz_ETnGA4U2Q0-EGbSF8D_WY?size=2048x1536&size_mode=3"
                },
                new RangeBehaviour
                         {
                             BehaviourName = "Sugars",
                             BehaviourType = "Food and Drinks",
                             BehaviourDescription = "I take sugars",
                             CategoryId = 4,
                    ratings = Behaviour.Rating.BETTER,
                             Points = 10,
                    Range = RangeBehaviour.Ranges.Between40and60, ProffesionalComment="",
                             ImageUrl = "https://photos-4.dropbox.com/t/2/AAC2lg3mTYWfu2uFuyruuQXazBgpXT9mJFFQQehIzw5Ilw/12/132617565/jpeg/32x32/1/_/1/2/sugrars.jpg/EL_E5mUYlAsgBygH/5SzH_aOX7iY3t-j42l6Oz_ETnGA4U2Q0-EGbSF8D_WY?size=2048x1536&size_mode=3"
                         },

                    new RangeBehaviour
                {
                    BehaviourName = "Sugar free Gums",
                    BehaviourType = "Food and Drinks",
                    BehaviourDescription = "Chewing gums after meal",
                    CategoryId = 4,
                    ratings=Behaviour.Rating.EXCELLENT,
                    Points = 75,
                    ProffesionalComment="",
                    ImageUrl = "https://www.dropbox.com/pri/get/SylvanFamily/sugarFreegums.gif?_subject_uid=132617565&raw=1&size=2048x1536&size_mode=3&w=AAADf0cpcWSe_tRMXybESHu_t3tnrhR67uFv-IhX6Zkovg"
                },
                    new RangeBehaviour
                {
                    BehaviourName = "Sugar gums",
                    BehaviourType = "Food and Drinks",
                    BehaviourDescription = " My gum contains sugars",
                    CategoryId = 2,
                    ratings=Behaviour.Rating.BETTER,
                    Points = 25,
                    ProffesionalComment="",
                    ImageUrl = "https://photos-2.dropbox.com/t/2/AADiQnDFE8bbdtTWY07QJ_ZxCzVrXk-xntH9OVgMIx9qsg/12/132617565/jpeg/32x32/1/_/1/2/sugar-gums.jpg/EL_E5mUYkgsgBygH/ZT1aCX9SPi0Yl9A7-LzXZvqQVlwQrSqDqP8h2bN66Bw?size=2048x1536&size_mode=3"
                },
                    new RangeBehaviour
                {
                    BehaviourName = "Ice chewing",
                    BehaviourType = "Food and Drinks",
                    BehaviourDescription = "I like cold beverages and chewing ice",
                    CategoryId = 2,
                    ratings=Behaviour.Rating.GOOD,
                    Points = 0,

                    ImageUrl = "https://photos-6.dropbox.com/t/2/AACXIsVHOOCB-QaclGHAJyxJm3CLcYUbl3WPskPPxF7PlQ/12/132617565/jpeg/32x32/1/_/1/2/iceChewi.jpg/EL_E5mUYhgsgBygH/DGgFnPWLfxHxGHwEyRMQeEiRnUQb7CSNoAsPsWCf0F4?size=2048x1536&size_mode=3"
                }


                //new Behaviour
                //{
                //    BehaviourName = "Toothpaste",
                //    BehaviourType = "Toothpaste",
                //    BehaviourDescription = "My toothpaste is che cheapest I could find",
                //    CategoryId = 2,

                //    Points = 50,

                //    ImageUrl = "https://photos-1.dropbox.com/t/2/AAB-qhYtJjQCQMeYuNXkGW4EPpfl3dWMVLGXG2bREZhY8g/12/132617565/jpeg/32x32/1/_/1/2/toothpaste.jpg/EL_E5mUYmgsgBygH/_LUyto8giPSDp_IY5JxPAPaU-dxxK3Q5k7BiV7uM4Do?size=2048x1536&size_mode=3"
                //},
                //new Behaviour
                //{
                //    BehaviourName = "No ToothPaste ",
                //    BehaviourType = "Electric",
                //    BehaviourDescription = "I dont use toothpaste",
                //    CategoryId = 2,

                //    Points = 25,

                //    ImageUrl = "https://photos-4.dropbox.com/t/2/AAD3oix8exwXZKevMFgFGXf3vfGGIrvxBj58omgjuwJzYA/12/132617565/jpeg/32x32/1/_/1/2/notoothpaste-1.jpg/EL_E5mUYjAsgBygH/NtVd9iIXrk-Jcaz6OJpQQ1JrMw9780OKvK3skkuUbHc?size=2048x1536&size_mode=3"
                //},
                //new Behaviour
                //{
                //    BehaviourName = "Traditional ToothBrush",
                //    BehaviourType = "Traditional",
                //    BehaviourDescription = "I dont use industrial toothbrush I have herbs",
                //    CategoryId = 2,

                //    Points = 50,

                //    ImageUrl = "https://photos-1.dropbox.com/t/2/AAA9HXfjRprmXCVm5sE2_wbKedQWnFT_dZIslKo9aMzraw/12/132617565/png/32x32/1/_/1/2/Miswak.png/EL_E5mUYiQsgBygH/XAwGaUsqx2lzljD0pA_HjMyG7aY_mXiqDIxvEDVw0TE?preserve_transparency=1&size=2048x1536&size_mode=3"
                //},
                //new Behaviour
                //{
                //    BehaviourName = "Gum Disease",
                //    BehaviourType = "Diseases",
                //    BehaviourDescription = "I have gum diseases",
                //    CategoryId = 1,

                //    Points = 0,

                //    ImageUrl = "https://photos-1.dropbox.com/t/2/AAD-rc5WeuYn-BE70VMtt1G05CotDdaBCepZPUJaQETucw/12/132617565/jpeg/32x32/1/_/1/2/periodontitis_blog_post_image.jpg/EL_E5mUYjQsgBygH/XjpjqO1NE4fAlGcYn6rrn6TOU5LvU-0BiM68R4e_CaE?size=2048x1536&size_mode=3"
                //},
                //new Behaviour
                //{
                //    BehaviourName = "Mouth Disease",
                //    BehaviourType = "Diseases",
                //    BehaviourDescription = "I have mouth related diseases (bad breadth etc)",
                //    CategoryId = 1,

                //    Points = 0,

                //},
                //new Behaviour
                //{
                //    BehaviourName = "Sensitivity",
                //    BehaviourType = "Diseases",
                //    BehaviourDescription = "Severe teeth sensitivity",
                //    CategoryId = 1,

                //    Points = 0,

                //    ImageUrl = "https://photos-5.dropbox.com/t/2/AAAQuxoXWC-ku1WJo3vVoOLKlrFC5jsjkCyuXlChlkpn4w/12/132617565/jpeg/32x32/1/_/1/2/sensitive%20teeth.jpg/EL_E5mUYjwsgBygH/QHzYaPc0OG-apmQPa31PHGet0zmgTSXN8TUWnyXEIz0?size=2048x1536&size_mode=3"
                //},
                //new Behaviour
                //{
                //    BehaviourName = "Extraction",
                //    BehaviourType = "Teeth",
                //    BehaviourDescription = "I have had extractions",
                //    CategoryId = 1,
                //    Points = 20,

                //    ImageUrl = "https://photos-5.dropbox.com/t/2/AAAVNTLDtzSFrO9SDkQnglvxq4f-nFhVE6nCrcE8Ib4qTQ/12/132617565/jpeg/32x32/1/_/1/2/extraction.jpg/EL_E5mUYggsgBygH/TVJzOsIGYp88KC67HYPoh6M2OY452L-0VEgFby6n_B0?size=2048x1536&size_mode=3"
                //}
                
                );
             context.SaveChanges();
        }
        }
    }
}

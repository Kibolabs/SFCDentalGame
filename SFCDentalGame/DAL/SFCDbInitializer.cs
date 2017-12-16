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

                if(context.Categories.Any()){
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
                if(context.Behaviours.Any()){
                    return;
                }
                context.Behaviours.AddRange(
                new Behaviour
                {
                    BehaviourName = "ToothBrush",
                    BehaviourType = "Electric",
                    BehaviourDescription = "My daily tooth brush is electric",
                    CategoryId =2,
                    InPractice = true,
                    Points = 100,
                    value = 100, Frequency=Frequency.DAILY
                },
                new Behaviour
                {
                    BehaviourName = "ToothBrush",
                    BehaviourType = "Regular",
                    BehaviourDescription = "My daily tooth brush is a regular one",
                    CategoryId = 2,
                    InPractice = true,
                    Points = 100,
                    value = 100,Frequency=Frequency.DAILY
                },
                new Behaviour
                {
                    BehaviourName = "Unwaxed Floss",
                    BehaviourType = "Flossing",
                    BehaviourDescription = "My daily dental floss is unwaxed",
                    CategoryId = 2,
                    InPractice = true,
                    Points = 100,
                    value = 100,Frequency=Frequency.TWICEADAY
                },
                new Behaviour
                {
                    BehaviourName = "Waxed Floss",
                    BehaviourType = "Flossing",
                    BehaviourDescription = "My daily dental floss is waxed",
                    CategoryId = 2,
                    InPractice = true,
                    Points = 100,
                    value = 100,Frequency=Frequency.DAILY
                },
                new Behaviour
                {
                    BehaviourName = "Teflon",
                    BehaviourType = "Flossing",
                    BehaviourDescription = "Polytetrafluoroethylene",
                    CategoryId = 2,
                    InPractice = true,
                    Points = 100,
                    value = 100,Frequency=Frequency.DAILY
                },
                new Behaviour
                {
                    BehaviourName = "Interdental Brush",
                    BehaviourType = "Flossing",
                    BehaviourDescription = "I have interdental brush",
                    CategoryId = 2,
                    InPractice = true,
                    Points = 125,
                    value = 125,Frequency=Frequency.DAILY
                },
                new Behaviour
                {
                    BehaviourName = "Single tuffed Brush",
                    BehaviourType = "Flossing",
                    BehaviourDescription = "I use tuffed brush for flossing daily",
                    CategoryId = 2,
                    InPractice = true,
                    Points = 100,
                    value = 100,Frequency=Frequency.DAILY
                },
                new Behaviour
                {
                    BehaviourName = "Tongue Scrapers",
                    BehaviourType = "Mouth Clean",
                    BehaviourDescription = "I clean my tongue using Scrapers",
                    CategoryId = 2,
                    InPractice = true,
                    Points = 100,
                    value = 100,Frequency=Frequency.DAILY
                },
                new Behaviour
                {
                    BehaviourName = "Oral Irrigation",
                    BehaviourType = "Food and Drinks",
                    BehaviourDescription = "I Frequently use colored Drinks Like Wine and beer",
                    CategoryId = 1,
                    InPractice = true,
                    Points = 100,
                    value = 100,Frequency=Frequency.DAILY
                },
                new Behaviour
                {
                    BehaviourName = "Fruits",
                    BehaviourType = "Food and Drinks",
                    BehaviourDescription = "My diet involves fruits",
                    CategoryId = 4,
                    InPractice = true,
                    Points = 100,
                    value = 100,Frequency=Frequency.DAILY
                },
                new Behaviour
                {
                    BehaviourName = "Balanced Diet with Snacks",
                    BehaviourType = "Food and Drinks",
                    BehaviourDescription = "I eat healthy foods and balanced in nutrients",
                    CategoryId = 4,
                    InPractice = true,
                    Points = 100,
                    value = 100, Frequency=Frequency.DAILY
                },
                new Behaviour
                {
                    BehaviourName = "Milk and Cheese",
                    BehaviourType = "Food and Drinks",
                    BehaviourDescription = "I take food with cheese and milk",
                    CategoryId = 4,
                    InPractice = true,
                    Points = 50,
                    value = 50, Frequency=Frequency.DAILY
                },
                new Behaviour
                {
                    BehaviourName = "No Milk or cheese",
                    BehaviourType = "Food and Drinks",
                    BehaviourDescription = "I take less milk and or cheese",
                    CategoryId = 4,
                    InPractice = true,
                    Points = 25,
                    value = 25, Frequency=Frequency.DAILY
                },
                new Behaviour
                {
                    BehaviourName = "Fiber rich foods",
                    BehaviourType = "Food and Drinks",
                    BehaviourDescription = "Foods that are rich in fiber",
                    CategoryId = 4,
                    InPractice = true,
                    Points = 100,
                    value = 100, Frequency=Frequency.OCASSIONALY
                },
                new Behaviour
                {
                    BehaviourName = "Sugars",
                    BehaviourType = "Food and Drinks",
                    BehaviourDescription = "I take sugars",
                    CategoryId = 4,
                    InPractice = true,
                    Points = 10,
                    value = 10, Frequency=Frequency.OCASSIONALY
                },
                new Behaviour
                {
                    BehaviourName = "Toffee",
                    BehaviourType = "Foods and Drinks",
                    BehaviourDescription = "I enjoy taking a toffee",
                    CategoryId = 4,
                    InPractice = true,
                    Points = 0,
                    value = 0, Frequency=Frequency.OCASSIONALY
                },
                new Behaviour
                {
                    BehaviourName = "Sacrose",
                    BehaviourType = "Foods and Drinks",
                    BehaviourDescription = "My sacrose intake is high",
                    CategoryId = 4,
                    InPractice = true,
                    Points = 0,
                    value = 0, Frequency=Frequency.OCASSIONALY
                },
                new Behaviour
                {
                    BehaviourName = "Sugar free Gums",
                    BehaviourType = "Food and Drinks",
                    BehaviourDescription = "Chewing gums after meal",
                    CategoryId = 4,
                    InPractice = true,
                    Points = 75,
                    value = 75, Frequency=Frequency.DAILY
                },
                new Behaviour
                {
                    BehaviourName = "Sugar gums",
                    BehaviourType = "Food and Drinks",
                    BehaviourDescription = " My gum contains sugars",
                    CategoryId = 2,
                    InPractice = true,
                    Points = 50,
                    value = 50, Frequency=Frequency.DAILY
                },
                new Behaviour
                {
                    BehaviourName = "Ice chewing",
                    BehaviourType = "Food and Drinks",
                    BehaviourDescription = "I like cold beverages and chewing ice",
                    CategoryId = 2,
                    InPractice = true,
                    Points = 0,
                    value = 0, Frequency=Frequency.OCASSIONALY
                },
                new Behaviour
                {
                    BehaviourName = "Smoking",
                    BehaviourType = "Health",
                    BehaviourDescription = "I smoke regulary",
                    CategoryId = 2,
                    InPractice = true,
                    Points = 0,
                    value = 0, Frequency=Frequency.DAILY
                },
                new Behaviour
                {
                    BehaviourName = "Heavy Drinks ",
                    BehaviourType = "Health",
                    BehaviourDescription = "My drinks are of high alcohol concentration ",
                    CategoryId = 1,
                    InPractice = true,
                    Points = 0,
                    value = 0, Frequency=Frequency.OCASSIONALY
                },
                new Behaviour
                {
                    BehaviourName = "Saline mouth wash",
                    BehaviourType = "Mouth Wash",
                    BehaviourDescription = "I use saline mouth wash",
                    CategoryId = 2,
                    InPractice = true,
                    Points = 75,
                    value = 75, Frequency=Frequency.TWICEADAY
                },
                new Behaviour
                {
                    BehaviourName = "Essential oils mouth wash",
                    BehaviourType = "Mouth wash",
                    BehaviourDescription = "I use EO brands like Listerine ",
                    CategoryId = 2,
                    InPractice = true,
                    Points = 100,
                    value = 100, Frequency=Frequency.TWICEADAY
                },
                new Behaviour
                {
                    BehaviourName = "CPC Mouth wash brand",
                    BehaviourType = "Electric",
                    BehaviourDescription = "I use CPC brads Like Colgate plax, crest pro, oral B rinse",
                    CategoryId = 2,
                    InPractice = true,
                    Points = 100,
                    value = 100, Frequency=Frequency.DAILY
                },
                new Behaviour
                {
                    BehaviourName = "Teeth Cleaning",
                    BehaviourType = "Health",
                    BehaviourDescription = "I occasionally get teeth cleaned by a dentist",
                    CategoryId = 1,
                    InPractice = true,
                    Points = 100,
                    value = 100, Frequency=Frequency.SEMIANNUALY
                },
                new Behaviour
                {
                    BehaviourName = "Doctor visits",
                    BehaviourType = "Health",
                    BehaviourDescription = "I get oral examination by a dentist occasionally",
                    CategoryId = 1,
                    InPractice = true,
                    Points = 100,
                    value = 100, Frequency=Frequency.QUARTELY
                },
                new Behaviour
                {
                    BehaviourName = "Basic teeth and moth cleaning training",
                    BehaviourType = "Mouth Cleaning",
                    BehaviourDescription = "I have been trained on proper dental hyiegiene and I practice one",
                    CategoryId = 3,
                    InPractice = true,
                    Points = 100,
                    value = 100, Frequency=Frequency.OCASSIONALY 
                },
                new Behaviour
                {
                    BehaviourName = "Best oral Hyiegine practices",
                    BehaviourType = "Electric",
                    BehaviourDescription = "I occasionally read or attend workshops on oral health",
                    CategoryId = 3,
                    InPractice = true,
                    Points = 100,
                    value = 100, Frequency=Frequency.OCASSIONALY
                },
                new Behaviour
                {
                    BehaviourName = "Teeth longenvity",
                    BehaviourType = "Longer health teeth",
                    BehaviourDescription = "I understand how to keep my teeth and oral health in check",
                    CategoryId = 3,
                    InPractice = true,
                    Points = 100,
                    value = 100, Frequency=Frequency.OCASSIONALY
                },
                new Behaviour
                {
                    BehaviourName = "Specific ToothPaste",
                    BehaviourType = "Toothpaste",
                    BehaviourDescription = "I brush my teeth with toothpaste and I got advise from dentist",
                    CategoryId = 2,
                    InPractice = true,
                    Points = 100,
                    value = 100, Frequency=Frequency.DAILY
                },
                new Behaviour
                {
                    BehaviourName = "Toothpaste",
                    BehaviourType = "Toothpaste",
                    BehaviourDescription = "My toothpaste is che cheapest I could find",
                    CategoryId = 2,
                    InPractice = true,
                    Points = 50,
                    value = 50, Frequency=Frequency.DAILY
                },
                new Behaviour
                {
                    BehaviourName = "No ToothPaste ",
                    BehaviourType = "Electric",
                    BehaviourDescription = "I dont use toothpaste",
                    CategoryId = 2,
                    InPractice = true,
                    Points = 25,
                    value = 25, Frequency=Frequency.OCASSIONALY
                },
                new Behaviour
                {
                    BehaviourName = "Traditional ToothBrush",
                    BehaviourType = "Traditional",
                    BehaviourDescription = "I dont use industrial toothbrush I have herbs",
                    CategoryId = 2,
                    InPractice = true,
                    Points = 50,
                    value = 50, Frequency=Frequency.DAILY
                },
                new Behaviour
                {
                    BehaviourName = "Gum Disease",
                    BehaviourType = "Diseases",
                    BehaviourDescription = "I have gum diseases",
                    CategoryId = 1,
                    InPractice = true,
                    Points = 0,
                    value = 0, Frequency=Frequency.OCASSIONALY
                },
                new Behaviour
                {
                    BehaviourName = "Mouth Disease",
                    BehaviourType = "Diseases",
                    BehaviourDescription = "I have mouth related diseases (bad breadth etc)",
                    CategoryId = 1,
                    InPractice = true,
                    Points = 0,
                    value = 0, Frequency=Frequency.OCASSIONALY
                },
                new Behaviour
                {
                    BehaviourName = "Sensitivity",
                    BehaviourType = "Diseases",
                    BehaviourDescription = "Severe teeth sensitivity",
                    CategoryId=1,
                    InPractice = true,
                    Points = 0,
                    value = 0, Frequency=Frequency.OCASSIONALY
                },
                new Behaviour
                {
                    BehaviourName = "Extraction",
                    BehaviourType = "Teeth",
                    BehaviourDescription = "I have had extractions",
                    CategoryId = 1,
                    InPractice = true,
                    Points = 20,
                    value = 20, Frequency=Frequency.OCASSIONALY
                }
                );
             context.SaveChanges();
        }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SFCDentalGame.DAL.Entities
{
    public class Category
    {
        public Category()
        {
        }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CategoryId
        {
            get;
            set;
        }
        [Display(Name = "Category Name")]
        public string CategoryName
        {
            get;
            set;
        }
        [Display(Name = "Category Description")]
        public string CategoryDescription
        {
            get;
            set;
        }
        public List<Behaviour> Behaviours {
            get; set;
        }
    }
}

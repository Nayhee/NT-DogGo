using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DogGO.Models
{
    public class Walk
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; } 

        public string TotalWalkTime 
        { 
            get
            {
                var NumMin = Duration / 60;
                if(NumMin > 60)
                {
                    var NumHours = NumMin / 60;
                    var remainMin = NumMin % 60;
                    return $"{NumHours} Hours and {remainMin} Minutes";
                }
                else
                {
                    return $"{NumMin} Minutes";
                }
                }
            }

        public int Duration { get; set; }
        public int WalkerId { get; set; }
        public int DogId { get; set; }

        public Dog Dog { get; set; }
        public Owner Owner { get; set; }
    }
}

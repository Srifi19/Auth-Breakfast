using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace BurberBreakfast.Models
{
    public class Breakfast
    {

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }



        public Breakfast(Guid id,
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            DateTime lastModifiedDateTime
           )
        {
            this.Id = id;
            Name = name;
            Description = description;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            LastModifiedDateTime = lastModifiedDateTime;
        
        }
        public Breakfast() { }
        
  

     
    }
}

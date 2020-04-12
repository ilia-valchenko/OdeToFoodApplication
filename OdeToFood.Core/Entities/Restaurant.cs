using System.ComponentModel.DataAnnotations;
using OdeToFood.Core.Enums;

namespace OdeToFood.Core.Entities
{
    public sealed class Restaurant //: IValidatableObject
    {
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string Name { get; set; }

        [Required, StringLength(255)]
        public string Location { get; set; }

        public Cuisine Cuisine { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
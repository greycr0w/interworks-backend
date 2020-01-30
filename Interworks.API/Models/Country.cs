using System.ComponentModel.DataAnnotations;

namespace Interworks.API.Models {

    public class Country {
        [Key]
        public int id { get; set; }

        public string code { get; set; }

        public string name { get; set; }

        public decimal shippingCost { get; set; }
    }

}
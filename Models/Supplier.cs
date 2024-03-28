using System;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Models
{
	public class Supplier
	{
        public int Id { get; set; }

        [Required(ErrorMessage = "Supplier name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Supplier CNPJ is required.")]
        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$", ErrorMessage = "Invalid CNPJ format.")]
        public string CNPJ { get; set; }

        // Address properties
        [Required(ErrorMessage = "Supplier address is required.")]
        public string Address { get; set; }

        // Phone property
        [Required(ErrorMessage = "Supplier phone is required.")]
        public string Phone { get; set; }

        // Relationship with products
        public List<Product> Products { get; set; }
    }
}


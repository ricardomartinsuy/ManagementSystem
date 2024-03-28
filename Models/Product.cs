﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Models
{
	public class Product
	{
        public int Id { get; set; }

        [Required(ErrorMessage = "Product description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Product brand is required.")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Product unit of measure is required.")]
        public string UnitOfMeasure { get; set; }

        [Required(ErrorMessage = "Product photo is required.")]
        public string Photo { get; set; }

        // Relationship with supplier
        public int SupplierId { get; set; }
        public required Supplier Supplier { get; set; }
    }
}


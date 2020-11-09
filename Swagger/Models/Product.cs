using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Swagger.Models
{
    public partial class Product
    {
        
        /// <summary>
        /// Urun ID-si
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// urun ismi required data
        /// </summary>
        [Required]
        
        public string Name { get; set; }

        /// <summary>
        /// urun fiyati required data
        /// </summary>
        [Required]
        public decimal? Price { get; set; }
        /// <summary>
        /// urun kategorisi required data
        /// </summary>
        [Required]
        public long? Category { get; set; }
    }
}

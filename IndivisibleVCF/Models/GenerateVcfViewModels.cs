using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IndivisibleVCF.Models
{
    public class GenerateVcfButtonResultViewModel
    {
        [Required]
        [DataType(DataType.PostalCode)]
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }
    }
}
﻿namespace StructuralDesign.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using StructuralDesign.Data.Common.Models;

    public class MaterialConcrete : BaseDeletableModel<int>
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public double VolumeWeight { get; set; }

        [Required]
        public double DesignCompressiveStrength { get; set; }

        [Required]
        public double DesignTensionStrength { get; set; }

        [Required]
        public double ModulusOfElasticity { get; set; }
    }
}

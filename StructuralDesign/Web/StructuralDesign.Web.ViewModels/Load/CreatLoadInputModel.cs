﻿namespace StructuralDesign.Web.ViewModels.Load
{
    using System.ComponentModel.DataAnnotations;

    public class CreatLoadInputModel
    {
        [Required]
        public LoadType Type { get; set; }

        public double? AxialForce { get; set; }

        public double? ShearForceY { get; set; }

        public double? ShearForceZ { get; set; }

        public double? BendingMomentY { get; set; }

        public double? BendingMomentZ { get; set; }

    }
}
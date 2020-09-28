﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LsmSearchApp.Models
{
    // Weights of building Attributes
    public enum BuildingWeight
    {
        // Weight of Own Attributes
        ShortCutWeight = 7,
        NameWeight = 9,
        DescriptionWeight = 5,
        // Weight of Transitive Attributes
        ShortCutWeightT = 5,
        NameWeightT = 8,
        DescriptionWeightT = 0,
    }

    // this class represents the building entity of the Data
    public class Building : Entity
    {

        // Attributes of Building
        public string ShortCut { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Locks { get; set; }
        public int WeightT { get; set; }
        public Building()
        {
            Locks = new List<string>();
            WeightT = 0;
        }


        // Calculate the weight of Building record based on searchText, return WeightT for child entities
        public void CalculateEntityWeight(string searchText)
        {
        }
    }
}

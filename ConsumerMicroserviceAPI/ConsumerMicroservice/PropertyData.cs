using ConsumerMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumerMicroservice
{
    public class PropertyData
    {
        public static List<Property> PropertyList = new List<Property>()

        {
           new Property()
            {

                PropertyId = "P01",
                BuildingSqft = 2000,
                BuildingType = "Owner",
                BuildingStoreys = 5,
                BuildingAge = 2,
                CostOfTheAsset =9,
                SalvageValue =3,
                UsefulLifeOfTheAsset =3
           },
           new Property()
            {

                PropertyId = "P02",
                BuildingSqft = 3000,
                BuildingType = "Rent",
                BuildingStoreys = 2,
                BuildingAge = 5,
                CostOfTheAsset =8,
                SalvageValue =2,
                UsefulLifeOfTheAsset =4
           },
           new Property()
            {

                PropertyId = "P03",
                BuildingSqft = 5000,
                BuildingType = "Lease",
                BuildingStoreys = 6,
                BuildingAge = 3,
                CostOfTheAsset =7,
                SalvageValue =4,
                UsefulLifeOfTheAsset =2
           },
           new Property()
            {

                PropertyId = "P04",
                BuildingSqft = 2500,
                BuildingType = "Contract",
                BuildingStoreys = 3,
                BuildingAge = 1,
                CostOfTheAsset =8,
                SalvageValue =2,
                UsefulLifeOfTheAsset =2
           },
           new Property()
            {

                PropertyId = "P05",
                BuildingSqft = 1000,
                BuildingType = "Goverment",
                BuildingStoreys = 2,
                BuildingAge = 5,
                CostOfTheAsset =6,
                SalvageValue =5,
                UsefulLifeOfTheAsset =5
           }

        };
    }
}

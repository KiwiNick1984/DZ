using System;

namespace RepkaStory
{
    internal class Ded : Personage
    {
        public Ded(int personagePower = 10) : base(personagePower)
        {
            Console.WriteLine("Дет пришел на огород!");
        }
        public Plant Plant(PlantsType plantsType, int plantPower = 10)
        {
            switch (plantsType)
            {
                case PlantsType.Repka:
                    Console.WriteLine("Дет посадил репку!");
                    return new Repka(plantPower);
                case PlantsType.Beet:
                    Console.WriteLine("Дет посадил свеклу!");
                    return new Beet(plantPower);
                default:
                    Console.WriteLine("У деда нет таких семян!");
                    return null;
            }
        }
        public override bool Pull(Plant plant, int personagePower)
        {
            Console.WriteLine("Дед тянет!");
            return plant.Pull(personagePower);
        }
    }
    enum PlantsType 
    {
        Repka,
        Beet
    }
}

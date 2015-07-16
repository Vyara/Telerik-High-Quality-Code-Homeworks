namespace Cooking
{
    using System;
    using Culinary;
    using Culinary.Ingredients.Vegetables;

    public class CookVegetables
    {
        public static void Main()
        {
            Chef chef = new Chef();
            Potato potato = new Potato();
            if (potato == null)
            {
                throw new ArgumentNullException("Potato should be created.");
            }
            else if (potato.IsPeeled && potato.IsRotten)
            { 
                    chef.Cook(potato);
            }
        }
    }
}

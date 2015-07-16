namespace Culinary
{
    using Culinary.Ingredients.Vegetables;

    public class Cook
    {
        public static void Main()
        {
            var chef = new Chef();
            var carrot = new Carrot();

            chef.Cook(carrot);
        }
    }
}

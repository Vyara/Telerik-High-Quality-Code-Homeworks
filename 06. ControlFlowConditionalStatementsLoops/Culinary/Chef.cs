namespace Culinary
{
    using Culinary.Cookware;
    using Culinary.Ingredients;
    using Culinary.Ingredients.Vegetables;

    public class Chef
    {
        public void Cook(Vegetable vegetable)
        {
            Potato potato = this.GetPotato();
            Carrot carrot = this.GetCarrot();

            this.Peel(potato);
            this.Peel(carrot);

            this.Cut(potato);
            this.Cut(carrot);

            Bowl bowl = this.GetBowl();
            bowl.Add(carrot);
            bowl.Add(potato);
        }

        private Potato GetPotato()
        {
            return new Potato();
        }

        private Carrot GetCarrot()
        {
            return new Carrot();
        }

        private Bowl GetBowl()
        {
            return new Bowl();
        }

        private void Peel(Vegetable vegetable)
        {
        }

        private void Cut(Vegetable vegetable)
        {
        }
    }
}

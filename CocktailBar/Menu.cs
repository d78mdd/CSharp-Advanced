using System.Text;

namespace CocktailBar
{
    public class Menu
    {
        public List<Cocktail> Cocktails { get; set; }

        public int BarCapacity { get; set; }

        public Menu(int barCapacity)
        {
            BarCapacity = barCapacity;
            Cocktails = new List<Cocktail>();
        }


        public void AddCocktail(Cocktail cocktail)
        {
            if (Cocktails.Count < BarCapacity && !Cocktails.Any(c => c.Name == cocktail.Name))
            {
                Cocktails.Add(cocktail);
            }
        }

        public bool RemoveCocktail(string name)
        {
            return Cocktails.Remove(
                Cocktails.Find(c => c.Name == name));
        }

        public Cocktail GetMostDiverse()
        {
            return Cocktails.OrderBy(c => c.Ingredients.Count).Last();
            // There will always be exactly one cocktail, that will have the greatest count of ingredients
        }

        public string Details(string cocktailName)
        {
            return Cocktails.Find(c => c.Name == cocktailName).ToString();
            // There will also be a cocktail with the given name added, before calling Details method.
        }

        public string GetAll()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("All Cocktails:");
            foreach (Cocktail cocktail in Cocktails
                         .OrderBy(c => c.Name))
            {
                sb.AppendLine(cocktail.Name);
            }

            return sb.ToString().Trim();
        }
        // You will always have drinks added before receiving methods, manipulating the drinks in the Menu.
    }
}

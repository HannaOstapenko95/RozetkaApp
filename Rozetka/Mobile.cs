namespace Rozetka
{
    public class Mobile: Product
    {
        public Mobile()
        {

        }
        public Mobile(string name, double price, int rating, string reviews, string descriptionlink)
        {
            Name = name;
            Price = price;
            Rating = rating;
            Reviews = reviews;
            DescriptionUrl = descriptionlink;
        }
    }
}

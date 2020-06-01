namespace Rozetka
{
    public class Mobile: Product
    {
        public Mobile()
        {

        }
        public Mobile(string name, int price, int popularity, string numberOfReviews, string productlink)
        {
            Name = name;
            Price = price;
            Popularity = popularity;
            NumberOfReviews = numberOfReviews;
            ProductLink = productlink;
        }
    }
}

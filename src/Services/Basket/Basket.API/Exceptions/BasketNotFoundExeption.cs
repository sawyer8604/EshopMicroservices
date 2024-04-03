
namespace Basket.API.Exceptions
{
    public class BasketNotFoundExeption : NotFoundException
    {
        public BasketNotFoundExeption(string userName) : base("Basket", userName)
        {
            
        }
    }
}

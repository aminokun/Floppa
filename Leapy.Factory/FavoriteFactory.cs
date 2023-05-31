using Leapy.Interfaces;
using Leapy.Data.Repositories;

namespace Leapy.Factory
{
    public class FavoriteFactory
    {
        public IFavorite UseFavoriteDAL(string dataType)
        {
            switch (dataType)
            {
                case "Favorite":
                    return new FavoriteDataAccess();
                default:
                    throw new Exception("Invalid data type");
            }
        }
    }
}

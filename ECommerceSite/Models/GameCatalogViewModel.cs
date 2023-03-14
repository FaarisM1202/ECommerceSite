using Microsoft.Identity.Client;

namespace ECommerceSite.Models
{
    public class GameCatalogViewModel
    {
        public GameCatalogViewModel(List<Game> games, int lastPage, int currentPage)
        {
            Games = games;
            LastPage = lastPage;
            CurrentPage = currentPage;
        }

        public List<Game> Games { get; private set; }

        /// <summary>
        /// The Last Page of the Catalog calculated by
        /// having a total number of products divided by
        /// products per page.
        /// </summary>
        public int LastPage { get; private set; }

        /// <summary>
        /// The current page the user is viewing.
        /// </summary>
        public int CurrentPage { get; private set; }
    }
}

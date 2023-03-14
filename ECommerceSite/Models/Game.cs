using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace ECommerceSite.Models
{
    /// <summary>
    /// Represents a single game available for the purchase
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Unique identifier for each product
        /// </summary>
        [Key]
        public int GameId { get; set; }
        /// <summary>
        /// The title of the games
        /// </summary>
        [Required] 
        public string Title { get; set; }
        /// <summary>
        /// The price for the buyer
        /// </summary>
        [Range(0, 1000)]     
        public double Price { get; set; }
    }

    /// <summary>
    /// A single video game that has been added to the users
    /// shopping cart cookie.
    /// </summary>
    public class CartGameViewModel
    {
        public int GameId { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }
    }
}

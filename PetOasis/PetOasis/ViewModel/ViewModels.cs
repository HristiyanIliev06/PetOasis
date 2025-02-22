using Microsoft.AspNetCore.Identity.UI.V5.Pages.Account.Manage.Internal;
using PetOasis.Data.Entities;

namespace PetOasis.ViewModel
{
    public class ViewModels
    {
        public IEnumerable<PetHotel>? PetHotels { get; set; }
        public IEnumerable<PawPost>? PawPosts { get; set; }

        public IndexModel? IndexModel { get; set; }
    }
}

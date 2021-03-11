using System;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace CollectionViewSample.ViewModels
{
    public class UserDTO : ReactiveObject
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        [Reactive] public string ProfilePhotoUrl { get; set; }
        [Reactive] public int ListingsCount { get; set; }
        [Reactive] public int ReviewsCount { get; set; }
        [Reactive] public double? AverageRating { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
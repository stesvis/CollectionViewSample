using System;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace CollectionViewSample.ViewModels
{
    public class CategoryDTO : ReactiveObject
    {
        [Reactive] public int Id { get; set; }

        [Reactive] public DateTime CreatedAt { get; set; }
        public UserDTO CreatedBy { get; set; }

        public string Status { get; set; }
        [Reactive] public DateTime UpdatedAt { get; set; }

        [Reactive] public UserDTO UpdatedBy { get; set; }

        [Reactive] public string Name { get; set; }

        public int? ParentId { get; set; }

        public int? Order { get; set; }
    }
}
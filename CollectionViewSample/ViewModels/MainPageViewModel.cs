using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DynamicData;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ReactiveUI.Fody.Helpers;

namespace CollectionViewSample.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        [Reactive] public ObservableCollection<object> Items { get; set; }

        private DelegateCommand loadItemsCommand;
        public DelegateCommand LoadItemsCommand =>
            loadItemsCommand ?? (loadItemsCommand = new DelegateCommand(ExecuteLoadItemsCommand));

        private void ExecuteLoadItemsCommand()
        {
            Reload();
        }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
        }

        private void Reload()
        {
            Items = new ObservableCollection<object>
            {
                "Item 1",
                "Item 2",
                "Item 3",
                "Item 4",
                "Item 5",
                "Item 6",
                "Item 7",
                "Item 8",
                "Item 9",
                "Item 10",
            };
        }
    }
}
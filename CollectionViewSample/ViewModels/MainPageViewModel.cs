using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ReactiveUI.Fody.Helpers;

namespace CollectionViewSample.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private static HttpClient client = new HttpClient();
        [Reactive] public ObservableCollection<CategoryDTO> Categories { get; set; }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            Categories = new ObservableCollection<CategoryDTO>();
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            HttpResponseMessage response = await client.GetAsync("https://api.yourent.app/api/categories");
            if (response.IsSuccessStatusCode)
            {
                var serializerOptions = new JsonSerializerOptions()
                {
                    MaxDepth = 0,
                    IgnoreNullValues = true,
                    IgnoreReadOnlyProperties = true,
                    PropertyNameCaseInsensitive = true,
                    IgnoreReadOnlyFields = true,
                    IncludeFields = false,
                };

                var categoriesJson = await response.Content.ReadAsStringAsync();
                var categorieDTOs = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<CategoryDTO>>(categoriesJson, serializerOptions);
                Categories = new ObservableCollection<CategoryDTO>(categorieDTOs);
            }
        }
    }
}
using HospitalDashboard.Client.Models;
using HospitalDashboard.Client.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Linq;


using System;
using System.Threading.Tasks;





namespace HospitalDashboard.Client.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Resource> Resources { get; set; } = new();
        public string NewResourceName { get; set; }
        public string NewResourceType { get; set; } = "Bed";
        public string NewResourceStatus { get; set; } = "Available";

        private readonly ApiService _api = new();
        private readonly SignalRService _signalR = new();

        public ICommand AddCommand { get; }
        public ICommand RefreshCommand { get; }

        public MainViewModel()
        {
            AddCommand = new RelayCommand(async (_) => await AddResource());
            RefreshCommand = new RelayCommand(async (_) => await LoadResources());

            _ = InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            await LoadResources();
            await _signalR.Connect();
            _signalR.OnUpdateReceived += async (_) => await LoadResources();
        }

        private async Task LoadResources()
        {
            var list = await _api.GetAllResources();
            Resources.Clear();
            foreach (var item in list)
                Resources.Add(item);
        }

        private async Task AddResource()
        {
            var newRes = new Resource
            {
                Name = NewResourceName,
                Type = NewResourceType?.ToString().Split(": ").Last(),
Status = NewResourceStatus?.ToString().Split(": ").Last()

            };
            await _api.AddResource(newRes);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

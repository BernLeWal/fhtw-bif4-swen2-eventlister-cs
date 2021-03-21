using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EventListerInCSharp.FilterHandling;

namespace EventListerInCSharp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ICommunicationHandler _com;
        private readonly IContentInterpreter _interpreter;
        private readonly IFilterHandler _filter;
        
        public string FilterText { get; set; }

        private RelayCommand _filterCommand = null;
        public RelayCommand FilterCommand
            => _filterCommand ?? (_filterCommand = new RelayCommand(FilterAction));

        private List<string> _filteredData = new List<string>();
        public List<string> FilteredData
        {
            get => _filteredData;
            set
            {
                if (_filteredData != value)
                {
                    _filteredData = value;
                    OnPropertyChanged();
                }
            }
        }

        private async void FilterAction()
        {
            var data = await _com.GetContentAsync();
            var interpretedData = _interpreter.Interpret(data);
            var filteredData = _filter.Filter(interpretedData, FilterText);
            this.FilteredData = filteredData.ToList();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainViewModel(IArgumentHandler argumentHandler, ICommunicationHandler com, IContentInterpreter interpreter, IFilterHandler filter)
        {
            _com = com;
            _interpreter = interpreter;
            _filter = filter;

            FilterText = string.Join(", ", argumentHandler.FilterCriterias);
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

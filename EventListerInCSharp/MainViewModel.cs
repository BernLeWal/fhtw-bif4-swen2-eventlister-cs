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
        /// <summary>
        /// These are our dependencies
        /// </summary>
        private readonly IArgumentHandler _argumentHandler;
        private readonly ICommunicationHandler _com;
        private readonly IContentInterpreter _interpreter;
        private readonly IFilterHandler _filter;
        
        public string FilterText { get; set; }

        private RelayCommand _filterCommand = null;
        /// <summary>
        /// Build a command which uses calls FilterAction() in its Execute() method
        /// </summary>
        public RelayCommand FilterCommand => _filterCommand ??= new RelayCommand(FilterAction);

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
            // fetch the content
            var data = await _com.GetContentAsync();
            
            // process it
            var interpretedData = _interpreter.Interpret(data);
            
            // apply the filter criteria defined in the filter text
            var filteredData = _filter.Filter(interpretedData, FilterText);
            
            // update the list
            this.FilteredData = filteredData.ToList();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// In our case, the MainViewModel is instantiated via the service provider in MainWindow.xaml, line 9 via the
        /// IoCContainerConfig resource (see also App.xaml and IoCContainerConfig.cs). The service provider is
        /// configured to provide the constructor parameters.
        /// </summary>
        /// <param name="argumentHandler">The argument handler, which (with our current IoC config) parses commandline arguments.</param>
        /// <param name="com">The communication handler, which fetches the content from a remote server.</param>
        /// <param name="interpreter">The interpreter for processing the fetched content.</param>
        /// <param name="filter">With our current IoC config, filters a list of strings according to a comma-separated list of filter criteria and returns a new list.</param>
        public MainViewModel(IArgumentHandler argumentHandler, ICommunicationHandler com, IContentInterpreter interpreter, IFilterHandler filter)
        {
            // keep the dependencies
            _argumentHandler = argumentHandler;
            _com = com;
            _interpreter = interpreter;
            _filter = filter;

            // pre-fill the filter text with filter criteria provided via the command line
            // this assumes a CsvBasedFilter!
            FilterText = string.Join(", ", argumentHandler.FilterCriterias);
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

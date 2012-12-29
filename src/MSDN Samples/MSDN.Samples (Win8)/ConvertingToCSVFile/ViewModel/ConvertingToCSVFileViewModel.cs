using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace MSDN.Samples.ConvertingToCSVFile.ViewModel
{
    using GalaSoft.MvvmLight;
    using Model;
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class ConvertingToCSVFileViewModel: ViewModelBase
    {
        private Random _random;

        public ConvertingToCSVFileViewModel()
        {
            Init();
            ExportCommand = new RelayCommand(ExportToCSVFile);
        }

        private void ExportToCSVFile()
        {
            var csv = new CsvExport<BoardItem>(DashBoardItems.ToList());
            csv.ExportToFile("myexportresult.csv");
        }

        private void Init()
        {
            _random = new Random();
            DashBoardItems = new ObservableCollection<BoardItem>
                {
                    new BoardItem
                        {
                            Name = "Blue",
                            Value = 1, 
                            Count = _random.Next(20,50)
                        },
                    new BoardItem
                        {
                            Name = "Pink", 
                            Value = 2, 
                            Count = _random.Next(20,100)
                        },
                    new BoardItem
                        {
                            Name = "Yellow", 
                            Value = 3,
                            Count =  _random.Next(20,100)
                        }
                };
        }
   
        public ObservableCollection<BoardItem> DashBoardItems { get; set; }
        public ICommand ExportCommand { get; set; }
    }

}

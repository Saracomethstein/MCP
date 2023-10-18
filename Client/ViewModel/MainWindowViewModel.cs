using Client.Model;
using Client.Views;
using Gma.System.MouseKeyHook;
using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace Client.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public int nextCounter = 1;
        private IKeyboardMouseEvents _mEvents;
        private RelayCommand _satartCommand;
        private RelayCommand _closeAppCommand;
        private RelayCommand _minimizedCommand;
        private RelayCommand _clearDataGridCommand;
        private RelayCommand _choseUserCommand;
        private string _xCor;
        private string _yCor;
        private string _startStopButton;
        private ObservableCollection<TableInfo> _tableInfnos;

        public MainWindowViewModel()
        {
            StartStopButton = "Start";
            XCor = "0000";
            YCor = "0000";
        }

        #region Properties
        public string XCor
        {
            get { return _xCor; }

            set
            {
                _xCor = value;
                NotifyPropertyChanged(nameof(XCor));
            }
        }

        public string YCor
        {
            get { return _yCor; }

            set
            {
                _yCor = value;
                NotifyPropertyChanged(nameof(YCor));
            }
        }

        public string StartStopButton
        {
            get { return _startStopButton; }

            set
            {
                _startStopButton = value;
                NotifyPropertyChanged(nameof(StartStopButton));
            }
        }

        public ObservableCollection<TableInfo> TableInfos
        {
            get
            {
                return _tableInfnos ?? (_tableInfnos = new ObservableCollection<TableInfo>());
            }

            set
            {
                _tableInfnos = value;
                NotifyPropertyChanged(nameof(TableInfos));
            }
        }
        #endregion

        #region Mouse Coordinates

        private void Subscribe(IKeyboardMouseEvents events)
        {
            _mEvents = events;
            _mEvents.MouseMove += EventMouseMove;
            _mEvents.MouseDownExt += EventMouseDownExt;
        }

        private void Unsubcribe()
        {
            if (_mEvents == null) return;
            _mEvents.MouseMove -= EventMouseMove;
            _mEvents.MouseDownExt -= EventMouseDownExt;
            _mEvents.Dispose();
            _mEvents = null;
        }

        private void EventMouseMove(object sender, MouseEventArgs e)
        {
            XCor = $"{e.X}";
            YCor = $"{e.Y}";

            if (e.X % 10 == 0 | e.Y % 10 == 0)
            {
                TableInfo info = new TableInfo
                {
                    Counter = nextCounter++,
                    Date = DateTime.Now,
                    Event = $"Mouse point shift",
                    Coordinates = "X: " + e.X + " Y: " + e.Y
                };
                TableInfos.Add(info);
                Service.SaveToDatabase(info.Counter, info.Event, info.Coordinates, info.Date);
            }
        }

        private void EventMouseDownExt(object sender, MouseEventExtArgs e)
        {
            TableInfo info = new TableInfo
            {
                Counter = nextCounter++,
                Date = DateTime.Now,
                Event = $"MouseDown: {e.Button}",
                Coordinates = "X: " + e.X + " Y: " + e.Y
            };
            TableInfos.Add(info);
            Service.SaveToDatabase(info.Counter, info.Event, info.Coordinates, info.Date);
        }

        #endregion

        #region Command

        public RelayCommand GetSatartCommand
            => _satartCommand ?? (_satartCommand = new RelayCommand(() =>
            {
                StartOrStop();
            }));

        public RelayCommand GetCloseAppCommand
            => _closeAppCommand ?? (_closeAppCommand = new RelayCommand(() =>
            {
                GeneralCommands.CloseApp();
            }));

        public RelayCommand GetMinimizedCommand
            => _minimizedCommand ?? (_minimizedCommand = new RelayCommand(() =>
            {
                GeneralCommands.MiniApp();
            }));

        public RelayCommand GetClearDataGridCommand
            => _clearDataGridCommand ?? (_clearDataGridCommand = new RelayCommand(() =>
            {
                ClearDataBase();
            }));

        public RelayCommand GetChoseUserCommand
            => _choseUserCommand ?? (_choseUserCommand = new RelayCommand(() =>
            {
                GetChoseUser();
            }));

        #endregion

        private void StartOrStop()
        {
            switch (StartStopButton)
            {
                case "Start":
                    StartStopButton = "Stop";
                    Subscribe(Hook.GlobalEvents());
                    Service.Message("Database recording has started.");
                    break;

                case "Stop":
                    StartStopButton = "Start";
                    XCor = "0000";
                    YCor = "0000";
                    Unsubcribe();
                    Service.Message("Writing to the database has ended.");
                    break;

                default:
                    System.Windows.MessageBox.Show("Error!");
                    break;
            }
        }

        private void ClearDataBase()
        {
            nextCounter = 1;
            TableInfos.Clear();
            Service.DeleteEvents();
            Service.Message("The `events` table data has been deleted.");
        }

        private void GetChoseUser()
        {
            var login = new LoginWindowView();
            var window = System.Windows.Application.Current.Windows[0];

            if (window != null)
            {
                login.Show();
                window.Close();
                Service.Message("The user has logged out.");
            }
        }
    }
}

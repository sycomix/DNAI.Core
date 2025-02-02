﻿using CorePluginLego.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;

namespace CorePluginLego.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly IConnection _connection;

        private BrickControllerNxt _controller;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _connection = new ConnectionBluetoothNxt();

            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }
                });
        }

        public override void Cleanup()
        {
            // Clean up if needed
            base.Cleanup();
            _controller?.Dispose();
        }

        private RelayCommand _connectCommand;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public RelayCommand ConnectCommand
        {
            get
            {
                return _connectCommand
                    ?? (_connectCommand = new RelayCommand(
                    async () =>
                    {
                        if (_controller?.IsConnected != true)
                        {
                            Status = "Connecting...";
                            //_controller = new BrickController(new ConnectionBluetooth("COM5"));
                            _controller = new BrickControllerNxt(new ConnectionBluetoothNxt(Convert.ToByte(ComPort)));
                            System.Threading.Thread.Sleep(100);
                            await _controller.ConnectAsync();
                            _controller.OnDistanceChanged += (object a, EventArgs b) => Distance = _controller.Distance.ToString();
                            Status = "Disconnect";
                        }
                        else
                        {
                            _controller.Dispose();
                            Status = "Connect";
                        }
                    }));
            }
        }

        private void Brick_BrickChanged(object sender, Lego.Ev3.Core.BrickChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private RelayCommand<int> _moveCommand;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public RelayCommand<int> MoveCommand
        {
            get
            {
                return _moveCommand
                    ?? (_moveCommand = new RelayCommand<int>(
                    (dir) =>
                    {
                        AutoPilot = false;
                        _controller.SendCommand((brick) =>
                        {
                            //brick.DirectCommand.TurnMotorAtPowerForTimeAsync(Lego.Ev3.Core.OutputPort.A | Lego.Ev3.Core.OutputPort.B, Velocity * dir, 100, false);
                            brick.MotorB.Run((sbyte)(Velocity * dir), 360);
                            brick.MotorC.Run((sbyte)(Velocity * dir), 360);
                        });
                    }, (dir) => _controller?.IsConnected == true));
            }
        }

        private RelayCommand<int> _turnCommand;

        /// <summary>
        /// Gets the TurnCommand.
        /// </summary>
        public RelayCommand<int> TurnCommand
        {
            get
            {
                return _turnCommand
                    ?? (_turnCommand = new RelayCommand<int>(
                    (dir) =>
                    {
                        AutoPilot = false;
                        _controller.SendCommand((brick) =>
                        {
                            //brick.BatchCommand.TurnMotorAtPowerForTime(Lego.Ev3.Core.OutputPort.A | Lego.Ev3.Core.OutputPort.B, Velocity * dir, 100, false);
                            brick.MotorB.Run((sbyte)(Velocity * -dir), 360);
                            //brick.BatchCommand.TurnMotorAtPowerForTime(Lego.Ev3.Core.OutputPort.A | Lego.Ev3.Core.OutputPort.B, Velocity * -dir, 100, false);
                            brick.MotorC.Run((sbyte)(Velocity * dir), 360);
                        });
                    },
                    (dir) => _controller?.IsConnected == true));
            }
        }

        private RelayCommand _pickFileCommand;

        /// <summary>
        /// Gets the PickFileCommand.
        /// </summary>
        public RelayCommand PickFileCommand
        {
            get
            {
                return _pickFileCommand
                    ?? (_pickFileCommand = new RelayCommand(
                    () =>
                    {
                        var dialog = new System.Windows.Forms.OpenFileDialog();
                        switch (dialog.ShowDialog())
                        {
                            case System.Windows.Forms.DialogResult.OK:
                                Path = dialog.FileName;
                                break;

                            case System.Windows.Forms.DialogResult.Cancel:
                                break;

                            default:
                                break;
                        }
                    }));
            }
        }

        private string _status = "Connect";

        /// <summary>
        /// Sets and gets the Status property.
        /// Changes to that property's value raise the PropertyChanged event.
        /// </summary>
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                Set(ref _status, value);
            }
        }

        private bool _autoPilot;

        public bool AutoPilot
        {
            get => _autoPilot;
            set
            {
                Set(ref _autoPilot, value);
                if (value)
                    _controller.StartAutoPilot(Path);
                else
                    _controller.StopAutopilot();
            }
        }

        private string _comPort = "8";

        public string ComPort
        { get => _comPort; set => Set(ref _comPort, value); }

        private int _velocity = 40;

        public int Velocity
        {
            get => _velocity;
            set
            {
                if (Set(ref _velocity, value) && _controller != null)
                    _controller.Velocity = value;
            }
        }

        private string _path;

        public string Path
        { get => _path; set => Set(ref _path, value); }

        private float _minDistance = 20f;

        public float MinDistance
        {
            get => _minDistance;
            set
            {
                if (Set(ref _minDistance, value) && _controller != null)
                    _controller.MinDistance = value;
            }
        }

        private string _distance;

        public string Distance
        {
            get => _distance;

            set
            {
                Set(ref _distance, value);
            }
        }
    }
}
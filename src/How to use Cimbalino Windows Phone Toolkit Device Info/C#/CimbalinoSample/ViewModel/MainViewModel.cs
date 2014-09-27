using GalaSoft.MvvmLight;

namespace CimbalinoSample.ViewModel
{
    using System;

    using Cimbalino.Phone.Toolkit.Services;

    using Microsoft.Phone.Info;

    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// The device extended properties service
        /// </summary>
        private readonly IDeviceExtendedPropertiesService _deviceExtendedPropertiesService;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDeviceExtendedPropertiesService deviceExtendedPropertiesService)
        {
            _deviceExtendedPropertiesService = deviceExtendedPropertiesService;
        }

        /// <summary>
        /// Gets the device unique identifier.
        /// </summary>
        /// <value>
        /// The device unique identifier.
        /// </value>
        public string DeviceUniqueID
        {
            get
            {
                return Convert.ToBase64String(_deviceExtendedPropertiesService.DeviceUniqueId);
            }
        }

        /// <summary>
        /// Gets the application current memory usage.
        /// </summary>
        /// <value>
        /// The application current memory usage.
        /// </value>
        public long ApplicationCurrentMemoryUsage
        {
            get
            {
                return _deviceExtendedPropertiesService.GetDeviceProperty<long>("ApplicationCurrentMemoryUsage");
            }
        }


        /// <summary>
        /// Gets the application peak memory usage.
        /// </summary>
        /// <value>
        /// The application peak memory usage.
        /// </value>
        public long ApplicationPeakMemoryUsage
        {
            get
            {
                return _deviceExtendedPropertiesService.GetDeviceProperty<long>("ApplicationPeakMemoryUsage");
            }
        }

        /// <summary>
        /// Gets the device firmware version.
        /// </summary>
        /// <value>
        /// The device firmware version.
        /// </value>
        public string DeviceFirmwareVersion
        {
            get
            {
                return _deviceExtendedPropertiesService.GetDeviceProperty<string>("DeviceFirmwareVersion");
            }
        }


        /// <summary>
        /// Gets the device hardware version.
        /// </summary>
        /// <value>
        /// The device hardware version.
        /// </value>
        public string DeviceHardwareVersion
        {
            get
            {
                return _deviceExtendedPropertiesService.GetDeviceProperty<string>("DeviceHardwareVersion");
            }
        }

        /// <summary>
        /// Gets the device manufacturer.
        /// </summary>
        /// <value>
        /// The device manufacturer.
        /// </value>
        public string DeviceManufacturer
        {
            get
            {
                return _deviceExtendedPropertiesService.GetDeviceProperty<string>("DeviceManufacturer");
            }
        }

        /// <summary>
        /// Gets the name of the device.
        /// </summary>
        /// <value>
        /// The name of the device.
        /// </value>
        public string DeviceName
        {
            get
            {
                return _deviceExtendedPropertiesService.GetDeviceProperty<string>("DeviceName");
            }
        }

        /// <summary>
        /// Gets the device total memory.
        /// </summary>
        /// <value>
        /// The device total memory.
        /// </value>
        public long DeviceTotalMemory
        {
            get
            {
                return _deviceExtendedPropertiesService.GetDeviceProperty<long>("DeviceTotalMemory");
            }
        }

        /// <summary>
        /// Gets the name of the original mobile operator.
        /// </summary>
        /// <value>
        /// The name of the original mobile operator.
        /// </value>
        public string OriginalMobileOperatorName
        {
            get
            {
                return _deviceExtendedPropertiesService.GetDeviceProperty<string>("OriginalMobileOperatorName");
            }
        }
    }
}
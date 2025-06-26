using AplicacionApuntes2.Models;
using AplicacionApuntes2.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionApuntes2.ViewModels
{
    internal class WeatherViewModel : INotifyPropertyChanged
    {
        private WeatherData _weatherData = new WeatherData();

        public WeatherData WeatherDataInfo
        {
            get => _weatherData;
            set
            {
                if (_weatherData != value)
                {
                    _weatherData = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(HoraFormateada));
                }
            }
        }

        public WeatherViewModel()
        {
            GetCurrentWeatherData();
        }

        public async void GetCurrentWeatherData()
        {
            WeatherRepository weatherRepository = new WeatherRepository();
            WeatherDataInfo = await weatherRepository.GetCurrentLocationWeatherData();
        }
        public string HoraFormateada
        {
            get
            {
                if (DateTime.TryParse(WeatherDataInfo?.current?.time, out DateTime hora))
                {
                    return hora.ToString("dd/MM/yyyy HH:mm");
                }
                return "--:--";
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

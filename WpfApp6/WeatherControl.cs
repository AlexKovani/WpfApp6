using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp6
{
    enum atmospheric_phenomena
    {
        sunny,
        clougy,
        snow,
        rain,
        storm
    }
    class WeatherControl : DependencyObject
    {
        private string wind_direction;
        private int wind_speed;
        private atmospheric_phenomena atmos;
        public string WindDirection { get; set; }
        public int WindSpeed { get; set; }

        public WeatherControl(string winddir, int windspeed, atmospheric_phenomena atmos)
        {
            this.WindDirection = winddir;
            this.WindSpeed = windspeed;
            this.atmos = atmos;
        }

        public static readonly DependencyProperty TempProperty;

        public int Temp
        {
            get => (int)GetValue(TempProperty);
            set => SetValue(TempProperty, value);
        }

        static WeatherControl()
        {
            TempProperty = DependencyProperty.Register(
                nameof(Temp),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsRender |
                    FrameworkPropertyMetadataOptions.Journal,
                    null,
                    new CoerceValueCallback(CoerceTemp)),
                    new ValidateValueCallback(ValidateTemp));

        }

        private static bool ValidateTemp(object value)
        {
            int v = (int)value;
            if (v >=-50 && v <= 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static object CoerceTemp(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v >= -50 && v <= 50)
            {
                return v;
            }
            else
            {
                return null ;
            }
        }


    }
}

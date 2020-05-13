using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_lab_4_17_3
{
    class Weather
    {
        private DateTime _date;
        private string _city;
        private int _pressure;
        private int _temperature;
        private int _windSpeed;

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        public int Perssure
        {
            get { return _pressure; }
            set { _pressure = value; }
        }
        public int Temperature
        {
            get { return _temperature; }
            set { _temperature = value; }
        }
        public int WindSpeed
        {
            get { return _windSpeed; }
            set { _windSpeed = value; }
        }

        public Weather()
        {
            _date = DateTime.Parse("01.01.0001");
            _city = "Не вказано";
            _pressure = 0;
            _temperature = 0;
            _windSpeed = 0;
        }

        public Weather(DateTime Date, string City, int Pressure, int Temerature, int WindSpeed)
        {
            _date = Date;
            _city = City;
            _pressure = Pressure;
            _temperature = Temerature;
            _windSpeed = WindSpeed;
        }

    }
}

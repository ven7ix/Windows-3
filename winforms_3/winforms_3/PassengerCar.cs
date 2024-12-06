using System;

namespace winforms_3
{
    [Serializable]
    public class PassengerCar : ICar
    {
        public string m_brand { get; set; }
        public string m_model { get; set; }
        public int m_power { get; set; }
        public int m_maxSpeed { get; set; }
        public string m_type { get; set; }
        public string m_licencePlate { get; set; }
        public string m_multimedia { get; set; }
        public int m_airbags { get; set; }

        public PassengerCar(string brand, string model, int power, int maxSpeed, string licencePlate)
        {
            m_brand = brand;
            m_model = model;
            m_power = power;
            m_maxSpeed = maxSpeed;
            m_type = "PassengerCar";
            m_licencePlate = licencePlate;
        }

        public PassengerCar(PassengerCar passengerCar)
        {
            m_brand = passengerCar.m_brand;
            m_model = passengerCar.m_model;
            m_power = passengerCar.m_power;
            m_maxSpeed = passengerCar.m_maxSpeed;
            m_type = "PassengerCar";
            m_licencePlate = passengerCar.m_licencePlate;
        }

        public PassengerCar()
        {

        }
    }
}

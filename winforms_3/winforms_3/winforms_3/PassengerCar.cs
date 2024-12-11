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

        public static bool operator ==(PassengerCar a, PassengerCar b)
        {
            if (a.m_brand == b.m_brand && a.m_model == b.m_model && a.m_power == b.m_power && a.m_maxSpeed == b.m_maxSpeed && a.m_licencePlate == b.m_licencePlate && a.m_multimedia == b.m_multimedia && a.m_airbags == b.m_airbags)
                return true;

            return false;
        }

        public static bool operator !=(PassengerCar a, PassengerCar b)
        {
            if (!(a == b))
                return true;

            return false;
        }

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

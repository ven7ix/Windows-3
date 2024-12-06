using System;

namespace winforms_3
{
    [Serializable]
    public class Truck : ICar
    {
        public string m_brand { get; set; }
        public string m_model { get; set; }
        public int m_power { get; set; }
        public int m_maxSpeed { get; set; }
        public string m_type { get; set; }
        public string m_licencePlate { get; set; }
        public int m_wheels { get; set; }
        public int m_trunkVolume { get; set; }

        public Truck(string brand, string model, int power, int maxSpeed, string licencePlate)
        {
            m_brand = brand;
            m_model = model;
            m_power = power;
            m_maxSpeed = maxSpeed;
            m_type = "Truck";
            m_licencePlate = licencePlate;
        }

        public Truck(Truck truck)
        {
            m_brand = truck.m_brand;
            m_model = truck.m_model;
            m_power = truck.m_power;
            m_maxSpeed = truck.m_maxSpeed;
            m_type = "Truck";
            m_licencePlate = truck.m_licencePlate;
        }

        public Truck()
        {

        }
    }
}

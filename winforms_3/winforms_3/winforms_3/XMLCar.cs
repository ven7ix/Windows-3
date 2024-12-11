using System;
using System.Collections.Generic;

namespace winforms_3
{
    [Serializable] public class XMLCar
    {
        public List<PassengerCar> PassengerCars = new List<PassengerCar>();
        public List<Truck> Trucks = new List<Truck>();

        public XMLCar()
        {

        }
    }
}

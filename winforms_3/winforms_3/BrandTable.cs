using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace winforms_3
{
    public partial class BrandTable : Form
    {
        private readonly string carBrand;

        public BrandTable(string brand)
        {
            InitializeComponent();

            carBrand = brand;

            Loader.LoadStart(carBrand);
            timerLoad.Enabled = true;
        }

        private void RenderRows(List<ICar> cars)
        {
            dataGridViewPassenger.Rows.Clear();
            dataGridViewTruck.Rows.Clear();

            foreach (ICar car in cars)
            {
                if (car.m_type == "Truck")
                    dataGridViewTruck.Rows.Add(car.m_brand, car.m_model, car.m_power, car.m_maxSpeed, car.m_licencePlate, (car as Truck).m_wheels, (car as Truck).m_trunkVolume);
                else if (car.m_type == "PassengerCar")
                    dataGridViewPassenger.Rows.Add(car.m_brand, car.m_model, car.m_power, car.m_maxSpeed, car.m_licencePlate, (car as PassengerCar).m_multimedia, (car as PassengerCar).m_airbags);
            }
        }

        private void TimerLoad_Tick(object sender, EventArgs e)
        {
            progressBarLoad.Value = Loader.GetProgress();
            RenderRows(Loader.GetData(carBrand));

            if (Loader.DoesLoaderFinish())
            {
                timerLoad.Enabled = false;
                progressBarLoad.Value = 0;
            }
        }
    }
}

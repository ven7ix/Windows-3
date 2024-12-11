using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;

namespace winforms_3
{
    public partial class BrandTable : Form
    {
        private readonly string carBrand;

        private readonly int ApplicationNumber;
        private readonly int port;
        private readonly MyTcpConnector connector;

        public BrandTable(int ApplicationNumber, string brand)
        {
            this.ApplicationNumber = ApplicationNumber;
            port = 13000 + ApplicationNumber;
            connector = new MyTcpConnector(port, LoaderEcho);

            InitializeComponent();
            Text = $"BrandTable {ApplicationNumber}";

            carBrand = brand;

            if (Loader.carBrandDictionaryList.ContainsKey(carBrand))
                RenderRows(Loader.carBrandDictionaryList[carBrand]);
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


        //
        // Blockchain
        //
        private void DataGridViewTruck_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int selectedTruckInTable = e.RowIndex;
            DataGridViewRow row = dataGridViewTruck.Rows[selectedTruckInTable];

            int selectedTruckInList = 0;
            int howManyTrucksISaw = 0;

            for (int i = 0; i < Loader.carBrandDictionaryList[carBrand].Count; i++)
            {
                ICar car = Loader.carBrandDictionaryList[carBrand][i];

                if (car is Truck)
                {
                    if (howManyTrucksISaw == selectedTruckInTable)
                    {
                        selectedTruckInList = i;
                        break;
                    }
                    howManyTrucksISaw++;
                }
            }

            Loader.carBrandDictionaryList[carBrand][selectedTruckInList].m_model = row.Cells[1].Value.ToString();
            Loader.carBrandDictionaryList[carBrand][selectedTruckInList].m_power = int.Parse(row.Cells[2].Value.ToString());
            Loader.carBrandDictionaryList[carBrand][selectedTruckInList].m_maxSpeed = int.Parse(row.Cells[3].Value.ToString());
            Loader.carBrandDictionaryList[carBrand][selectedTruckInList].m_licencePlate = row.Cells[4].Value.ToString();


            Block blockTruckCar = new Block(Block.ConvertCarToString(Loader.carBrandDictionaryList[carBrand][selectedTruckInList]));
            Loader.brandDictionaryBlockchain[carBrand][selectedTruckInList] = Block.AddBlockToMiddle(blockTruckCar, Loader.brandDictionaryBlockchain[carBrand], selectedTruckInList);
        }

        private void DataGridViewPassenger_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int selectedPassengerInTable = e.RowIndex;
            DataGridViewRow row = dataGridViewPassenger.Rows[selectedPassengerInTable];

            int selectedPassengerInList = 0;
            int howManyPassengersISaw = 0;

            for (int i = 0; i < Loader.carBrandDictionaryList[carBrand].Count; i++)
            {
                ICar car = Loader.carBrandDictionaryList[carBrand][i];

                if (car is PassengerCar)
                {
                    if (howManyPassengersISaw == selectedPassengerInTable)
                    {
                        selectedPassengerInList = i;
                        break;
                    }
                    howManyPassengersISaw++;
                }
            }

            Loader.carBrandDictionaryList[carBrand][selectedPassengerInList].m_model = row.Cells[1].Value.ToString();
            Loader.carBrandDictionaryList[carBrand][selectedPassengerInList].m_power = int.Parse(row.Cells[2].Value.ToString());
            Loader.carBrandDictionaryList[carBrand][selectedPassengerInList].m_maxSpeed = int.Parse(row.Cells[3].Value.ToString());
            Loader.carBrandDictionaryList[carBrand][selectedPassengerInList].m_licencePlate = row.Cells[4].Value.ToString();


            Block blockPassengerCar = new Block(Block.ConvertCarToString(Loader.carBrandDictionaryList[carBrand][selectedPassengerInList]));
            Loader.brandDictionaryBlockchain[carBrand][selectedPassengerInList] = Block.AddBlockToMiddle(blockPassengerCar, Loader.brandDictionaryBlockchain[carBrand], selectedPassengerInList);
        }


        //
        // P2P Buttons
        //
        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            Loader.LoadStart(carBrand);
            timerLoad.Enabled = true;
        }

        private void ButtonPing_Click(object sender, EventArgs e)
        {
            if (!Loader.carBrandDictionaryList.ContainsKey(carBrand))
            {
                for (int i = 0; i < 5; i++)
                    SendMessageTo(i, $"GIVE_ME_CARS<BR>{carBrand}");
            }

            if (Loader.carBrandDictionaryList.ContainsKey(carBrand))
                RenderRows(Loader.carBrandDictionaryList[carBrand]);
        }


        //
        // Data exchange
        //
        private string SendTableData(string brand)
        {
            List<ICar> generatedCars = new List<ICar>();
            if (Loader.carBrandDictionaryList.ContainsKey(brand))
                generatedCars = Loader.carBrandDictionaryList[brand];

            string BrandTalbeData = $"{brand}<BR>";

            for (int i = 0; i < generatedCars.Count; i++)
            {
                ICar car = generatedCars[i];

                if (car is Truck)
                {
                    BrandTalbeData += $"{(car as Truck).m_brand}<SEP>";
                    BrandTalbeData += $"{(car as Truck).m_model}<SEP>";
                    BrandTalbeData += $"{(car as Truck).m_power}<SEP>";
                    BrandTalbeData += $"{(car as Truck).m_maxSpeed}<SEP>";
                    BrandTalbeData += $"{(car as Truck).m_type}<SEP>";
                    BrandTalbeData += $"{(car as Truck).m_licencePlate}<SEP>";
                    BrandTalbeData += $"{(car as Truck).m_wheels}<SEP>";
                    BrandTalbeData += $"{(car as Truck).m_trunkVolume}";
                }
                else if (car is PassengerCar)
                {
                    BrandTalbeData += $"{(car as PassengerCar).m_brand}<SEP>";
                    BrandTalbeData += $"{(car as PassengerCar).m_model}<SEP>";
                    BrandTalbeData += $"{(car as PassengerCar).m_power}<SEP>";
                    BrandTalbeData += $"{(car as PassengerCar).m_maxSpeed}<SEP>";
                    BrandTalbeData += $"{(car as PassengerCar).m_type}<SEP>";
                    BrandTalbeData += $"{(car as PassengerCar).m_licencePlate}<SEP>";
                    BrandTalbeData += $"{(car as PassengerCar).m_multimedia}<SEP>";
                    BrandTalbeData += $"{(car as PassengerCar).m_airbags}";
                }

                if (i < generatedCars.Count - 1)
                    BrandTalbeData += "<BR>";
            }

            return BrandTalbeData;
        }

        private void ReceiveTableData(string BrandTalbeData)
        {
            Regex regBR = new Regex("<BR>");
            Regex regSEP = new Regex("<SEP>");

            if (!(regBR.IsMatch(BrandTalbeData) || regSEP.IsMatch(BrandTalbeData)))
                return;

            string[] carsData = regBR.Split(BrandTalbeData);
            string brand = carsData[1];

            if (!Loader.carBrandDictionaryList.ContainsKey(brand))
                Loader.carBrandDictionaryList.Add(brand, new List<ICar>());

            for (int i = 2; i < carsData.Count(); i++)
            {
                string[] carData = regSEP.Split(carsData[i]);

                ICar car = null;

                if (carData[4] == "Truck")
                    car = new Truck()
                    {
                        m_brand = carData[0],
                        m_model = carData[1],
                        m_power = int.Parse(carData[2]),
                        m_maxSpeed = int.Parse(carData[3]),
                        m_type = carData[4],
                        m_licencePlate = carData[5],
                        m_wheels = int.Parse(carData[6]),
                        m_trunkVolume = int.Parse(carData[7])
                    };
                else if (carData[4] == "PassengerCar")
                    car = new PassengerCar()
                    {
                        m_brand = carData[0],
                        m_model = carData[1],
                        m_power = int.Parse(carData[2]),
                        m_maxSpeed = int.Parse(carData[3]),
                        m_type = carData[4],
                        m_licencePlate = carData[5],
                        m_multimedia = carData[6],
                        m_airbags = int.Parse(carData[7])
                    };

                if (CheckCarForCopy(car, brand))
                    continue;

                Loader.carBrandDictionaryList[brand].Add(car);
            }

            // Blockchain
            if (!Loader.brandDictionaryBlockchain.ContainsKey(brand))
                Loader.brandDictionaryBlockchain.Add(brand, new List<Block>());
            Loader.brandDictionaryBlockchain[brand] = Block.ConvertListToBlockchain(Loader.carBrandDictionaryList[brand]);
        }

        private bool CheckCarForCopy(ICar carChecking, string brand)
        {
            foreach (ICar car in Loader.carBrandDictionaryList[brand])
            {
                if (car is Truck && carChecking is Truck)
                {
                    if ((car as Truck) == (carChecking as Truck))
                        return true;
                }
                else if (car is PassengerCar && carChecking is PassengerCar)
                {
                    if ((car as PassengerCar) == (carChecking as PassengerCar))
                        return true;
                }
            }
            return false;
        }


        //
        // P2P
        //
        private void LoaderEcho(string message)
        {
            object locker = new object();
            lock (locker)
            {
                Regex regBR = new Regex("<BR>");

                if (regBR.Split(message)[1] == "GIVE_ME_CARS")
                {
                    string brand = regBR.Split(message)[2];

                    if (!Loader.carBrandDictionaryList.ContainsKey(brand))
                        return;

                    if (!Block.CheckBlockchain(Loader.brandDictionaryBlockchain[brand]))
                    {
                        MessageBox.Show("Blockchain Error");
                        return;
                    }

                    SendMessageTo(int.Parse(regBR.Split(message)[0]) - 13000, $"{SendTableData(brand)}");
                    return;
                }

                ReceiveTableData(message);
            }
        }

        private void SendMessageTo(int application, string message)
        {
            if (application == ApplicationNumber)
                return;

            connector.Send("127.0.0.1", 13000 + application, $"{port}<BR>{message}");
        }
    }
}
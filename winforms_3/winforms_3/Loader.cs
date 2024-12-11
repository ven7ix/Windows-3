using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winforms_3
{
    internal class Loader
    {
        public static Dictionary<string, List<Block>> brandDictionaryBlockchain = new Dictionary<string, List<Block>>();

        private static int progress = 0;
        private static bool isFinished = true;
        private static readonly Random random = new Random();
        public static Dictionary<string, List<ICar>> carBrandDictionaryList = new Dictionary<string, List<ICar>>();

        public static async Task LoadStart(string brand)
        {
            if (carBrandDictionaryList.ContainsKey(brand))
                return;

            List<ICar> carsWithSameBrand = new List<ICar>();
            carBrandDictionaryList.Add(brand, carsWithSameBrand);

            isFinished = false;
            int recordAmount = random.Next(10, 21);

            for (int i = 0; i < recordAmount; i++)
            {
                progress = (i + 1) * 100 / recordAmount;

                ICar car = GenerateCar(brand);
                AddCarToBlockchain(brand, car);
                carsWithSameBrand.Add(car);
                carBrandDictionaryList[brand] = carsWithSameBrand;

                await Task.Delay(random.Next(0, 501));
            }

            isFinished = true;
        }

        static private ICar GenerateCar(string brand)
        {
            ICar car;

            bool truckOrPassenger = random.Next(0, 2) == 0;
            if (truckOrPassenger)
            {
                car = new PassengerCar(brand, "-", 0, 0, random.Next(0, 1000).ToString());
                (car as PassengerCar).m_multimedia = random.Next(1000, 2000).ToString() + " multimedia";
                (car as PassengerCar).m_airbags = random.Next(0, 5);
            }
            else
            {
                car = new Truck(brand, "-", 0, 0, random.Next(0, 1000).ToString());
                (car as Truck).m_wheels = random.Next(0, 8) * 2;
                (car as Truck).m_trunkVolume = random.Next(8, 21);
            }

            return car;
        }

        private static void AddCarToBlockchain(string brand, ICar car)
        {
            if (!brandDictionaryBlockchain.ContainsKey(brand))
                brandDictionaryBlockchain.Add(brand, new List<Block>());

            Block carBlock = new Block(Block.ConvertCarToString(car));
            brandDictionaryBlockchain[brand].Add(Block.AddBlock(carBlock, brandDictionaryBlockchain[brand]));
        }

        //
        //Get info
        //
        public static List<ICar> GetData(string brand)
        {
            return carBrandDictionaryList[brand];
        }

        public static bool DoesLoaderFinish()
        {
            return isFinished;
        }

        public static int GetProgress()
        {
            return progress;
        }
    }
}
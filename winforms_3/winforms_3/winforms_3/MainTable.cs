using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace winforms_3
{
    public partial class MainTable : Form
    {
        private readonly List<ICar> cars = new List<ICar>();

        private int ApplicationNumber;

        public MainTable(int ApplicationNumber)
        {
            InitializeComponent();
            this.ApplicationNumber = ApplicationNumber;
            Text = $"MainTable {ApplicationNumber}";

            //заполнение
            {
                cars.Add(new PassengerCar("Toyota", "Camry", 200, 240, "-"));
                cars.Add(new Truck("Ford", "F-150", 400, 180, "-"));
                cars.Add(new PassengerCar("Honda", "Civic", 150, 220, "-"));
                cars.Add(new Truck("Chevrolet", "Silverado", 350, 190, "-"));
                cars.Add(new PassengerCar("BMW", "3 Series", 250, 250, "-"));
                cars.Add(new PassengerCar("Mercedes-Benz", "C-Class", 220, 240, "-"));
                cars.Add(new PassengerCar("Nissan", "Rogue", 170, 200, "-"));
                cars.Add(new Truck("Ram", "1500", 395, 180, "-"));
                cars.Add(new PassengerCar("Volkswagen", "Golf", 180, 210, "-"));
                cars.Add(new PassengerCar("LADA", "ВАЗ-2121 4x4", 77, 130, "-"));
                cars.Add(new PassengerCar("LADA", "ВАЗ-21099", 72, 150, "-"));
                cars.Add(new PassengerCar("LADA", "ВАЗ-2115", 82, 175, "-"));
                cars.Add(new Truck("МАЗ", "МАЗ-5440", 400, 95, "-"));
                cars.Add(new Truck("МАЗ", "МАЗ-6517", 400, 95, "-"));
                cars.Add(new Truck("МАЗ", "МАЗ-6430", 400, 95, "-"));
            }
        }


        //
        //Open BrandTable
        //
        private void DataGridViewMainTable_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int selected = e.RowIndex;
            if (selected == -1)
                return;

            string selectedBrand = dataGridViewMainTable.Rows[selected].Tag.ToString();

            BrandTable brandTable = new BrandTable(ApplicationNumber, selectedBrand);
            brandTable.Show();
        }


        //
        //Update table
        //
        private void UpdateMainTable()
        {
            dataGridViewMainTable.CurrentCell = null;
            bindingSourceCars.DataSource = cars;
            RecolorMainTable();
            UpdateTags();
        }

        private void RecolorMainTable()
        {
            foreach (DataGridViewRow row in dataGridViewMainTable.Rows)
            {
                if (row.Cells[4].Value.ToString() == "PassengerCar")
                    row.DefaultCellStyle.BackColor = Color.Red;
                else if (row.Cells[4].Value.ToString() == "Truck")
                    row.DefaultCellStyle.BackColor = Color.Blue;
                else
                    row.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void UpdateTags()
        {
            for (int i = 0; i < dataGridViewMainTable.Rows.Count; i++)
                dataGridViewMainTable.Rows[i].Tag = cars[i].m_brand;
        }

        private void MainTable_Load(object sender, EventArgs e)
        {
            UpdateMainTable();
        }

        private void DataGridViewMainTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int selected = e.RowIndex;
            if (selected == -1)
                return;

            UpdateMainTable();
        }


        //
        //XML
        //
        private void SaveListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XMLCar car = new XMLCar();

            IEnumerable<PassengerCar> passengerCar = from p in cars where p is PassengerCar select p as PassengerCar;
            car.PassengerCars = passengerCar.ToList();

            IEnumerable<Truck> truck = from p in cars where p is Truck select p as Truck;
            car.Trucks = truck.ToList();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(XMLCar));
            
            using (FileStream file = new FileStream("brands.xml", FileMode.Create))
                xmlSerializer.Serialize(file, car);
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cars.Clear();
            XMLCar car = new XMLCar();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(XMLCar));
            using (FileStream file = new FileStream("brands.xml", FileMode.Open))
                car = xmlSerializer.Deserialize(file) as XMLCar;

            foreach (PassengerCar passengerCar in car.PassengerCars)
                cars.Add(passengerCar);
            foreach (Truck truck in car.Trucks)
                cars.Add(truck);

            UpdateMainTable();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
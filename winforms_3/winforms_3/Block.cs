using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace winforms_3
{
    internal class Block
    {
        static public readonly string SEP = "<HASH>";
        public string hashCode;
        private static readonly Regex regHASH = new Regex("<HASH>");

        public Block(string input)
        {
            hashCode = input;
        }

        static public string GetHash(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }

        static public Block AddBlock(Block message, List<Block> blockchain)
        {
            if (blockchain.Count == 0)
                return message;

            Block hashed = new Block(GetHash(blockchain[blockchain.Count - 1].hashCode) + SEP + message.hashCode);

            return hashed;
        }

        static public Block AddBlockToMiddle(Block message, List<Block> blockchain, int position)
        {
            if (blockchain.Count == 0)
                return message;

            if (position <= 0)
                return message;

            Block hashed = new Block(GetHash(blockchain[position - 1].hashCode) + SEP + message.hashCode);

            return hashed;
        }

        static public string GetPreviousHash(string input)
        {
            return regHASH.Split(input)[0];
        }

        static public bool CheckBlock(Block block, Block blockPrevious)
        {
            if (GetPreviousHash(block.hashCode) != GetHash(blockPrevious.hashCode))
                return false;

            return true;
        }

        static public bool CheckBlockchain(List<Block> blockchain)
        {
            for (int i = blockchain.Count - 1; i > 0; i--)
            {
                if (!CheckBlock(blockchain[i], blockchain[i - 1]))
                    return false;
            }

            return true;
        }

        static public string ConvertCarToString(ICar car)
        {
            string carAsString = string.Empty;

            if (car is Truck)
            {
                carAsString += $"{(car as Truck).m_brand}<SEP>";
                carAsString += $"{(car as Truck).m_model}<SEP>";
                carAsString += $"{(car as Truck).m_power}<SEP>";
                carAsString += $"{(car as Truck).m_maxSpeed}<SEP>";
                carAsString += $"{(car as Truck).m_type}<SEP>";
                carAsString += $"{(car as Truck).m_licencePlate}<SEP>";
                carAsString += $"{(car as Truck).m_wheels}<SEP>";
                carAsString += $"{(car as Truck).m_trunkVolume}";
            }
            else if (car is PassengerCar)
            {
                carAsString += $"{(car as PassengerCar).m_brand}<SEP>";
                carAsString += $"{(car as PassengerCar).m_model}<SEP>";
                carAsString += $"{(car as PassengerCar).m_power}<SEP>";
                carAsString += $"{(car as PassengerCar).m_maxSpeed}<SEP>";
                carAsString += $"{(car as PassengerCar).m_type}<SEP>";
                carAsString += $"{(car as PassengerCar).m_licencePlate}<SEP>";
                carAsString += $"{(car as PassengerCar).m_multimedia}<SEP>";
                carAsString += $"{(car as PassengerCar).m_airbags}";
            }

            return carAsString;
        }

        static public List<Block> ConvertListToBlockchain(List<ICar> cars)
        {
            List<Block> blockchain = new List<Block>();

            foreach (ICar car in cars)
            {
                blockchain.Add(AddBlock(new Block(ConvertCarToString(car)), blockchain));
            }

            return blockchain;
        }
    }
}
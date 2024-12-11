using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace winforms_3
{
    internal class Block
    {
        public string splitter = "<HASH>";
        public string hashCode;
        private Regex regHASH = new Regex("<HASH>");

        public Block(string input)
        {
            hashCode = input;
        }

        public string GetHash(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }

        public string GetPreviousHash(string input)
        {
            return regHASH.Split(input)[0];
        }

        static public List<Block> blockchain = new List<Block>();
        public void AddMessageToBlockchain(string message)
        {
            if (blockchain.Count == 0)
            {
                blockchain.Add(new Block(splitter + message));
                return;
            }

            blockchain.Add(new Block(blockchain[blockchain.Count - 1].ToString() + splitter + message));
        }

        public bool CheckBlockchain()
        {
            for (int i = 0; i < blockchain.Count; i++)
            {
                if (i == 0)
                    continue;

                if (GetPreviousHash(blockchain[i].hashCode) != GetHash(blockchain[i - 1].hashCode))
                {
                    return false;
                }
            }

            return true;
        }
    }
}

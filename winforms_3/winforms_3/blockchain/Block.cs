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
        static public string SEP = "<HASH>";
        public string hashCode;
        static private Regex regHASH = new Regex("<HASH>");

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
            {
                return message;
            }

            Block hashed = new Block(GetHash(blockchain[blockchain.Count - 1].hashCode.ToString()) + SEP + message.hashCode);

            return hashed;
        }

        static public string GetPreviousHash(string input)
        {
            return regHASH.Split(input)[0];
        }

        static public bool CheckBlock(Block block, Block blockPrevious)
        {
            if (GetPreviousHash(block.hashCode) != GetHash(blockPrevious.hashCode))
            {
                return false;
            }

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using winforms_3;

namespace blockchain
{
    internal class Program
    {
        static public List<Block> blockchain = new List<Block>();

        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{i}\t");
                string message = Console.ReadLine();
                Block block = new Block(message);

                blockchain.Add(Block.AddBlock(block, blockchain));

                Console.WriteLine($"{blockchain.Last().hashCode}\n");
            }

            blockchain[0].hashCode = "m10";

            for (int i = blockchain.Count - 1; i > 0; i--)
            {
                Console.WriteLine($"{i}\t");

                if (Block.CheckBlock(blockchain[i], blockchain[i - 1]))
                {
                    Console.WriteLine($"{blockchain[i].hashCode} - True\n");
                }
                else
                {
                    Console.WriteLine($"{blockchain[i].hashCode} - False\n");
                }

                
            }
        }
    }
}

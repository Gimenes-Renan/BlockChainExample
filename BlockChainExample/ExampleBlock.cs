using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainExample
{
    public class ExampleBlock
    {
        public DateTime TimeStamp;
        public long Nonce;
        public string PreviousHash { get; set; }

        public List<HistoricTransaction> HistoricTransactions { get; set; }

        public string Hash { get; set; }

        public ExampleBlock(DateTime timeStamp, List<HistoricTransaction> transactions, string previousHash = "")
        {
            TimeStamp = timeStamp;
            Nonce = 0;
            HistoricTransactions = transactions;
            PreviousHash = previousHash;
            Hash = CreateHash();
        }
        public void MineBlock(int proofOfWorkDifficulty)
        {
            string hashValidationTemplate = new('0', proofOfWorkDifficulty);

            while (Hash.Substring(0, proofOfWorkDifficulty) != hashValidationTemplate)
            {
                Nonce++;
                Hash = CreateHash();
            }
            Console.WriteLine("Blocked with HASH={0} successfully mined!", Hash);
        }
        public string CreateHash()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                string rawData = PreviousHash + TimeStamp + HistoricTransactions + Nonce;
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                return Encoding.UTF8.GetString(bytes);
            }
        }
        public override string ToString()
        {
            return "Hash: " + Hash;
        }
    }
}

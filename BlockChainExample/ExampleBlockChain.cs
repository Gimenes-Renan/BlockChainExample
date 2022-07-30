using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainExample
{
    public class ExampleBlockChain
    {
        private readonly int _proofOfWorkDifficulty;
        private readonly decimal _miningReward;
        private List<HistoricTransaction> _pendingTransactions;
        public List<ExampleBlock> Chain { get; set; }
        public ExampleBlockChain(int proofOfWorkDifficulty, int miningReward)
        {
            _proofOfWorkDifficulty = proofOfWorkDifficulty;
            _miningReward = miningReward;
            _pendingTransactions = new List<HistoricTransaction>();
            Chain = new List<ExampleBlock> { CreateGenesisBlock() };
        }
        public void CreateTransaction(HistoricTransaction transaction)
        {
            _pendingTransactions.Add(transaction);
        }
        public void MineBlock(string minerAddress)
        {
            var minerRewardTransaction = new HistoricTransaction(null, minerAddress, _miningReward);
            _pendingTransactions.Add(minerRewardTransaction);
            var block = new ExampleBlock(DateTime.Now, _pendingTransactions);
            block.MineBlock(_proofOfWorkDifficulty);
            block.PreviousHash = Chain.Last().Hash.ToString();
            Chain.Add(block);
            _pendingTransactions = new List<HistoricTransaction>();
        }
        public bool IsValidChain()
        {
            for (int i = 1; i < Chain.Count; i++)
            {
                ExampleBlock previousBlock = Chain[i - 1];
                ExampleBlock currentBlock = Chain[i];
                if (currentBlock.Hash != currentBlock.CreateHash())
                    return false;
                if (currentBlock.PreviousHash != previousBlock.Hash)
                    return false;
            }
            return true;
        }
        public decimal GetBalance(string address)
        {
            decimal balance = 0;
            foreach (ExampleBlock block in Chain)
            {
                foreach (var transaction in block.HistoricTransactions)
                {
                    if (transaction.From == address)
                    {
                        balance -= transaction.Amount;
                    }
                    if (transaction.To == address)
                    {
                        balance += transaction.Amount;
                    }
                }
            }
            return balance;
        }
        private ExampleBlock CreateGenesisBlock()
        {
            var transactions = new List<HistoricTransaction> { new HistoricTransaction("", "", 0) };
            return new ExampleBlock(DateTime.Now, transactions, "0");
        }

        public static void PrintChain(ExampleBlockChain blockChain)
        {
            Console.WriteLine("----------------- Start Blockchain -----------------");
            foreach (ExampleBlock block in blockChain.Chain)
            {
                Console.WriteLine();
                Console.WriteLine("------ Start Block ------");
                Console.WriteLine("Hash: {0}", block.Hash);
                Console.WriteLine("Previous Hash: {0}", block.PreviousHash);
                Console.WriteLine("--- Start Transactions ---");
                foreach (var transaction in block.HistoricTransactions)
                {
                    Console.WriteLine("From: {0} To {1} Amount {2}", transaction.From, transaction.To, transaction.Amount);
                }
                Console.WriteLine("--- End Transactions ---");
                Console.WriteLine("------ End Block ------");
            }
            Console.WriteLine("----------------- End Blockchain -----------------");
        }
    }
}

// See https://aka.ms/new-console-template for more information
using BlockChainExample;

//Console.WriteLine("Hello, World!");

//BlockChain bc = new BlockChain();
//var block1 = bc.GenerateGenesisBlock();

//var block2 = bc.GenerateNewBlock(block1, new HistoricTransaction("Renan", "Juliana", 99.99m));

//var block3 = bc.GenerateNewBlock(block2, new HistoricTransaction("Juliana", "Genésio", 8.88m));

//Console.WriteLine("Block 1 - Status:");
//Console.WriteLine(block1.ToString());
//Console.WriteLine();
//Console.WriteLine("Block 2 - Status:");
//Console.WriteLine(block2.ToString());
//Console.WriteLine();
//Console.WriteLine("Block 3 - Status:");
//Console.WriteLine(block3.ToString());

//Console.WriteLine();

//var exBlock1 = new ExampleBlock(DateTime.Now, new List<HistoricTransaction>());

//var exBlock2 = new ExampleBlock(DateTime.Now, exBlock1.HistoricTransactions, exBlock1.Hash);

//Console.WriteLine("exBlock1 = " + exBlock1);
//Console.WriteLine("exBlock2 = " + exBlock2);

//Console.WriteLine();




const string minerAddress = "miner1";
const string user1Address = "A";
const string user2Address = "B";
var blockChain = new ExampleBlockChain(proofOfWorkDifficulty: 2, miningReward: 10);
blockChain.CreateTransaction(new HistoricTransaction(user1Address, user2Address, 200));
blockChain.CreateTransaction(new HistoricTransaction(user2Address, user1Address, 10));
Console.WriteLine("Is valid: {0}", blockChain.IsValidChain());
Console.WriteLine();
Console.WriteLine("--------- Start mining ---------");
blockChain.MineBlock(minerAddress);
Console.WriteLine("BALANCE of the miner: {0}", blockChain.GetBalance(minerAddress));
blockChain.CreateTransaction(new HistoricTransaction(user1Address, user2Address, 5));
Console.WriteLine();
Console.WriteLine("--------- Start mining ---------");
blockChain.MineBlock(minerAddress);
Console.WriteLine("BALANCE of the miner: {0}", blockChain.GetBalance(minerAddress));
Console.WriteLine();
ExampleBlockChain.PrintChain(blockChain);
Console.WriteLine();
Console.WriteLine("Hacking the blockchain...");
blockChain.Chain[1].HistoricTransactions = new List<HistoricTransaction> { new HistoricTransaction(user1Address, minerAddress, 150) };
Console.WriteLine("Is valid: {0}", blockChain.IsValidChain());
Console.ReadKey();




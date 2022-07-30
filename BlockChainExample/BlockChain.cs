// See https://aka.ms/new-console-template for more information
internal class BlockChain
{
    public BlockChain()
    {

    }

    public Block GenerateGenesisBlock()
    {
        var block = new Block();
        block.Hash = new HashCode();
        block.PreviousHash = block.Hash;
        return block;
    }

    public HashCode GenerateHashCode(HashCode hash, HistoricTransaction ht)
    {
        hash.Add(ht);
        return hash;
    }

    public Block GenerateNewBlock(Block previousBlock, HistoricTransaction ht)
    {
        Block block = new Block();
        block.PreviousHash = previousBlock.Hash;
        block.Hash = GenerateHashCode(previousBlock.Hash, ht);
        return block;
    }
}
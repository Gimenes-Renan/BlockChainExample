// See https://aka.ms/new-console-template for more information
public class Block
{
    public HashCode Hash { get; set; }
    public HashCode PreviousHash { get; set; }

    public Block()
    {
    }

    public override string ToString()
    {
        return "Hash: " + Hash.ToHashCode() + " - PreviousHash: " + PreviousHash.ToHashCode();
    }
}
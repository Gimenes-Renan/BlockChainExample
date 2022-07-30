// See https://aka.ms/new-console-template for more information
public class HistoricTransaction
{
    public decimal Amount { get; set; }
    public DateTime DateTime { get; set; }
    public string From { get; }
    public string To { get; }

    public HistoricTransaction(string from, string to, decimal amount)
    {
        From = from;
        To = to;
        Amount = amount;
        DateTime = DateTime.Now;
    }
}
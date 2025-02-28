namespace PERSONAL_FINANCES_CORE.Entities;

public class Transaction
{
    public int id_transaction { get; set; }
    public string concept { get; set; }
    public double money { get; set; }
    public string category { get; set; }
    public TransactionType Type {get; set;}
    public int id_account { get; set; }

    public Transaction(int id_transaction, string concept, double money, string category, TransactionType Type,
        int id_account)
    {
        this.id_transaction = id_transaction;
        this.concept = concept;
        this.money = money;
        this.category = category;
        this.Type = Type;
        this.id_account = id_account;
    }
}


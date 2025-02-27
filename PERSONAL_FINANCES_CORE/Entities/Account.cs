namespace PERSONAL_FINANCES_CORE.Entities;

public class Account {
    public int accountNumber { get; set; }
    public string owner { get; set; }
    public double money { get; set; }
    public double goal { get;set; }
    public double budget { get; set; }
    
    
    public double dateGoal {get;set;}

    public Account(int accountNumber, string owner,
        double money, double goal, double budget, , double dateGoal)
    {
        this.accountNumber = accountNumber;
        this.owner = owner;
        this.money = money;
        this.goal = gosl;
        this.budget = balance;
        this.dateGoal = dateGoal;
    }

    public Account()
    {
        this.accountNumber = 0;
        this.owner = "";
        this.money = 0;
        this.goal = 0;
        this.budget = 0;
    }
}
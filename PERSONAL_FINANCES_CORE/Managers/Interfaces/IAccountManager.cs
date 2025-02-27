using PERSONAL_FINANCES_CORE.Entities;
using PERSONAL_FINANCES_CORE.Enums;

namespace PERSONAL_FINANCES_CORE.Managers.Interfaces;

public class IAccountManager
{
    account getaccount(int id_account);

    bool newAccount(string owner, double money, double goal, double budget, double dategoal);
    
    double currentBalance(int id_account);
    
    string report(int id_account);
    
    bool updateBalance(int id_account, TransactionManager transactionManager);
}
using PERSONAL_FINANCES_CORE.Entities;
using PERSONAL_FINANCES_CORE.Enums;

namespace PERSONAL_FINANCES_CORE.Managers.Interfaces;

public interface IAccountManager
{
    //obtiene cuenta con id
    Account getaccount(int id_account);

    //creación de cuentas nuevas con sus atributos
    bool newAccount(string owner, double money, double goal, double budget, double dategoal);
    
    //obtener el saldo actual
    double currentBalance(int id_account);
    
    //obtienen información de la cuenta
    string report(int id_account);
    
    //Actualiza el saldo 
    bool updateBalance(int id_account, double amount);
    
    //transacciones y estado de la cuenta 
    string summary (int id_account, TransactionManager transactionManager);
    
    //Obtiene cuentas
    List<Account> listAccounts();
}
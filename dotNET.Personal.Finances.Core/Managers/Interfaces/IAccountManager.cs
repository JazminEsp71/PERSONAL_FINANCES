//Importacion de entidades y enums
using dotNET.Personal.Finances.Core.Entities;
using dotNET.Personal.Finances.Core.Enums;

//Nombre del paquete al que pertence la clase
namespace dotNET.Personal.Finances.Core.Managers.Interfaces;

public interface IAccountManager{

    //Obtención de una cuenta a través del ID
    Account getAccount(int id_account);

    //Creación de cuentas nuevas con sus atributos completos
    bool newAccount(string owner, double money, double goal, 
        double budget, double dateGoal);

    //Obtención del saldo actual
    double currentBalance(int id_account);

    //Obtencion de la información personal de la cuenta
    string report(int id_account);

    //Actualización del saldo actual
    bool updateBalance(int id_account, double amount); 

    //Listado de las transacciones y estado de la cuenta
    string summary(int id_account, TransactionManager transactionManager);

    //Obtención directa de las cuentas
    List<Account> listAccounts();
}
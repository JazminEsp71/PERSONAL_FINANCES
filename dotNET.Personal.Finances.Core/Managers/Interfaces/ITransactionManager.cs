//Importacion de entidades y enums
using dotNET.Personal.Finances.Core.Entities;
using dotNET.Personal.Finances.Core.Enums;

//Nombre del paquete al que pertenece esta clase
namespace dotNET.Personal.Finances.Core.Managers.Interfaces;

public interface ITransactionManager{

    //Obtencion de una trasaccion con su id y su id de cuenta
    Transaction getTransaction(int id_transaction, int id_account);

    //Cacenlación de una transacción con su id y su id de cuenta
    bool cancelTransaction(int id_transaction, 
        int id_account, AccountManager accountManager);

    /*Recibe AccountManager para realizar las operaciones 
    dentro del manejador instanciado en la clase Program, es decir,
    utilizará el servicio instanciado al principio del programa*/
    bool newTransaction(string concept, double money, string category, TransactionType type, 
        int id_account, AccountManager accountManager);

    //Obtención directa de las transacciones
    List<Transaction> listTransactions();
}
//Importacion de entidades, enums e interfaces de managers y servicios
using dotNET.Personal.Finances.Core.Entities;
using dotNET.Personal.Finances.Core.Enums;
using dotNET.Personal.Finances.Core.Managers.Interfaces;
using dotNET.Personal.Finances.Core.Services.Interfaces;

//Nombre del paquete al que pertenece la clase
namespace dotNET.Personal.Finances.Core.Managers;

//Implementación de la interfaz ITransactionManager
public class TransactionManager : ITransactionManager{

    //Instancia del servicio TransactionService
    private readonly ITransactionService _service;

    //Definición de la instancia del servicio
    public TransactionManager(ITransactionService service){
        _service = service;
    }

    //Implementación de métodos de la interfaz correspondiente
    public bool newTransaction(string concept, double money, string category, TransactionType type, int id_account, AccountManager accountManager){
        return _service.newTransaction(concept, money, category, type, id_account, accountManager);
    }


    public Transaction getTransaction(int id_transaction, int id_account){
        return _service.getTransaction(id_transaction, id_account);
    }

    public bool cancelTransaction(int id_transaction, int id_account, AccountManager accountManager){
        return _service.cancelTransaction(id_transaction, id_account, accountManager);
    }

    public List<Transaction> listTransactions(){
        return _service.listTransactions();
    }

}
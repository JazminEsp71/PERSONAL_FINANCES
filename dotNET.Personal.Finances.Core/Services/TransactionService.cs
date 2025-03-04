//Importación de entidades, enums, managers e interfaces de los servicios
using dotNET.Personal.Finances.Core.Entities;
using dotNET.Personal.Finances.Core.Enums;
using dotNET.Personal.Finances.Core.Services.Interfaces;
using dotNET.Personal.Finances.Core.Managers;
using System;

//Nombre del paquete al que pertenece la clase
namespace dotNET.Personal.Finances.Core.Services;

//Implementación de la interfaz del servicio
public class TransactionService : ITransactionService {

    //Lista de transacciones en el sistema
    List<Transaction> transactions = new List<Transaction>();

    //Generador de IDs
    IDGenerator generator = new IDGenerator(); 

    /*Creará una nueva transacción asociada con una cuenta y actualizará
    el saldo de la cuenta dependiendo del tipo de moviento (ingreso o egreso)*/
    public bool newTransaction(string concept, double money, string category,
        TransactionType type, int id_account, AccountManager accountManager){
        try{
            Transaction transaction = new Transaction(generator.getNewID(), 
                concept, money, category, type, id_account);
            Account account = accountManager.getAccount(id_account);
            
            if(!(transaction.Type==TransactionType.Income) && transaction.Money > account.Money){
            return false;
            }

            //Evalua si la transaccion es de tipo ingreso o egreso y actualiza el saldo total
            if(transaction.Type == TransactionType.Egress){
                accountManager.updateBalance(id_account, -transaction.Money);
            }else if(transaction.Type == TransactionType.Income){
                accountManager.updateBalance(id_account, transaction.Money);
            }
            
            //Agrega la transaccion a la lista de transacciones
            transactions.Add(transaction);

            return true;
        }catch(Exception ex){
            return false;
        }
    }

    //Obtendrá una transacción a través de su id y el id de la cuenta
    public Transaction getTransaction(int id_transaction, int id_account){
        /*Itera sobre la lista y devuelve 
        aquella que sea la misma del ID y el ID de la cuenta*/
        foreach(Transaction transaction in transactions){
            if((transaction.Id_transaction == id_transaction) 
                && (transaction.Id_transaction == id_account) ){
                return transaction;
            }
        }
        return null;
    }

    /*Cancelará una transacción a través de su id y el id de la cuenta, 
    además recibirá el manager del servicio para tener la misma instancia
     donde se encuentra la información de la cuenta para actulizar su saldo*/
    public bool cancelTransaction(int id_transaction, int id_account, 
        AccountManager accountManager){
        try{
            Transaction transaction = getTransaction(id_transaction, id_account);
            
            Account account = accountManager.getAccount(id_account);
            
            if(!(transaction.Type==TransactionType.Egress) && transaction.Money > account.Money){
            return false;
            }

            /*Evalua el tipo de transaccion a cancelar para aumentar o restar
            el saldo total de la cuenta, si es egreso -> suma, si es ingresa -> resta*/
            if(transaction.Type == TransactionType.Egress){
                accountManager.updateBalance(id_account, transaction.Money);
            }else if(transaction.Type == TransactionType.Income){
                accountManager.updateBalance(id_account, -transaction.Money);
            }

            return true;
        }catch(Exception ex){
            return false;
        }
    }

    //Devuelve la lista de transacciones del sistema
    public List<Transaction> listTransactions(){
        return this.transactions;
    }
    
}
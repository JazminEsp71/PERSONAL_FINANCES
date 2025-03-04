//Importación de las entidades, enums, managers e interfaces del servicio
using dotNET.Personal.Finances.Core.Entities;
using dotNET.Personal.Finances.Core.Enums;
using dotNET.Personal.Finances.Core.Managers;
using dotNET.Personal.Finances.Core.Services.Interfaces;
using System;

//Nombre del paquete al que pertenece la clase
namespace dotNET.Personal.Finances.Core.Services;

//Implementación de la interfaz IAccountService
public class AccountService : IAccountService {

    //Lista que almacenará las cuentas del sistema
    public List<Account> accountList = new List<Account>();

    //Generador de IDs
    IDGenerator generator = new IDGenerator(); 

    //Este méotodo creará una nueva cuenta y la cargaŕa a la lista
    public bool newAccount(string owner, double money, 
        double goal, double budget, double dateGoal){

        if (money < 0) {
            return false;
        }
        
        try{
            Account account = new Account(generator.getNewID()+1, owner, money, goal, budget, dateGoal); 
            accountList.Add(account);

            return true; //Para validar si la operación se hizo correctamente
        }catch(Exception ex){
            System.Console.WriteLine("HA OCURRIDO UN ERROR AL AGREGAR LA CUENTA");
            return false;
        }
    }

    //Este método retornará una cuenta a través de su id
    public Account getAccount(int id_account){
        foreach (Account account in accountList){
           if(account.Id_account == id_account){
            return account;
           }
        }
        return null; //Si no encuentra la cuenta, retorna null
    }

    //Este método retorna el saldo actual de una cuenta
    public double currentBalance(int id_account){
        try{
            Account account = getAccount(id_account);
            return account.Money;
        }catch(Exception ex){
            return 0.0; //Si no encuentra la cuenta, retorna 0
        }
    }

    /*Este método retorna las transacciones asociadas a una
    cuenta, recibe la instancia del manager para obtener los mismos datos
    que se encuentran al momento de la ejecución del sistema*/
    public string summary(int id_account, TransactionManager transactionManager){
        try{
            string summary = "LISTADO DE TRANSACCIONES: \n";
            Account account = getAccount(id_account);
            List<Transaction> transactions = transactionManager.listTransactions();

            foreach (Transaction transaction in transactions){
                summary += $"ID: ${transaction.Id_transaction}, Tipo: ${transaction.Type}, Concepto: ${transaction.Concept} -> $ ${transaction.Money}\n";
            }

            return summary;
        }catch(Exception ex){
            return "HA OCURRIDO UN ERROR";
        }
    }

    //Este método retorna la información básica de la cuenta
    public string report(int id_account){
        try{
            Account account = getAccount(id_account);
            string report = $"CUENTA: {account.Id_account} \n" +
                $"PROPIETARIO: {account.Owner} \n" +
                $"SALDO: {account.Money} \n" +
                $"META: {account.Goal} \n" +
                $"PRESUPUESTO: {account.Budget} \n" +
                $"SEMANAS CALCULADAS PARA ALCANZAR LA META: {account.DateGoal}";

            return report;
        }catch(Exception ex){
            return "HA OCURRIDO UN ERROR";
        }
    }

    //Este método actualiza el saldo actual de una cuenta
    public bool updateBalance(int id_account, double amount){
        try
        {
            Account account = getAccount(id_account);
            account.Money += amount;
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    //Retorna la lista de cuentas directamente
    public List<Account> listAccounts(){
        return this.accountList;
    }
}


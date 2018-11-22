using IDMONEY.IO.Model;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace IDMONEY.IO.Service
{
    public class TransactionService : BaseService
    {
        public TransactionModel Transaction { get; set; }

        public ObservableCollection<TransactionModel> Transactions { get; set; }

        public static async Task<TransactionService> InsertTrasactionAsync(TransactionModel transaction)
        {
            var uri = new Uri(APIDictionary.API_InsertTrasaction);

            var json = JsonConvert.SerializeObject(new
            {
                Transaction = transaction
            });

            return await PostAsync<TransactionService>(json, uri, UserService.GetUser().Token);
        }

        public static TransactionService SearchTransaction()
        {
            var uri = new Uri(APIDictionary.API_TransactionsList);

            return Get<TransactionService>(uri, UserService.GetUser().Token);
        }

        public static async Task<TransactionService> SearchTransactionAsync()
        {
            var uri = new Uri(APIDictionary.API_TransactionsList);

            return await GetAsync<TransactionService>(uri, UserService.GetUser().Token);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Prism.Events;
using RajProj.Models;

namespace RajProj.Data
{
    public class MerchantService
    {
        public string Message { get; set; }
        public IEventAggregator EA { get; set; }
        private readonly IEventAggregator _ea;
        public Data.RajContext Context { get; set; }
       
        private readonly Data.RajContext _context;
        private static int i = 1;
        public List<Merchant> MerchantList;
        public MerchantService(Data.RajContext context, IEventAggregator ea)
        {
            _ea = ea;
            EA = _ea;
            Context = _context = context;
            Message = "Merchant Accounts";
            MerchantList = new List<Merchant>();
            MerchantList = Context.Merchant.ToArray().ToList();
            DbSet<Merchant> db = Context.Merchant;
            //DataTable dataTable = db.U;
        }       
        public List<Merchant> GetAccountList()
        {
            //call to db. fetch all rows in merchant table
            Merchant[] merchants = Context.Merchant.ToArray(); // pass this to am IEnumerable class.
            return merchants.ToList<Merchant>();
        }
        public void CreateMerchantAccount()
        {
            Merchant merchant = new Merchant();
            merchant.MerhchantName = "OCBC";
            merchant.MaxDailyTransactionAmount = 1000;
            merchant.MinDailyTranAmount = 100;
            merchant.Account = i.ToString();
            Context.Merchant.Add(merchant);
            //Context.SaveChangesAsync();
            Context.SaveChanges();
            MerchantList = GetAccountList();
            i++;
            //todo add code to broadcast an event which says the  database has been updated.
        }
        public void CreateMerchantAccounts(int x)
        {
            x = x + i;
            for (; i <= x; i++)
            {
                Merchant merchant = new Merchant();
                merchant.MerhchantName = "OCBC";
                merchant.MaxDailyTransactionAmount = 1000;
                merchant.MinDailyTranAmount = 100;
                merchant.Account = i.ToString();
                Context.Merchant.Add(merchant);
                //Context.SaveChangesAsync();
                Context.SaveChanges();
            }
            MerchantList = GetAccountList(); 
            //todo add code to broadcast an event which says the  database has been updated.
        }
    }
}

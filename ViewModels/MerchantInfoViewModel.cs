using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RajProj.Models;
using RajProj.Data;
using Prism.Events;
using System.Collections.Specialized;
using Microsoft.JSInterop;
using System.IO;
using System.Data;

namespace RajProj.ViewModels
{
    /// <summary>
    /// Implements Pagination.
    /// </summary>
    public class MerchantInfoViewModel
    {
        private readonly IEventAggregator _ea;
        public IEventAggregator EA { get; set; }
        RajContext _context;
        private Merchant[] overLimitMerchants = { };
        public MerchantService MerchantService { get; set; }
        public Merchant[] Merchants { get; set; }
        //public List<Merchant> MerchantList { get; set; }
        public Merchant[] OverLimitMerchants { get; set; }
        public int TotalPages { get; set; }
        public int PageId { get; set; }
        public int RowCount { get; set; }
        private int MaxRows = 50;
        private DataTable dTable;

        //public MerchantInfoViewModel(MerchantService mService, IEventAggregator ea, Data.RajContext context)
        //{
        //    _ea = ea;
        //    EA = _ea;
        //    _context = context;
        //    MerchantService = mService;
        //    MerchantService.Context = _context;
        //}
        public MerchantInfoViewModel(MerchantService mService, IEventAggregator ea)
        {
            _ea = ea;
            EA = _ea;           
            MerchantService = mService;
            dTable = new DataTable("Merchants Table");
            ConvertToDataTable();
            //MerchantList = mService.MerchantList;
        }
        public async Task<Merchant[]> GetMerchantsAsync(DateTime dateTime)
        {            
            Merchants = MerchantService.MerchantList.ToArray();
            //MerchantList = MerchantService.MerchantList;
            if (Merchants != null)
                MerchantService.Message = "";
            return Merchants;
        }    
        private void ConvertToDataTable()
        {          
            DataColumn dtColumn;
            DataRow dRow;
           
            // Create id column  
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(Int32);
            dtColumn.ColumnName = "ID";
            dtColumn.Caption = "Merchant ID";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = true;
            // Add column to the DataColumnCollection.  
            dTable.Columns.Add(dtColumn);

            // Create Name column.    
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "MerhchantName";
            dtColumn.Caption = "Merchant Name";
            dtColumn.AutoIncrement = false;
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            /// Add column to the DataColumnCollection.  
            dTable.Columns.Add(dtColumn);

            // Create Address column.    
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "Account";
            dtColumn.Caption = "Account";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            // Add column to the DataColumnCollection.    
            dTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(Int32);
            dtColumn.ColumnName = "MaxDailyTransactionAmount";
            dtColumn.Caption = "MaxDailyTransactionAmount";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            // Add column to the DataColumnCollection.    
            dTable.Columns.Add(dtColumn);
           
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(Int32);
            dtColumn.ColumnName = "MinDailyTranAmount";
            dtColumn.Caption = "MinDailyTranAmount";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            // Add column to the DataColumnCollection.    
            dTable.Columns.Add(dtColumn);

            foreach(Merchant merchant in MerchantService.MerchantList)
            {
                dRow = dTable.NewRow();
                dRow["ID"] = merchant.ID;
                dRow["MerhchantName"] = merchant.MerhchantName;
                dRow["Account"] = merchant.Account;
                dRow["MaxDailyTransactionAmount"] = merchant.MaxDailyTransactionAmount;
                dRow["MinDailyTranAmount"] = merchant.MinDailyTranAmount;
                dTable.Rows.Add(dRow);
            }

        }

        private bool CheckValidRow(int pageId, int rowCount)
        {          
            int numPages = MerchantService.MerchantList.Count / rowCount;
            int numRemainder = MerchantService.MerchantList.Count % rowCount;// the remaining rows on the last page.
            int endIndex = (pageId * rowCount);// index to the last row within a page.
            int startIndex = endIndex - rowCount; // index to the starting row within a page.
            int count = endIndex - numRemainder;
            if (endIndex - numRemainder != 0)
                return false;// out of bounds count
            return true;


        }
        /// <summary>
        /// returns a List<DataRow> which is fileterd based on pageID and rowCount
        /// </summary>
        /// <param name="table"></param>
        /// <param name="pageId"></param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public List<DataRow> GetAccountList(DataTable table, int pageId, int rowCount)
        {
            List<DataRow> filteredRow = new List<DataRow>();
            rowCount = rowCount > MaxRows ? 35 : rowCount;
            
            //check for negative page and row
            if (pageId < 1 || rowCount < 1)
            {                
                return filteredRow;
            }

            int numPages = table.Rows.Count / rowCount;
            int numRemainder = table.Rows.Count % rowCount;
            int endIndex = (pageId * rowCount);// index to the last row within a page.
            int startIndex = endIndex - rowCount; // index to the starting row within a page.

            if (startIndex >= table.Rows.Count) // check for out of bound row index based on row count
            {                
                return filteredRow;
            }
            if (endIndex > table.Rows.Count) // adjust the end index
                endIndex = table.Rows.Count; // startIndex + numRemainder

            for (int i = startIndex; i < endIndex; i++)
            {
                filteredRow.Add(table.Rows[i]);
            }           
            return filteredRow;
        }
        /// <summary>
        /// Returns a filtered list of Merchant objects
        /// </summary>
        /// <returns></returns>
        public List<Merchant> GetAccountList(int pageId, int rowCount)
        { 
            Merchants = MerchantService.MerchantList.ToArray();
            List<Merchant> mList = Merchants.ToList();
            List<Merchant> filteredList = new List<Merchant>();
            CheckValidRow(pageId, rowCount);
            //assign default value to rowCount if rowCount over MaxRows
            rowCount = rowCount > MaxRows ? 35 : rowCount;
            //check for negative page and row
            if (pageId < 1 || rowCount < 1) 
            {
                Merchants = filteredList.ToArray();
                TotalPages = 0;
                return filteredList;
            }
            
            int numPages = mList.Count / rowCount;
            int numRemainder = mList.Count % rowCount;
            int endIndex = (pageId * rowCount);// index to the last row within a page.
            int startIndex = endIndex - rowCount; // index to the starting row within a page.
           
            if (startIndex >= mList.Count ) // check for out of bound row index based on row count
            {               
                Merchants = filteredList.ToArray();
                TotalPages = 0;
                return filteredList;
            }
            if (numRemainder != 0)
                numPages++;// add one to total number of page
            
            TotalPages = numPages;

            if (endIndex > mList.Count) // adjust the end index
                endIndex = mList.Count; // startIndex + numRemainder

            for(int i = startIndex; i <endIndex; i++)
            {
                filteredList.Add(mList[i]);
            }
            Merchants = filteredList.ToArray();
            List<DataRow> rowList = GetAccountList(dTable, pageId, rowCount);
            return filteredList; 
        }

        public void CreateMerchant()
        {
            MerchantService.CreateMerchantAccount();
            Merchants = MerchantService.MerchantList.ToArray();
        }
        public void CreateMerchantAccounts(int x)
        {
            MerchantService.CreateMerchantAccounts(x);
            Merchants = MerchantService.MerchantList.ToArray();            
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RajProj.Models
{
    public class Merchant
    {
        public int ID { get; set; }
        public string MerhchantName { get; set; }
        public string Account { get; set; }
        [Display(Name = "Max Daily Amount")]
        public int MaxDailyTransactionAmount { get; set; }
        [Display(Name = "Min Daily Amount")]
        public int MinDailyTranAmount { get; set; }

    }
}

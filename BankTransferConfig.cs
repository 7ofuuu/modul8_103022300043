using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_103022300043
{
    public class BankTransferConfig
    {
        private const string ConfigPath = "bank_transfer_config.json";

        public string lang { get; set; }
        public Transfer transfer { get; set; }
        public List<string> methods {  get; set; } 
        public Confirmation confirmation { get; set; }


        public class Transfer
        {
            public int threshold { get; set; }
            public int low_fee { get; set; } 
            public int high_fee { get; set; } 
        }

        public class Confirmation
        {
            public string en { get; set; } = "yes";
            public string id { get; set; } = "ya";
        }


        public void setDefault()
        {
            BankTransferConfig bank = new BankTransferConfig();
            bank.lang = "en";
            bank.transfer.threshold = 25000000;
            bank.transfer.low_fee = 6500;
            bank.transfer.high_fee = 15000;
            bank.methods = ["RTO(real-time)", "SKIN", "RTGS", "BI FAST"];
            bank.confirmation.en = "yes";
            bank.confirmation.id = "ya";
        }

        public BankTransferConfig LoadConfig()
        {  
            string json = File.ReadAllText(ConfigPath);
            var data = JsonSerializer.Deserialize<BankTransferConfig>(json);return data;
        }

        public void SaveConfig()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(this, options);
            File.WriteAllText(ConfigPath, json);
        }
    }
}

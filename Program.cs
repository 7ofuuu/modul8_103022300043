using System;
using modul8_103022300043;

class Program
{
    static void Main()
    {
        BankTransferConfig config = new BankTransferConfig();
        BankTransferConfig data = config.LoadConfig();
        //Console.WriteLine($"{data.lang}");
        if (data.lang == "en")
        {
            Console.Write("Please insert the amount of money to transfer:");
        }
        else if (data.lang == "id")
        {
            Console.Write("Masukkan jumlah uang yang akan di-transfer: ");
        }

        int biayaTransfer;
        int jumlahUang = Convert.ToInt32(Console.ReadLine());
        int totalBiaya;

        if (jumlahUang <= data.transfer.threshold)
        {
            biayaTransfer = data.transfer.low_fee;
            totalBiaya = jumlahUang + biayaTransfer;
        }
        else if (jumlahUang > data.transfer.threshold)
        {
            biayaTransfer = data.transfer.high_fee;
            totalBiaya = jumlahUang + biayaTransfer;
        }

        if (config.lang == "en")
        {
            Console.WriteLine($"Transfer Fee = " );
        }
        else if (config.lang == "id")
        {
            Console.Write("Masukkan jumlah uang yang akan di-transfer: ");
        }
    }
}
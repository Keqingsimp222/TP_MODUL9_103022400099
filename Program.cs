using System;

class Program
{
    static void Main()
    {
        CovidConfig config = new CovidConfig();

        // ubah satuan (sesuai soal)
        config.UbahSatuan();

        Console.WriteLine($"Gunakan satuan {config.satuan_suhu}");

        // INPUT SUHU
        Console.Write("Berapa suhu badan anda saat ini? ");
        double suhu = Convert.ToDouble(Console.ReadLine());

        // INPUT HARI
        Console.Write("Berapa hari yang lalu anda terakhir memiliki gejala demam? ");
        int hari = Convert.ToInt32(Console.ReadLine());

        // 🔥 AUTO KONVERSI (INI YANG PENTING)
        double suhuC = suhu;

        if (config.satuan_suhu == "fahrenheit")
        {
            suhuC = (suhu - 32) * 5 / 9; // F → C
        }

        // VALIDASI
        bool suhuValid = (suhuC >= 36.5 && suhuC <= 37.5);
        bool hariValid = (hari < config.batas_hari_demam);

        Console.WriteLine("\n=== HASIL SCREENING ===");

        if (suhuValid && hariValid)
        {
            Console.WriteLine(config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(config.pesan_ditolak);
        }

        Console.ReadLine();
    }
}
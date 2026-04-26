using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

public class CovidConfig
{
    public string satuan_suhu { get; set; }
    public int batas_hari_demam { get; set; }
    public string pesan_ditolak { get; set; }
    public string pesan_diterima { get; set; }

    private string filePath = "covid_config.json";

    public CovidConfig()
    {
        LoadConfig();
    }

    public void LoadConfig()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            var data = JsonSerializer.Deserialize<Dictionary<string, string>>(json);

            // mapping CONFIG → nilai asli
            satuan_suhu = data["satuan_suhu"] == "CONFIG1" ? "celcius" : "celcius";
            batas_hari_demam = 14;
            pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
            pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
        }
        else
        {
            // default
            satuan_suhu = "celcius";
            batas_hari_demam = 14;
            pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
            pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
        }
    }

    public void UbahSatuan()
    {
        if (satuan_suhu == "celcius")
            satuan_suhu = "fahrenheit";
        else
            satuan_suhu = "celcius";

        Console.WriteLine($"Satuan diubah menjadi: {satuan_suhu}");
    }
}
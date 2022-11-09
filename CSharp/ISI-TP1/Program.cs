using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ISI_TP1
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = @"../../Files/csv_files/chip_dataset.csv";

            List<Vendor> Vendors = ReadChips(file);

            writeJSON(Vendors);

            Console.WriteLine("Finished..");
            Console.ReadLine();
        }

        #region Leitura do ficheiro com a lista de chips e armazenamento separado por fabricante
        static List<Vendor> ReadChips(string file)
        {
            NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-GB");               // Necessário para conseguir converter os números decimais separados por "."

            List<Vendor> Vendors = new List<Vendor>();

            string regularExpression = @"[0-9]+,[^,]*,(GPU|CPU),[0-9]{4}-[0-9]{2}-[0-9]{2}(,[0-9]*[.]?[0-9]*)+[^,]*,[^,]*(,[0-9]*[.]?[0-9]*)+";

            Regex regex = new Regex(regularExpression);
            using (StreamReader reader = new StreamReader(file))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    Match match = regex.Match(line);
                    if (match.Success)
                    {
                        Vendor vendor = new Vendor();
                        Chip chip = new Chip();
                        string[] campos = match.Value.Split(',');

                        chip.Product = campos[1];
                        chip.Type = campos[2];
                        chip.ReleaseDate = DateTime.Parse(campos[3]);
                        if (decimal.TryParse(campos[4], style, culture, out decimal result4)) chip.ProcessSize = result4;
                        else chip.ProcessSize = 0;
                        if (decimal.TryParse(campos[5], style, culture, out decimal result5)) chip.TDP = result5;
                        else chip.TDP = 0;
                        if (decimal.TryParse(campos[6], style, culture, out decimal result6)) chip.DieSize = result6;
                        else chip.DieSize = 0;
                        if (decimal.TryParse(campos[7], style, culture, out decimal result7)) chip.Transistors = result7;
                        else chip.Transistors = 0;
                        if (decimal.TryParse(campos[8], style, culture, out decimal result8)) chip.Frequency = result8;
                        else chip.Frequency = 0;
                        chip.Foundry = campos[9];
                        vendor.Name = campos[10];
                        if (decimal.TryParse(campos[11], style, culture, out decimal result11)) chip.FP16 = result11;
                        else chip.FP16 = 0;
                        if (decimal.TryParse(campos[12], style, culture, out decimal result12)) chip.FP32 = result12;
                        else chip.FP32 = 0;
                        if (decimal.TryParse(campos[13], style, culture, out decimal result13)) chip.FP64 = result13;
                        else chip.FP64 = 0;

                        if (Vendors.Any(x => x.Name == vendor.Name))
                        {
                            int position = Vendors.FindIndex(p => p.Name == vendor.Name);
                            Vendors[position].Chips.Add(chip);
                        }
                        else
                        {
                            List<Chip> Chips = new List<Chip>();
                            Chips.Add(chip);
                            vendor.Chips = Chips;
                            Vendors.Add(vendor);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Linha Inválida: {line}");
                    }
                }
            }
            Console.WriteLine("\nCSV file read sucessfully!");
            return Vendors;
        }
        #endregion

        #region Escrita dos dados em ficheiro JSON
        static void writeJSON(List<Vendor> Vendors)
        {
            string file = @"../../../../Kettle/chip_dataset.json";

            var opt = new JsonSerializerOptions() { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize<IList<Vendor>>(Vendors, opt);
            try{ File.WriteAllText(file, "{\"data\":" + jsonString + "}"); }
            catch { Console.WriteLine("\nPath not found"); }
            Console.WriteLine("\nJSON file successfully written!\n");
        }
        #endregion
    }
}

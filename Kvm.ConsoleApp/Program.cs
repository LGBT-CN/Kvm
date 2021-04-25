using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Kvm.Analyser;

namespace Kvm.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = JsonSerializer.Deserialize<List<ParseItemModel>>(
                File.ReadAllText(
                    args.Length > 0
                        ? string.IsNullOrWhiteSpace(args[0])
                            ? "config.json"
                            : args[0]
                        : "config.json"
                )
            );

            if (list == null)
            {
                Shared.Log.E("Cannot deserialise config!");
                return;
            }

            foreach (var i in list)
            {
                try
                {
                    i.Parse();
                }
                catch (Exception ex)
                {
                    Shared.Log.E($"Cannot parse {i.OutPath}\n{ex.Message}");
                }
            }
        }
    }
}
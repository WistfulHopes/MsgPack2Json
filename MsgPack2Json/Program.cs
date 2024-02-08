// See https://aka.ms/new-console-template for more information

using System.Buffers;
using System.Globalization;
using System.Text;
using MessagePack;
using MessagePack.Formatters;
using Newtonsoft.Json;

namespace MsgPack2Yml;

internal class Program
{
    private static void Main(string[] args)
    {
        if (args.Length <= 2)
        {
            Console.WriteLine("Invalid arguments.");
            Console.WriteLine("MsgPack2Json json <input.msg> <output.json>");
            Console.WriteLine("MsgPack2Json msg <input.json> <output.msg>");
            return;
        }

        if (!File.Exists(args[1]))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        switch (args[0])
        {
            case "json":
            {
                var bin = File.ReadAllBytes(args[1]);
        
                File.WriteAllText(args[2], MessagePackSerializer.ConvertToJson(bin));
                break;
            }
            case "msg":
            {
                var json = File.ReadAllText(args[1]);
        
                File.WriteAllBytes(args[2], MessagePackSerializer.ConvertFromJson(json));
                break;
            }
            default:
                Console.WriteLine("Invalid arguments.");
                Console.WriteLine("MsgPack2Json json <input.msg> <output.json>");
                Console.WriteLine("MsgPack2Json msg <input.json> <output.msg>");
                return;
        }
    }
}
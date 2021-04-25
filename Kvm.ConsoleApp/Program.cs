using System;
using System.Collections.Generic;
using System.IO;
using Kvm.Analyser;

namespace Kvm.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ParseItemModel> list = new();

            list.AddRange(new[]
            {
                new ParseItemModel()
                {
                    ModelPath= "in\\model\\index.kvm",
                    PropPath = "in\\data\\zh.txt",
                    OutPath = "out\\index_zhcn.html"
                },
                new ParseItemModel()
                {
                    ModelPath= "in\\model\\index.kvm",
                    PropPath = "in\\data\\tw.txt",
                    OutPath = "out\\index_zhtw.html"
                },
                new ParseItemModel()
                {
                    ModelPath= "in\\model\\index.kvm",
                    PropPath = "in\\data\\en.txt",
                    OutPath = "out\\index_engb.html"
                }
            });

            foreach (var i in list)
            {
                i.Parse();
            }

        }
    }
}
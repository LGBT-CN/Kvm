using System;

namespace Kvm.Log
{
    public class Default : IKLog
    {
        public void W(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[W {DateTime.Now.ToLocalTime().ToString()}] {msg}");
            Console.ResetColor();
        }

        public void I(string msg)
        {
            Console.Error.WriteLine($"[I {DateTime.Now.ToLocalTime().ToString()}] {msg}");
            Console.ResetColor();
        }

        public void E(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Error.WriteLine($"[E {DateTime.Now.ToLocalTime().ToString()}] {msg}");
            Console.ResetColor();
        }
    }
}
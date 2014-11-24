using System;
using GemBox.Document;

namespace Word.GemBox.Test {
    internal class Program {
        private static void Main(string[] args) {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            ComponentInfo.FreeLimitReached += ComponentInfo_FreeLimitReached;

            Console.ReadLine();
        }

        static void ComponentInfo_FreeLimitReached(object sender, FreeLimitEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
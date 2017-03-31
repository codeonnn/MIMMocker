using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MIM_Mocker
{
    class Program
    {
        private static readonly ProxyController Controller = new ProxyController();

        public static void Main(string[] args)
        {
            //On Console exit make sure we also exit the proxy
            NativeMethods.Handler = ConsoleEventCallback;
            NativeMethods.SetConsoleCtrlHandler(NativeMethods.Handler, true);

            Controller.StartProxy();

            Console.WriteLine("Hit any key to shutdown MIM Mocker proxy server.");
            Console.WriteLine();
            Console.Read();

            Controller.Stop().Wait();
        }

        private static bool ConsoleEventCallback(int eventType)
        {
            if (eventType != 2) return false;
            try
            {
                Controller.Stop();
            }
            catch
            {
                // ignored
            }
            return false;
        }
    }

    internal static class NativeMethods
    {
        // Keeps it from getting garbage collected
        internal static ConsoleEventDelegate Handler;

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool SetConsoleCtrlHandler(ConsoleEventDelegate callback, bool add);

        // Pinvoke
        internal delegate bool ConsoleEventDelegate(int eventType);
    }
}

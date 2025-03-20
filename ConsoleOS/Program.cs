using System.Runtime;
using System.Runtime.InteropServices;

unsafe class Program
{
    static void Main() { }

    public static void ThreadTest()
    {
        //Console.WriteLine("Thread started");
        //Console.WriteLine("Thread ended");

        //for (int i = 0; i < 1000000000; i++)
        //{
        //}
    }

    /*
     * Minimum system requirement:
     * 1024MiB of RAM
     * Memory Map:
     * 256 MiB - 512MiB   -> System
     * 512 MiB - ∞     -> Free to use
     */
    //Check out Kernel/Misc/EntryPoint.cs
    [UnmanagedCallersOnly(EntryPoint = "KMain")]
    static void KMain() 
    {
        //Console.Clear();
        //Console.WriteLine("Now you are in MOOS-ConsoleOS!");
        //for(; ; ) 
        //{
        //    Console.Write("CMD>> ");
        //    string s = Console.ReadLine();

        //    if (string.IsNullOrEmpty(s)) continue;

        //    switch (s.ToLower())
        //    {
        //        case "help":
        //            Console.WriteLine("help - Show this message");
        //            Console.WriteLine("clear - Clear the screen");
        //            Console.WriteLine("exit - Exit the console");
        //            break;
        //        case "clear":
        //            Console.Clear();
        //            break;
        //        case "shutdown":
        //            Console.WriteLine("Shutting down...");
        //            Power.Shutdown();
        //            break;
        //        case "reboot":
        //            Console.WriteLine("Rebooting...");
        //            Power.Reboot();
        //            break;
        //        case "test":
        //            Thread test = new Thread(() =>
        //            {

        //            });
        //            test.Start();
        //            break;
        //        default:
        //            Console.WriteLine("Command not found: " + s);
        //            break;
        //    }
        //}
    }
}
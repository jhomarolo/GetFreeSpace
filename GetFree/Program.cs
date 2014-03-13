using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace GetFree
{
    class Program
    {
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetDiskFreeSpaceEx(string lpDirectoryName,
           out ulong lpFreeBytesAvailable,
           out ulong lpTotalNumberOfBytes,
           out ulong lpTotalNumberOfFreeBytes);

        static void Main(string[] args)
        {

            ulong FreeBytesAvailable;
            ulong TotalNumberOfBytes;
            ulong TotalNumberOfFreeBytes;

            bool success = GetDiskFreeSpaceEx(@"c:\\",
                                              out FreeBytesAvailable,
                                              out TotalNumberOfBytes,
                                              out TotalNumberOfFreeBytes);
            if (!success)
                throw new System.ComponentModel.Win32Exception();

            Console.WriteLine("Total numero de bytes livres:      {0,15:D}", FreeBytesAvailable);
            Console.WriteLine("Total numero de bytes existentes:     {0,15:D}", TotalNumberOfBytes);
            Console.WriteLine("Total numero de bytes livres e desalocados: {0,15:D}", TotalNumberOfFreeBytes);

            Console.ReadLine();
        }

      

      


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive
{
    internal class Drives
    {
        public static List<System.IO.DriveInfo> disks = new List<System.IO.DriveInfo>();
        public static List<string> paths = new List<string>();
        public static List<string> lastPath = new List<string>();
        public static int Drivers()
        {
            int ct = 0;
            lastPath.Clear();
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                if (d.IsReady == true)
                {
                    Console.WriteLine($"    {d.Name}      {d.TotalSize} bytes");
                }
                else
                {
                    Console.WriteLine($"    {d.Name}");
                }
                ct++;
                disks.Add(d);
            }
            return ct;
        }

        public static void getDrivers(string path)
        {
            try{
                lastPath.Add(path);
                paths.Clear();
                string[] dirs = Directory.GetDirectories(path);
                string[] files = Directory.GetFiles(path);
                foreach (string s in dirs)
                {
                    Console.WriteLine($"    {s}");
                    paths.Add(s);
                }
                if (files.Length != 0)
                {
                    foreach (string s in files)
                    {
                        Console.WriteLine($"    {s}");
                        paths.Add(s);
                    }
                }
                

            }
            catch (IOException)
            {

            }
            
        }


    }
}

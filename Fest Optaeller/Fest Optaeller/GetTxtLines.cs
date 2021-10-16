using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Fest_Optaeller
{
    static class GetTxtLines
    {
        static string txtName = "people.txt";

        // Returns all lines of the file named txtName that is on the same directory as the .exe file
        // //Returns null if the file doesn't exist
        // Throws exception if the file doesn't exist
        public static string[] ReadTxtLines()
        {
            string txtFilePath = string.Format("{0}/{1}", new DirectoryInfo(".").FullName, txtName);

            try
            {
                return File.ReadAllLines(txtFilePath);
            }
            catch (FileNotFoundException e)
            {
                throw new ArgumentException(string.Format("File named: {0} needs to exist", txtName));
                //return null;
            }
        }
    }
}

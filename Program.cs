using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
namespace Question_Two
{
    class Program
    {
        static void Main(string[] args)
        {
            //string variable declaration
            string fileData;

            //try...catch decalartion
            try {
         
                //creating new stream reader object and text file
                StreamReader mySR = new StreamReader("Covid-19.txt");

                //assigning string variable with text file string
                fileData = mySR.ReadToEnd();

                //displaying text file as is
                Console.WriteLine("This is from the Covid-19.txt file:\n");
                Console.WriteLine(fileData);

                //regex to replace unnecessary/unwanted tags, forward-slashes and text between tags, with blank spaces
                Regex myRegExOne = new Regex(@"<.*?>|&.*?;");
                string textResult = myRegExOne.Replace(fileData, "");

                //regex to remove unnecessay white spaces, from multiple lines at once
                string finalResult = Regex.Replace(textResult, @"^\s+$[\r\n]*", @"", RegexOptions.Multiline);

                Console.WriteLine("");
                Console.WriteLine("This is being written into the Covid-20.txt file:\n");
                Console.WriteLine(finalResult);

                //creating new file path
                string newFilePath = @"Covid-20.txt";

                //if file path does not exist
                if (!File.Exists(newFilePath)) {
                    //using stream writer, create a new textfile
                    using (StreamWriter writer = File.CreateText(newFilePath))
                    {
                        //write final result of necessary text only, to new textfile
                        writer.WriteLine(finalResult);
                    }
                }

                //close file path
                mySR.Close();
                Console.ReadLine();

            }//catch exceptions
            catch (Exception Ex) {
                //display exceptions
                Console.WriteLine(Ex);
            }

            Console.Read();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourament_library.Models;

namespace Tourament_library.DataAccess.Convert
{
    // * load the text file
    // * convert the text to prizes=list<prize model>
    // find the max ID
    // add the new record (id+1)
    //convert convert prizes to list<string>
    // save the list as text
    public static class textFileProcessor
    {
        public static string getFullpath(this string fileName)//prizeModel.csv //this. help to make it 
            //as extension so when we call it (getFullpath.String)
        {
            return $"{ConfigurationManager.AppSettings["filePath"]}\\{fileName}";
        }

        ///// take the full file path and load that string
        public static List<string> loadFile(this string file) {
            if (!File.Exists(file))
            {
                return  new List<string>();
            }
            return File.ReadAllLines(file).ToList() ;
        }
        public static List<person> convertToPeopleModel(this List<string> lines)
        {
            List<person> output = new List<person>();
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                person p = new person();
                p.id = int.Parse(parts[0]);
                p.name = parts[1];
                p.lastName = parts[2];
                p.email = parts[3];
                p.phone = parts[4];
                output.Add(p);


            }
            return output;


        }
        public static List<PrizeModel> convertToPrizeModel(this List<string> lines) {
            List<PrizeModel> output = new List<PrizeModel>();
            foreach (string line in lines) {
                string[] parts = line.Split(',');
                PrizeModel p= new PrizeModel();
                p.id = int.Parse(parts[0]);
                p.placeName= parts[1];
                p.prizeAmount= int.Parse(parts[2]);
                p.prizePercentage = float.Parse(parts[3]);
                p.placeNumber = int.Parse(parts[4]);
                output.Add(p);


            }
            return output ;


        }
        /// <summary>
        /// it convert the model into a list of string than it add element of the model
        /// to the list string with "," in bett
        /// </summary>
        /// <param name="List of models"></param>
        /// <param name="file Name"></param>
        public static void savePrizeToTextfile(this List<PrizeModel> Models,string fileName) {

            List<string> lines = new List<string>();
           
            foreach (PrizeModel p in Models) {

                lines.Add($"{p.id},{p.placeName},{p.prizeAmount},{p.prizePercentage},{p.placeNumber}");

            }
            string s = fileName.getFullpath();
            
            File.WriteAllLines(fileName.getFullpath(), lines);
            
            

        }
        public static void savePeoplesToTextfile(this List<person> persons, string fileName)
        {

            List<string> lines = new List<string>();

            foreach (person p in persons)
            {

                lines.Add($"{p.id},{p.name},{p.lastName},{p.email},{p.phone}");

            }
            string s = fileName.getFullpath();

            File.WriteAllLines(fileName.getFullpath(), lines);



        }






    }
}

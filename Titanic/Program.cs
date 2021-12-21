// Jacob Coomer - Titanic ML model
// This program predicts the survival of ~400 titanic passengers 

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TitanicML.Model;

namespace Titanic
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new ModelInput();

            int i = 0;
            string[] tempFile = File.ReadAllLines(@"C:\Users\shamp\Desktop\TitanicML\Titanic\TestTitanic.csv"); // read in passengers to test
            List<string> fullFile = tempFile.ToList();
            fullFile.RemoveAt(0);
            foreach (string s in fullFile) { Console.WriteLine(s); }
            int[] ID = new int[fullFile.Count];
            int[] survived = new int[fullFile.Count];


            foreach (string passenger in fullFile) // split, create, and run the model for each passenger
            {
                Console.WriteLine($"Started to parse Passenger {i}");
                string[] splitPass = passenger.Split(",");
                var passengerInput = new ModelInput();

                passengerInput.PassengerId = (float)(int.Parse(splitPass[0]));
                passengerInput.Pclass = (float)(int.Parse(splitPass[1]));
                passengerInput.Sex = splitPass[4];
                try
                { passengerInput.Age = float.Parse(splitPass[5]); }
                catch
                {
                    passengerInput.Age = 25f;
                }
                passengerInput.SibSp = (float)(int.Parse(splitPass[6]));
                passengerInput.Parch = (float)(int.Parse(splitPass[7]));
                passengerInput.Ticket = splitPass[8];
                try
                { passengerInput.Fare = float.Parse(splitPass[9]); }
                catch
                { passengerInput.Fare = 80f; }

                ID[i] = (int)passengerInput.PassengerId;

                ModelOutput life = ConsumeModel.Predict(passengerInput);

                if (life.Score > .5f)
                {
                    survived[i] = 1;
                }
                else
                {
                    survived[i] = 0;
                }
                i++;
            }
            for (int j = 0; j < ID.Length; j++)  // print model output for each passenger
            {
                Console.WriteLine($"Passenger: {ID[j]} Survived: {survived[j]}");
            }

            using StreamWriter titanic = new("TitanicPredictions.txt");  // write to file to upload to kaggle
            titanic.WriteLine("PassengerID,Survived");
            for (int j = 0; j < ID.Length; j++)
            {
                titanic.WriteLine($"{ID[j]},{survived[j]}");
            }
            titanic.Close();
        }
    }
}

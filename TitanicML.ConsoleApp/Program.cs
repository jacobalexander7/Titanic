
using System;
using TitanicML.Model;

namespace TitanicML.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create single instance of sample data from first line of dataset for model input
            ModelInput sampleData = new ModelInput()
            {
                Pclass = 3F,
                Sex = @"male",
                Age = 22F,
                SibSp = 1F,
                Parch = 0F,
                Fare = 7.25F,
                Embarked = @"S",
            };

            // Make a single prediction on the sample data and print results
            var predictionResult = ConsumeModel.Predict(sampleData);

            Console.WriteLine("Using model to make single prediction -- Comparing actual Survived with predicted Survived from sample data...\n\n");
            Console.WriteLine($"Pclass: {sampleData.Pclass}");
            Console.WriteLine($"Sex: {sampleData.Sex}");
            Console.WriteLine($"Age: {sampleData.Age}");
            Console.WriteLine($"SibSp: {sampleData.SibSp}");
            Console.WriteLine($"Parch: {sampleData.Parch}");
            Console.WriteLine($"Fare: {sampleData.Fare}");
            Console.WriteLine($"Embarked: {sampleData.Embarked}");
            Console.WriteLine($"\n\nPredicted Survived: {predictionResult.Score}\n\n");
            Console.WriteLine("=============== End of process, hit any key to finish ===============");
            Console.ReadKey();
        }
    }
}

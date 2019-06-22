using System;
using System.Linq;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 }, 
                new[] { 2, 8 }, 
                new[] { 5, 2 }, 
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" }, 
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 }, 
                new[] { 2, 8, 5, 1 }, 
                new[] { 5, 2, 4, 4 }, 
                new[] { "tFc", "tF", "Ftc" }, 
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 }, 
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 }, 
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 }, 
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" }, 
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            int[] dietPlanValues = new int[dietPlans.Length];
            int[] cal = new int[protein.Length];
            for (int i = 0; i < protein.Length; i++)
                cal[i] = protein[i] * 5 + carbs[i] * 5 + fat[i] * 9;
            for (int i = 0; i < dietPlans.Length; i++)
            {
				int min, max;
                List<int> tempDiet = new List<int>();
                var numList = Enumerable.Range(0, protein.Length).ToList();
                for (int j = 0; j < dietPlans[i].Length; j++)
                {
                    tempDiet = new List<int>();
                    if (dietPlans[i][j] == 'C')
                    {
                        max = carbs[numList[0]];
                        foreach (int k in numList)
                            if (max < carbs[k])
                                max = carbs[k];
                        foreach (int k in numList)
                            if (max == carbs[k])
                                tempDiet.Add(k);
                    }
                    else if (dietPlans[i][j] == 'c')
                    {
                        min = carbs[numList[0]];
                        foreach (int k in numList)
                            if (min > carbs[k])
                                min = carbs[k];
                        foreach (int k in numList)
                            if (min == carbs[k])
                                tempDiet.Add(k);
                    }
                    else if (dietPlans[i][j] == 'P')
                    {
                        max = protein[numList[0]];
                        foreach (int k in numList)
                            if (max < protein[k])
                                max = protein[k];
                        foreach (int k in numList)
                            if (max == protein[k])
                                tempDiet.Add(k);
                    }
                    else if (dietPlans[i][j] == 'p')
                    {
                        min = protein[numList[0]];
                        foreach (int k in numList)
                            if (min > protein[k])
                                min = protein[k];
                        foreach (int k in numList)
                            if (min == protein[k])
                                tempDiet.Add(k);
                    }
                    else if (dietPlans[i][j] == 'F')
                    {
                        max = fat[numList[0]];
                        foreach (int k in numList)
                            if (max < fat[k])
                                max = fat[k];
                        foreach (int k in numList)
                            if (max == fat[k])
                                tempDiet.Add(k);
                    }
                    else if (dietPlans[i][j] == 'f')
                    {
                        min = fat[numList[0]];
                        foreach (int k in numList)
                            if (min > fat[k])
                                min = fat[k];
                        foreach (int k in numList)
                            if (min == fat[k])
                                tempDiet.Add(k);
                    }
                    else if (dietPlans[i][j] == 'T')
                    {
                        max = cal[numList[0]];
                        foreach (int k in numList)
                            if (max < cal[k])
                                max = cal[k];
                        foreach (int k in numList)
                            if (max == cal[k])
                                tempDiet.Add(k);
                    }
                    else if (dietPlans[i][j] == 't')
                    {
                        min = cal[numList[0]];
                        foreach (int k in numList)
                            if (min > cal[k])
                                min = cal[k];
                        foreach (int k in numList)
                            if (min == cal[k])
                                tempDiet.Add(k);
                    }
                    if (tempDiet.Count == 1)
                        break;
                    numList = tempDiet;
                }
                if (dietPlans[i] == "")
                    dietPlanValues[i] = 0;
                else
                    dietPlanValues[i] = tempDiet[0];
            }
            return dietPlanValues;
            throw new NotImplementedException();
        }
    }
}

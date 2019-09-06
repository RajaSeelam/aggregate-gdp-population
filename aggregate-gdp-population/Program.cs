using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace aggregate_gdp_population
{
public class Program
    {

        public static void Main(string[] args) { }

        public static void GDP()
        {
            Dictionary<string, string[]> cont_ref = new Dictionary<string, string[]>();
            cont_ref.Add("Asia", new string[]{ "Saudi Arabia", "China", "India", "Indonesia", "Japan","Republic of Korea", "Russia","Turkey" });
            cont_ref.Add("South America", new string[] { "Argentina", "Brazil"});
            cont_ref.Add("Oceania", new string[] {"Australia"});
            cont_ref.Add("North America", new string[] { "Canada", "USA", "Mexico" });
            cont_ref.Add("Europe", new string[]{"Italy","Germany","United Kingdom", "France"});
            cont_ref.Add("Africa", new string[]{"South Africa"});
            string[] Continents = cont_ref.Keys.ToArray();


            Dictionary<string, double[]> ans_dict = new Dictionary<string, double[]>();
            ans_dict.Add("South America",new double[] { 0, 0 });
            ans_dict.Add("Oceania",new double[] { 0, 0 });
            ans_dict.Add("North America",new double[] { 0, 0 });
            ans_dict.Add("Asia", new double[] { 0, 0 });
            ans_dict.Add("Europe",new double[] { 0, 0 });
            ans_dict.Add("Africa", new double[] { 0, 0 });

            string gdp = "GDP_2012";
            string pop = "POPULATION_2012";

            Console.WriteLine(gdp);

            string _string = "../../../../datafile.csv";
            string[] csv_lines = File.ReadAllLines(_string);
            
            int No_lines = csv_lines.Length;

            for(int i=1;i<No_lines;i++)
            {
                
                string[] Base_row=csv_lines[i].Split(",");
                Base_row[0]=Base_row[0].Replace("\"",string.Empty);
                Base_row[4] = Base_row[4].Replace("\"", string.Empty);
                Base_row[7] = Base_row[7].Replace("\"", string.Empty);
                string country = Base_row[0];

                for (int j = 0; j < Continents.Length;j++)
                {
                    string[] countries_data = new string[14];
                    countries_data=(cont_ref[Continents[j]] );

                    if(countries_data.Contains(country))
                    {
                        ans_dict[Continents[j]][0] = ans_dict[Continents[j]][0]+Convert.ToDouble( Base_row[7] );
                        ans_dict[Continents[j]][1] = ans_dict[Continents[j]][1] +Convert.ToDouble(Base_row[4] );
                    }
                }
            }

            Dictionary<string, Dictionary<string, double>> final = new Dictionary<string, Dictionary<string, double>>();

            Dictionary<string, double> mini= new Dictionary<string, double>();
            Dictionary<string, double> mini1 = new Dictionary<string, double>();
            Dictionary<string, double> mini2 = new Dictionary<string, double>();
            Dictionary<string, double> mini3 = new Dictionary<string, double>();
            Dictionary<string, double> mini4 = new Dictionary<string, double>();
            Dictionary<string, double> mini5 = new Dictionary<string, double>();

            mini.Add(gdp, ans_dict["South America"][0]);
            mini.Add(pop, ans_dict["South America"][1]);

            mini1.Add(gdp, ans_dict["Oceania"][0]);
            mini1.Add(pop, ans_dict["Oceania"][1]);


            mini2.Add(gdp, ans_dict["North America"][0]);
            mini2.Add(pop, ans_dict["North America"][1]);

            mini3.Add(gdp, ans_dict["Asia"][0]);
            mini3.Add(pop, ans_dict["Asia"][1]);

            mini4.Add(gdp, ans_dict["Europe"][0]);
            mini4.Add(pop, ans_dict["Europe"][1]);

            mini5.Add(gdp, ans_dict["Africa"][0]);
            mini5.Add(pop, ans_dict["Africa"][1]);

            final.Add("South America", mini);
            final.Add("Oceania", mini1);
            final.Add("North America", mini2);
            final.Add("Asia", mini3);
            final.Add("Europe", mini4);
            final.Add("Africa", mini5);

            string output = JsonConvert.SerializeObject(final, Formatting.Indented);
            output=output.Replace("[", "{");
            output = output.Replace("]", "}");


            System.IO.File.WriteAllText("../../../../obtained_output.json", output);

        }
    }
}

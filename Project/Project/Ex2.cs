using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Ex2
    {
        private string[] textFile;
        private Dictionary<string,List<int>> map;
        private List<(string, int)> retour;
        public Ex2()
        {
            textFile = System.IO.File.ReadAllLines("Ex2.txt");
            map = new Dictionary<string, List<int>>();
            retour = new List<(string, int)>();
        }
        private void Mapping()
        {
            List<Dictionary<string, int>> valuePairs = new List<Dictionary<string, int>>();
            Parallel.For(0, textFile.Length, i =>
              {
                  string text = textFile[i];
                  string[] values = text.Split(" ");
                  Dictionary<string, int> classifiedlist = new Dictionary<string, int>();
                  foreach (string value in values)
                  {
                      if (classifiedlist.ContainsKey(value))
                      {
                          classifiedlist[value] += 1;
                      }
                      else
                      {
                          classifiedlist.Add(value, 1);
                      }
                  }
                  valuePairs.Add(classifiedlist);
                  
                  Parallel.ForEach(classifiedlist, (CurrentKey) =>
                   {
                        lock(map)
                        {
                            if (map.ContainsKey(CurrentKey.Key))
                            {
                                map[CurrentKey.Key].Add(CurrentKey.Value);
                            }
                            else
                            {
                                map.Add(CurrentKey.Key, new List<int> { CurrentKey.Value });
                            }
                        }
                       
                   });
                  
              });
        }
        private void Reducing()
        {
            if (map!= null)
            {
                Parallel.ForEach(map, (CurrentKey) =>
                 {
                     int sum = 0;
                     foreach(int i in CurrentKey.Value)
                     {
                         sum += i;
                     }
                     (string, int) testvalue = (CurrentKey.Key, sum);
                     lock(retour)
                     {
                        retour.Add(testvalue);
                     }
                     
                 });
            }
        }
        public List<(string, int)> Run()
        {
            Mapping();
            Reducing();
            return retour;
        }
        public List<(string, int)> Retour { get => retour; set => retour = value; }
    }
}

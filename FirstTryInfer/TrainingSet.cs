using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using MicrosoftResearch.Infer.Maths;

namespace FirstTryInfer
{
  public  class TrainingSet
    {
        public Vector[] FeatureVectors;
        public string[] Labels;

        private static double[] predsum = new double[10]; //array, which keep avg value to each attribute, that could be unknown

        public TrainingSet(int n)
        {
            FeatureVectors = new Vector[n];
            Labels = new string[n];
        }

      /*method write data from file to array
       * path - full path to the file
       * delimeter - delimeter, which is used in the file
       * mode - boolean value, which means (if true) do we need calculate and use the unknown value or only use it
       * */

        public void setData(string path,char delimeter,bool mode)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                for (int i = 0; i < Labels.Length; i++)
                {
                    string curstr = reader.ReadLine();
                    if (curstr == null) break;
                    string[] curArr = curstr.Split(delimeter);

                    //read data from file to FeatureVectors и Labels

                    //normalize "Num" data
                    Labels[i] = (curArr[13] == "0") ? "absent" : "present";

                    double[] dvector = new double[13]; //all attributes in one line of source file
                    for (int j = 0; j < 13; j++)
                    {
                        if (mode)
                        {
                            //if the value is known keep it to the array and add it to predsum array
                            //else use the avg value, which is resualt of previous data
                            if (curArr[j] != "?")
                            {
                                dvector[j] = Convert.ToDouble(curArr[j].Replace(".", ","));
                                if (j > 2) predsum[j - 3] += dvector[j];
                            }
                            else
                            {
                                dvector[j] =Math.Round(predsum[j - 3] / i);
                                predsum[j - 3] += dvector[j];
                            }
                        }
                        else
                        {
                            if (curArr[j] != "?") dvector[j]=Convert.ToDouble(curArr[j].Replace(".", ","));
                            else dvector[j] = predsum[j - 3];
                        }                        
                    }

                    FeatureVectors[i] = Vector.FromArray(dvector, Sparsity.Sparse);

                }

                //if the sums was calculated, calculate the avg values
                if (mode)
                {
                    for (int j = 0; j < predsum.Length; j++)
                    {
                        predsum[j] = Math.Round(predsum[j] / Labels.Length);
                       // Console.WriteLine("j: " + j + " avg: " + predsum[j]);
                    }
                }
            }
        }


    }
}

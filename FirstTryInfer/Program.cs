using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicrosoftResearch.Infer.Models;
using MicrosoftResearch.Infer;
using MicrosoftResearch.Infer.Distributions;

namespace FirstTryInfer
{

    enum cpEnum
    {

        typical_angina = 1,
        atypical_angina,
        nonAnginal_pain,
        asymptomatic
    }

    enum restecgEnum
    {
        normal,
        StT_wave_obnormality,
        left_ventricular_hypertrophy_by_estes_criteria
    }

    enum slopeEnum
    {
        upsloping = 1,
        flat,
        downsloping
    }

    enum thalEnum
    {
        normal = 3,
        fixed_defect = 6,
        reversable_defect = 7
    }

    class Program
    {

        static void Main(string[] args)
        {
           /* Vector[] cpVec = new Vector("typical_angina",
        "atypical_angina",
        "nonAnginal_pain",
        "asymptomatic");*/
/*

            Variable<int> age = Variable.Poisson(0.1250);
            Variable<bool> sex = Variable.Bernoulli(0.5);
            Variable<Enum> cp = Variable.New<Enum>();//?????

            

            //Variable<int> icp = Variable.EnumToInt();

            Variable<int> trestbps = Variable.Poisson(0.4310);
            Variable<int> chol = Variable.Poisson(0.5);
            Variable<bool> fbs = Variable.Bernoulli(0.0663);
            Variable<Enum> restecg = Variable.New<Enum>();///????
            Variable<int> thalach = Variable.Poisson(0.5);
            Variable<bool> exang = Variable.Bernoulli(0.2868);
            Variable<double> oldpeak = Variable.GammaFromMeanAndVariance(0,4);
            Variable<Enum> slope = Variable.New<Enum>();
            double[] val = { 0, 1, 2, 3 };
            Variable<int> ca = Variable.Discrete(val);
            Variable<Enum> thal = Variable.New<Enum>();
            Variable<bool> num = Variable.Bernoulli(0.7);


        //DiscreteEnum<cpEnum>();

            InferenceEngine ie = new InferenceEngine();
            Console.WriteLine(ie.Infer(age));
 * 
 * /*/
            Classiffier.Run();

            Console.ReadLine();
        }
    }
}

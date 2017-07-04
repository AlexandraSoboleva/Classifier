using System;
using System.Collections.Generic;
using System.Linq;
using MicrosoftResearch.Infer.Factors;
using MicrosoftResearch.Infer.Maths;
using MicrosoftResearch.Infer.Learners;
using MicrosoftResearch.Infer.Learners.Mappings;

namespace FirstTryInfer
{
    class Classiffier
    {
        public static void Run()
        {
            //Training
            TrainingSet trainingSet = new TrainingSet(303);
            string path = @"D:\8-доп_курсы\helix\projects\FirstTryInfer\FirstTryInfer\Cleveland.txt";
            trainingSet.setData(path, ',',true);

            var mapping = new ClassifierMapping();
            var classifier = BayesPointMachineClassifier.CreateBinaryClassifier(mapping);

            classifier.Train(trainingSet.FeatureVectors, trainingSet.Labels);

            //Incremental Training

            trainingSet = new TrainingSet(294);
            path = @"D:\8-доп_курсы\helix\projects\FirstTryInfer\FirstTryInfer\hungarian.txt";
            trainingSet.setData(path, ',', false);

            //thrown execption MicrosoftResearch.Infer.Learners.BayesPointMachineClassifierException" в Infer.Learners.Classifier.dll
            //Дополнительные сведения: The class labels must not change.
            
            //classifier.TrainIncremental(trainingSet.FeatureVectors, trainingSet.Labels);

            //TestSet
            double[] testSetArr = new double[13] { 63,1,4,140,260,0,1,112,1,3,2,1,5 };
            TrainingSet testSet = new TrainingSet(1);
            testSet.FeatureVectors[0] = Vector.FromArray(testSetArr, Sparsity.Sparse);

            //Prediction

            IEnumerable<IDictionary<string, double>> predictions = classifier.PredictDistribution(testSet.FeatureVectors);

            foreach (Dictionary<string, double> pred in predictions)
            {

                Console.WriteLine("present " + pred["present"]);
                Console.WriteLine("absent " + pred["absent"]);
            }

            IEnumerable<string> estimate = classifier.Predict(testSet.FeatureVectors);
            foreach (string est in estimate)
            {
                Console.WriteLine(est);
            }

            //Evaluation

            var evaluatorMapping = mapping.ForEvaluation();
            var evaluator = new ClassifierEvaluator<IList<Vector>, int, IList<string>, string>(evaluatorMapping);

            path = @"D:\8-доп_курсы\helix\projects\FirstTryInfer\FirstTryInfer\switzerland.txt";
            testSet = new TrainingSet(123);
            testSet.setData(path, ',',false);
 
            var predictionDist = classifier.PredictDistribution(testSet.FeatureVectors);
            IEnumerable<string> estimates = classifier.Predict(testSet.FeatureVectors);

            double errorCount = evaluator.Evaluate(testSet.FeatureVectors, testSet.Labels, estimates, Metrics.ZeroOneError);
            double areaUnderRocCurve = evaluator.AreaUnderRocCurve( "present", testSet.FeatureVectors, testSet.Labels, predictionDist);
            Console.WriteLine("errorCount: "+errorCount);
            Console.WriteLine("AURC: "+areaUnderRocCurve);
 
        }
       
    }
}

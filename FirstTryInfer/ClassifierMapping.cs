using System;
using System.Collections.Generic;
using MicrosoftResearch.Infer;
using MicrosoftResearch.Infer.Maths;
using MicrosoftResearch.Infer.Learners.Mappings;

namespace FirstTryInfer
{
   public class ClassifierMapping:IClassifierMapping<IList<Vector>,int,IList<string>,string,Vector>
    {
        public IEnumerable<string> GetClassLabels(IList<Vector> instanceSource = null, IList<string> labelSource = null)
        {
            return new[] { "present", "absent" };
        }

        public Vector GetFeatures(int instance, IList<Vector> instanceSource = null)
        {
            return instanceSource[instance];
        }

        public IEnumerable<int> GetInstances(IList<Vector> instanceSource)
        {
            for (int instance = 0; instance < instanceSource.Count; instance++)
            {
                yield return instance;
            }
        }

        public string GetLabel(int instance, IList<Vector> instanceSource = null, IList<string> labelSource = null)
        {
            return labelSource[instance];
        }
    }
}

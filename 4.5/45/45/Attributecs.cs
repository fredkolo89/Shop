using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using _45.Db;
using _45.Db.Models;


namespace _45
{
    public class Attribute
    {
        ArrayList mValues;
        string mName;
        object mLabel;

        public Attribute(string name, string[] values)
        {
            mName = name;
            mValues = new ArrayList(values);
            mValues.Sort();
        }

        public Attribute(object Label)
        {
            mLabel = Label;
            mName = string.Empty;
            mValues = null;
        }

        public string AttributeName
        {
            get
            {
                return mName;
            }
        }

        public string[] values
        {
            get
            {
                if (mValues != null)
                    return (string[])mValues.ToArray(typeof(string));
                else
                    return null;
            }
        }

      
        public bool isValidValue(string value)
        {
            return indexValue(value) >= 0;
        }

        public int indexValue(string value)
        {
            if (mValues != null)
                return mValues.BinarySearch(value);
            else
                return -1;
        }

      
        public override string ToString()
        {
            if (mName != string.Empty)
            {
                return mName;
            }
            else
            {
                return mLabel.ToString();
            }
        }
    }

    public class TreeNode
    {
        private ArrayList mChilds = null;
        private Attribute mAttribute;

        public TreeNode(Attribute attribute)
        {
            if (attribute.values != null)
            {
                mChilds = new ArrayList(attribute.values.Length);
                for (int i = 0; i < attribute.values.Length; i++)
                    mChilds.Add(null);
            }
            else
            {
                mChilds = new ArrayList(1);
                mChilds.Add(null);
            }
            mAttribute = attribute;
        }

        public void AddTreeNode(TreeNode treeNode, string ValueName)
        {
            int index = mAttribute.indexValue(ValueName);
            mChilds[index] = treeNode;
        }

        public int totalChilds
        {
            get
            {
                return mChilds.Count;
            }
        }


        public TreeNode getChild(int index)
        {
            return (TreeNode)mChilds[index];
        }


        public Attribute attribute
        {
            get
            {
                return mAttribute;
            }
        }


        public TreeNode getChildByBranchName(string branchName)
        {
            int index = mAttribute.indexValue(branchName);
            return (TreeNode)mChilds[index];
        }
    }

    public class DecisionTreeID3
    {
        private DataTable mSamples;
        private int mTotalPositives = 0;
        private int mTotal = 0;
        private string mTargetAttribute = "result";
        private double mEntropySet = 0.0;


        private int countTotalPositives(DataTable samples)
        {
            int result = 0;

            foreach (DataRow aRow in samples.Rows)
            {
                if ((bool)aRow[mTargetAttribute] == true)
                    result++;
            }

            return result;
        }

       
        private double calcEntropy(int positives, int negatives)
        {
            int total = positives + negatives;
            double ratioPositive = (double)positives / total;
            double ratioNegative = (double)negatives / total;

            if (ratioPositive != 0)
                ratioPositive = -(ratioPositive) * System.Math.Log(ratioPositive, 2);
            if (ratioNegative != 0)
                ratioNegative = -(ratioNegative) * System.Math.Log(ratioNegative, 2);

            double result = ratioPositive + ratioNegative;

            return result;
        }

     
        private void getValuesToAttribute(DataTable samples, Attribute attribute, string value, out int positives, out int negatives)
        {
            positives = 0;
            negatives = 0;

            foreach (DataRow aRow in samples.Rows)
            {
                if (((string)aRow[attribute.AttributeName] == value))
                    if ((bool)aRow[mTargetAttribute] == true)
                        positives++;
                    else
                        negatives++;
            }
        }

       
        private double gain(DataTable samples, Attribute attribute)
        {
            string[] values = attribute.values;
            double sum = 0.0;

            for (int i = 0; i < values.Length; i++)
            {
                int positives, negatives;

                positives = negatives = 0;

                getValuesToAttribute(samples, attribute, values[i], out positives, out negatives);

                double entropy = calcEntropy(positives, negatives);
                sum += -(double)(positives + negatives) / mTotal * entropy;
            }
            return mEntropySet + sum;
        }

      
        private Attribute getBestAttribute(DataTable samples, Attribute[] attributes)
        {
            double maxGain = 0.0;
            Attribute result = null;

            foreach (Attribute attribute in attributes)
            {
                double aux = gain(samples, attribute);
                if (aux > maxGain)
                {
                    maxGain = aux;
                    result = attribute;
                }
            }
            return result;
        }

       
        private bool allSamplesPositives(DataTable samples, string targetAttribute)
        {
            foreach (DataRow row in samples.Rows)
            {
                if ((bool)row[targetAttribute] == false)
                    return false;
            }

            return true;
        }

    
        private bool allSamplesNegatives(DataTable samples, string targetAttribute)
        {
            foreach (DataRow row in samples.Rows)
            {
                if ((bool)row[targetAttribute] == true)
                    return false;
            }

            return true;
        }

        
        private ArrayList getDistinctValues(DataTable samples, string targetAttribute)
        {
            ArrayList distinctValues = new ArrayList(samples.Rows.Count);

            foreach (DataRow row in samples.Rows)
            {
                if (distinctValues.IndexOf(row[targetAttribute]) == -1)
                    distinctValues.Add(row[targetAttribute]);
            }

            return distinctValues;
        }

      
        private object getMostCommonValue(DataTable samples, string targetAttribute)
        {
            ArrayList distinctValues = getDistinctValues(samples, targetAttribute);
            int[] count = new int[distinctValues.Count];

            foreach (DataRow row in samples.Rows)
            {
                int index = distinctValues.IndexOf(row[targetAttribute]);
                count[index]++;
            }

            int MaxIndex = 0;
            int MaxCount = 0;

            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] > MaxCount)
                {
                    MaxCount = count[i];
                    MaxIndex = i;
                }
            }

            return distinctValues[MaxIndex];
        }

        
        private TreeNode internalMountTree(DataTable samples, string targetAttribute, Attribute[] attributes)
        {
            if (allSamplesPositives(samples, targetAttribute) == true)
                return new TreeNode(new Attribute(true));

            if (allSamplesNegatives(samples, targetAttribute) == true)
                return new TreeNode(new Attribute(false));

            if (attributes.Length == 0)
                return new TreeNode(new Attribute(getMostCommonValue(samples, targetAttribute)));

            mTotal = samples.Rows.Count;
            mTargetAttribute = targetAttribute;
            mTotalPositives = countTotalPositives(samples);

            mEntropySet = calcEntropy(mTotalPositives, mTotal - mTotalPositives);

            Attribute bestAttribute = getBestAttribute(samples, attributes);

            TreeNode root = new TreeNode(bestAttribute);

            DataTable aSample = samples.Clone();

            foreach (string value in bestAttribute.values)
            {
                aSample.Rows.Clear();

                DataRow[] rows = samples.Select(bestAttribute.AttributeName + " = " + "'" + value + "'");

                foreach (DataRow row in rows)
                {
                    aSample.Rows.Add(row.ItemArray);
                }
              	
                ArrayList aAttributes = new ArrayList(attributes.Length - 1);
                for (int i = 0; i < attributes.Length; i++)
                {
                    if (attributes[i].AttributeName != bestAttribute.AttributeName)
                        aAttributes.Add(attributes[i]);
                }
              
                if (aSample.Rows.Count == 0)
                {
                    return new TreeNode(new Attribute(getMostCommonValue(aSample, targetAttribute)));
                }
                else
                {
                    DecisionTreeID3 dc3 = new DecisionTreeID3();
                    TreeNode ChildNode = dc3.mountTree(aSample, targetAttribute, (Attribute[])aAttributes.ToArray(typeof(Attribute)));
                    root.AddTreeNode(ChildNode, value);
                }
            }

            return root;
        }
        
       
        public TreeNode mountTree(DataTable samples, string targetAttribute, Attribute[] attributes)
        {
            mSamples = samples;
            return internalMountTree(mSamples, targetAttribute, attributes);
        }
    }

   public class ID3Sample
    {
      
        
        //public 
        public static void printNode(TreeNode root, string tabs, ref string kolejnosc)
        {
            kolejnosc += tabs + '|' + root.attribute + '|'+ Environment.NewLine;
            if (root.attribute.values != null)
            {
                for (int i = 0; i < root.attribute.values.Length; i++)
                {
                    kolejnosc += tabs + "\t" + "<" + root.attribute.values[i] + ">" + Environment.NewLine;
                    TreeNode childNode = root.getChildByBranchName(root.attribute.values[i]);
                    printNode(childNode, "\t" + tabs, ref kolejnosc);
                }
            }

        }
        public static DataTable getDataTable()
        {
            DataTable result = new DataTable("samples");
            DataTable tb;
            DataBase database;

            using (database = new DataBase())
            {
                List<Data1> data = database.Data1.Select(s => s).ToList();

                 tb = Helpers.ToDataTable(data);

            }
            result = tb;

          
            ///*  
            //result.Rows.Add(new object[] { "slonecznie", "wysoka", "wysokie", "nie", false });
            //result.Rows.Add(new object[] { "slonecznie", "wysoka", "wysokie", "tak", false });
            //result.Rows.Add(new object[] { "pochmurnie", "wysoka", "wysokie", "nie", true });
            //result.Rows.Add(new object[] { "deszczowo", "wysoka", "wysokie", "nie", true });
            //result.Rows.Add(new object[] { "deszczowo", "niska", "umiarkowane", "nie", true });
            //result.Rows.Add(new object[] { "deszczowo", "niska", "umiarkowane", "tak", false });
            //result.Rows.Add(new object[] { "pochmurnie", "niska", "umiarkowane", "tak", true });
            //result.Rows.Add(new object[] { "slonecznie", "umiarkowana", "wysokie", "nie", false });
            //result.Rows.Add(new object[] { "slonecznie", "niska", "umiarkowane", "nie", true });
            //result.Rows.Add(new object[] { "deszczowo", "umiarkowana", "umiarkowane", "nie", true });
            //result.Rows.Add(new object[] { "slonecznie", "umiarkowana", "umiarkowane", "nie", true });
            //result.Rows.Add(new object[] { "pochmurnie", "umiarkowana", "wysokie", "tak", true });
            //result.Rows.Add(new object[] { "pochmurnie", "wysoka", "umiarkowane", "nie", true });
            //result.Rows.Add(new object[] { "deszczowo", "umiarkowana", "wysokie", "tak", false });
            //*/

            

            return result;

        }     
    }
}

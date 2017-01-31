﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _45.Tree
{
    public class DecisionTree
    {
        private DataTable mSamples;
        private int mTotalPositives = 0;
        private int mTotal = 0;
        private string mTargetAttribute = "rezultat";
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
                    DecisionTree dc3 = new DecisionTree();
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
}

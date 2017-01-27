using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using _45.Db;
using _45.Db.Models;
using _45.Tree;

namespace _45
{
    public class Attribute
    {
        ArrayList mValues;
        string mName;
        public object mLabel;

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

        public static Attribute GetAttribute(int position, DataTable tb, List<string> nameColumns)
        {
            var tab = tb.AsEnumerable().Select(x => x[position].ToString()).Distinct().ToArray();
            Attribute attr = new Attribute(nameColumns[position].ToString(), tab);
            return attr;
        }

    }
}

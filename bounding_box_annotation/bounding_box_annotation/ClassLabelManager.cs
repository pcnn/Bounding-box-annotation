using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bounding_box_annotation
{
    internal class ClassLabelManager
    {
        string filename = Application.StartupPath + "\\" + "classes.txt";
        public string Filename
        {
            get { return this.filename; }
        }

        public List<string> ReadLabels()
        {
            List<string> res = new List<string>();
            if (System.IO.File.Exists(this.filename))
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(this.filename))
                {
                    while (!sr.EndOfStream)
                    {
                        string s = sr.ReadLine();
                        res.Add(s);
                    }
                }
            }
            return res;
        }

        public void SaveLabels(string[] labels)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filename))
            {
                for (int i = 0; i < labels.Length; i++)
                {
                    sw.WriteLine(labels[i]);
                }
                sw.Flush();
                sw.Close();
            }
        }
    }
}

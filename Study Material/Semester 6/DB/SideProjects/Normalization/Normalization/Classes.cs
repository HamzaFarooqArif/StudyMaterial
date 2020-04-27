using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Normalization
{
    //FunctionalDependency_Class--------------------------------------------------------
    public class FunctionalDependency
    {
        //FunctionalDependency_DataMembers----------------------------------------------
        List<string> left;
        public List<string> Left
        {
            get
            {
                return left;
            }

            set
            {
                left = value;
            }
        }
        List<string> right;

        public List<string> Right
        {
            get
            {
                return right;
            }

            set
            {
                right = value;
            }
        }

        //FunctionalDependency_MemberFunctions----------------------------------------
        public FunctionalDependency()
        {
            this.left = new List<string>();
            this.right = new List<string>();
        }
        public FunctionalDependency(FunctionalDependency fd)
        {
            this.left = new List<string>();
            this.right = new List<string>();

            foreach (string attri in fd.left)
            {
                this.left.Add( attri);
            }
            foreach (string attri in fd.right)
            {
                this.right.Add(attri);
            }
        }
        public void assign(FunctionalDependency fd)
        {
            this.left.Clear();
            this.right.Clear();
            foreach (string attri in fd.left)
            {
                this.left.Add(attri);
            }
            foreach (string attri in fd.right)
            {
                this.right.Add(attri);
            }
        }
        public bool addLeft(string str)
        {
            bool shouldAdd = true;
            foreach (string stri in this.left)
            {
                if (stri.Equals(str)) shouldAdd = false;
            }
            if (shouldAdd)
            {
                this.left.Add(str);
                return true;
            }
            return false;
        }
        public bool addRight(string str)
        {
            bool shouldAdd = true;
            foreach (string stri in this.right)
            {
                if (stri.Equals(str)) shouldAdd = false;
            }
            if (shouldAdd)
            {
                this.right.Add(str);
                return true;
            }
            return false;
        }
        public string show()
        {
            string result = "";
            if(left.Count > 0)
            {
                for (int i = 0; i < left.Count; i++)
                {
                    if (i < left.Count - 1)
                    {
                        result += left[i];
                        result += ", ";
                    }
                    else result += left[i];
                }
            }
            else
            {
                result += "Empty";
            }

            result += "->";

            if(right.Count > 0)
            {
                for (int i = 0; i < right.Count; i++)
                {
                    if (i < right.Count - 1)
                    {
                        result += right[i];
                        result += ", ";
                    }
                    else result += right[i];
                }
            }
            else
            {
                result += "Empty";
            }
            
            return result;
        }
        public void simplify()
        {
            List<string> tempList = new List<string>();

            foreach(string stri in this.left)
            {
                foreach(string strj in this.right)
                {
                    if (stri.Equals(strj)) tempList.Add(strj);
                }
            }

            foreach(string str in tempList)
            {
                this.right.Remove(str);
            }
        }
        public bool isSubsetOf(FunctionalDependency fd)
        {
            FunctionalDependency thisFd = new FunctionalDependency(this);
            thisFd.simplify();
            fd.simplify();

            foreach (string attri in thisFd.left)
            {
                bool shouldReturn = true;
                foreach (string attrj in fd.left)
                {
                    if (attri.Equals(attrj)) shouldReturn = false;
                }
                if (shouldReturn) return false;
            }
            foreach (string attri in fd.left)
            {
                bool shouldReturn = true;
                foreach (string attrj in thisFd.left)
                {
                    if (attri.Equals(attrj)) shouldReturn = false;
                }
                if (shouldReturn) return false;
            }
            foreach (string attri in thisFd.right)
            {
                bool shouldReturn = true;
                foreach (string attrj in fd.right)
                {
                    if (attri.Equals(attrj)) shouldReturn = false;
                }
                if (shouldReturn) return false;
            }
            return true;
        }
        public bool isEqual(FunctionalDependency fd)
        {
            FunctionalDependency thisFd = new FunctionalDependency(this);
            thisFd.simplify();
            fd.simplify();

            if (thisFd.isSubsetOf(fd) && fd.isSubsetOf(thisFd)) return true;
            return false;
        }
        public List<FunctionalDependency> breakDown()
        {
            List<FunctionalDependency> reslutList = new List<FunctionalDependency>();
            this.simplify();

            foreach(string stri in this.right)
            {
                FunctionalDependency fd = new FunctionalDependency();
                foreach (string strj in this.left)
                {
                    fd.left.Add(strj);
                }
                fd.right.Add(stri);
                reslutList.Add(fd);
            }
            return reslutList;
        }
        public bool leftContains(List<string> attrList)
        {
            foreach(string stri in attrList)
            {
                bool shouldReturn = true;
                foreach(string strj in this.left)
                {
                    if (stri.Equals(strj)) shouldReturn = false;
                }
                if (shouldReturn) return false;
            }
            return true;
        }
        public bool rightContains(List<string> attrList)
        {
            foreach (string stri in attrList)
            {
                bool shouldReturn = true;
                foreach (string strj in this.right)
                {
                    if (stri.Equals(strj)) shouldReturn = false;
                }
                if (shouldReturn) return false;
            }
            return true;
        }
        public void takeClosure(List<FunctionalDependency> fdList, List<string> attributeList)
        {
            List<FunctionalDependency> actualList = new List<FunctionalDependency>();
            List<string> resultList = new List<string>();

            foreach(FunctionalDependency fdi in fdList)
            {
                List<FunctionalDependency> tempFdList = fdi.breakDown();
                foreach(FunctionalDependency fdj in tempFdList)
                {
                    bool shouldAdd = true;
                    foreach(FunctionalDependency fdk in actualList)
                    {
                        if (fdk.isEqual(fdj)) shouldAdd = false;
                    }
                    if(shouldAdd) actualList.Add(fdj);
                }
            }

            foreach(FunctionalDependency fdk in actualList)
            {
                Console.WriteLine(fdk.show());
            }
        }
    }
}

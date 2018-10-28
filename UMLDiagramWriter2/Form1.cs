//Enter the first line of a function to get it returned in a UML formatin C# only

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMLDiagramWriter2
{
    public partial class Form1 : Form
    {
        const int TYPES_OF_FUNCTION = 5;
        int functionType = 0;
        const int TYPES_OF_PARAMETERS = 18;
        string[,] typeParameter = new string[TYPES_OF_PARAMETERS, 2];
        string[,] typeFunction = new string[TYPES_OF_FUNCTION, 2];
        void SetupStrings()
        {
            typeFunction[0, 0] = "void"; typeFunction[0, 1] = "";
            typeFunction[1, 0] = "bool"; typeFunction[1, 1] = " : Boolean";
            typeFunction[2, 0] = "string"; typeFunction[2, 1] = " : String";
            typeFunction[3, 0] = "int"; typeFunction[3, 1] = " : Integer";
            typeFunction[4, 0] = "double"; typeFunction[4, 1] = " : Double";

            typeParameter[0, 0] = "string"; typeParameter[0, 1] = "String";
            typeParameter[1, 0] = "int"; typeParameter[1, 1] = "Integer";
            typeParameter[2, 0] = "Point"; typeParameter[2, 1] = "Point";
            typeParameter[3, 0] = "Size"; typeParameter[3, 1] = "Size";
            typeParameter[4, 0] = "Rectangle"; typeParameter[4, 1] = "Rectangle";
            typeParameter[5, 0] = "RectangleF"; typeParameter[5, 1] = "RectangleF";

            typeParameter[6, 0] = "SizeF"; typeParameter[6, 1] = "SizeF";
            typeParameter[7, 0] = "PointF"; typeParameter[7, 1] = "PointF";
            typeParameter[8, 0] = "Image"; typeParameter[8, 1] = "Image";
            typeParameter[9, 0] = "string[]"; typeParameter[9, 1] = "String[]";
            typeParameter[10, 0] = "int[]"; typeParameter[10, 1] = "Integer[]";
            typeParameter[11, 0] = "Point[]"; typeParameter[11, 1] = "Point[]";
            typeParameter[12, 0] = "Size[]"; typeParameter[12, 1] = "Size[]";

            typeParameter[13, 0] = "Rectangle[]"; typeParameter[13, 1] = "Rectangle[]";
            typeParameter[14, 0] = "RectangleF[]"; typeParameter[14, 1] = "RectangleF[]";
            typeParameter[15, 0] = "SizeF[]"; typeParameter[15, 1] = "SizeF[]";
            typeParameter[16, 0] = "PointF[]"; typeParameter[16, 1] = "PointF[]";
            typeParameter[17, 0] = "Image[]"; typeParameter[17, 1] = "Image[]";

        }
        public Form1()
        {
            InitializeComponent();
            SetupStrings();
        }
        //string subprogram()
        //{
        //    int subprogramCursorCount = 0;
        //    int nameStart = 0;
        //    int nameLength = 0;
        //    int[] parameterType = new int[0];
        //    string[] parameterName =new string[0];

        //    for (int i = 0; i < typeFunction.Length; i++)
        //    {
        //        if (txtInput.Text.Substring(0, typeFunction[i,0].Length) == typeFunction[i,0])
        //        {
        //            functionType = i;
        //            subprogramCursorCount = typeFunction[i,0].Length+1;
        //            nameStart = subprogramCursorCount;
        //        }
        //    }
        //    while (txtInput.Text.Substring(subprogramCursorCount+nameLength,1)!="(")
        //    {
        //        nameLength++;
        //    }
        //    string subprogramName = txtInput.Text.Substring(subprogramCursorCount, nameLength);
        //    subprogramCursorCount += nameLength + 1;
        //    while (txtInput.Text.Substring(subprogramCursorCount, 1) != ")") 
        //        { 
        //            for (int p = 0; p < typeParameter.Length; p++)
        //            {
        //                if (txtInput.Text.Substring(subprogramCursorCount, typeParameter[p,0].Length) == typeParameter[p,0])
        //                {
        //                    ResizeBiggerInteger(ref parameterType);
        //                    ResizeBiggerString(ref parameterName);
        //                    parameterType[parameterType.Length-1] =p;
        //                    subprogramCursorCount += typeParameter[p,0].Length + 1;
        //                    int parameterCounter = 1;

        //                    while (txtInput.Text.Substring(subprogramCursorCount+ parameterCounter, 1) != ")"
        //                        && txtInput.Text.Substring(subprogramCursorCount+ parameterCounter,1) !=",")
        //                    {
        //                        parameterCounter++;
        //                    }
        //                    parameterName[parameterName.Length - 1] = txtInput.Text.Substring(subprogramCursorCount, parameterCounter);
        //                    subprogramCursorCount += parameterCounter+3;
        //                    p= typeParameter.Length;
        //                }
        //            }
        //        }
        //    string subprogramUML = subprogramName + "(";
        //    if (parameterType.Length != 0)
        //    {
        //        for (int i = 0; i < parameterType.Length; i++)
        //        {
        //            subprogramUML += parameterName[i] + " : " + typeParameter[parameterType[i],1]+",";
        //        }
        //        subprogramUML = subprogramUML.Remove(subprogramUML.Length - 1, 1);
        //    }
        //    subprogramUML += ")"+ typeParameter[functionType,1];
        //    return subprogramUML;

        //}
        private void btnUML_Click(object sender, EventArgs e)
        {
            //void RemoveEnemy(int index, ref Point[] enemyLocation, ref Size[] enemySize, ref Rectangle[] enemyBB, ref int[] enemyDirection, ref int[] enemySpeed, ref int[] enemyFrameCounter, ref int[] enemyHealth, ref int[] enemyMaxHealth, ref int[] enemyCurrent)

            string input = txtInput.Text.Trim();
            string fuction="", nameOfSubprogram="";
            string[] parameters = new string[0];
            int[] Nparameters = new int[0];
            for (int i = 0; i < input.Length; i++)
            {
                if (input.Substring(0, "Static ".Length) == "static ")
                {
                    input = input.Remove(0, "Static ".Length);
                }
            }
            for (int i = 0; i < input.Length - "ref ".Length; i++)
            {
                if (input.Substring(i, 4) == "ref ")
                {
                    input = input.Remove(i, 4);
                    i = 0;
                }
            }
            for (int i = 0; i < typeFunction.GetLength(0); i++)
            {
                if (input.Substring(0, typeFunction[i, 0].Length) == typeFunction[i, 0])
                {
                    fuction = typeFunction[i, 1];
                    input = input.Remove(0, typeFunction[i, 0].Length).Trim();
                    break;
                }
                if (i == typeFunction.GetLength(0) - 1)
                {
                    MessageBox.Show("Function does not have a type");
                }
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (input.Substring(i, 1) == "(")
                {
                    nameOfSubprogram = input.Substring(0, i);
                    input = input.Remove(0, i + 1);
                    break;
                }
                if (i == input.Length - 1)
                {
                    Application.Restart();
                }
            }
            bool repeat = true;

            int number = 0;
            string name = "";
            do
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (input.Substring(i, 1) == " ")
                    {
                        for (int k = 0; k < typeParameter.GetLength(0); k++)
                        {
                            if (input.Substring(0, i).Trim() == typeParameter[k, 0])
                            {
                                number = k;
                                break;
                            }
                        }
                        input = input.Remove(0, i).Trim();
                        break;

                    }
                }
                for (int i = 0; i < input.Length; i++)
                {
                    if (input.Substring(i, 1) == "," || input.Substring(i, 1) == ")")
                    {
                        name = input.Substring(0, i);
                        if (input.Substring(i, 1) == ")")
                        {
                            repeat = false;
                        }
                        input = input.Remove(0, i + 1).Trim();
                        break;
                    }
                }
                AddParemeter(ref Nparameters, ref parameters, ref number, ref name);
            } while (repeat == true);
            string UMLed = OutputFormat(ref Nparameters,ref parameters,ref nameOfSubprogram, ref fuction);
            MessageBox.Show(UMLed);

        }
        string OutputFormat(ref int[] numbro, ref string[] name,ref string functionName,ref string functionType)
        {
            string output = functionName + "( ";
            for (int i = 0; i < name.Length; i++)
            {
                output += name[i] +" : " +typeParameter[numbro[i],1];
                string end = "";
                if (i == name.Length - 1)
                {
                    end = ")";
                }
                else
                {
                    end = " , ";
                }
                output += end;
            }
            output += ") " + functionType;
            return output;
        }
        void AddParemeter(ref int[] numbro, ref string[] name, ref int number, ref string pie)
        {
            ResizeBiggerString(ref name);
            ResizeBiggerInteger(ref numbro);
            numbro[numbro.Length - 1] = number;
            name[name.Length - 1] = pie;
        }

        void ResizeBiggerInteger(ref int[] integer)
        {
            //Stores the array in a local array
            int[] storeInteger = integer;
            //Increases the size of the array in the parameter by 1.
            integer = new int[integer.Length + 1];
            //This is a forloop that copies everything from the local array to the main array.
            for (int i = 0; i < storeInteger.Length; i++)
            {
                //Stores the value at the index.
                integer[i] = storeInteger[i];
            }
        }
        //Resizes the string of integers to be bigger
        void ResizeBiggerString(ref string[] str)
        {
            String[] storeStr = str;
            str = new string[str.Length + 1];
            for (int i = 0; i < storeStr.Length; i++)
            {
                str[i] = storeStr[i];
            }
        }
    }
}

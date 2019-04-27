using System;
namespace UMLWriter
{
    class Setup
    {
        /// <summary>
        /// Setups the arrays with all the function types and waht they should return. 
        /// </summary>
        public static void SetupStrings(ref string[,] typeFunction, ref string[,] typeParameter)
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
        /// <summary>
        /// Resizes an int array to be one bigger
        /// </summary>
        static void ResizeBiggerInteger(ref int[] integer) {
            //Stores the array in a local array
            int[] storeInteger = integer;
            //Increases the size of the array in the parameter by 1.
            integer = new int[integer.Length + 1];
            //This is a forloop that copies everything from the local array to the main array.
            for (int i = 0; i < storeInteger.Length; i++)
                //Stores the value at the index.
                integer[i] = storeInteger[i];
        }
        /// <summary>
        /// Resizes the string of integers to be bigger
        /// </summary>
        static void ResizeBiggerString(ref string[] str){
            String[] storeStr = str;
            str = new string[str.Length + 1];
            for (int i = 0; i < storeStr.Length; i++)
                str[i] = storeStr[i];
        }
        /// <summary>
        /// Adds a parameter to all the variables associated witht he parameter. 
        /// </summary>
        public static void AddParemeter(ref int[] numbro, ref string[] name, ref int number, ref string pie)
        {
            ResizeBiggerString(ref name);
            ResizeBiggerInteger(ref numbro);
            numbro[numbro.Length - 1] = number;
            name[name.Length - 1] = pie;
        }
        /// <summary>
        /// Once the array has been analyed, this function will create a formatted string.
        /// </summary>
        public static string OutputFormat(ref int[] numbro, ref string[] name, ref string functionName, ref string functionType,ref string[,] typeParameter)
        {
            string output = functionName + "(";
            for (int i = 0; i < name.Length; i++)
            {
                output += name[i] + " : " + typeParameter[numbro[i], 1];

                string end = "";
                if (i == name.Length - 1)
                    end = ")";
                else
                    end = " , ";

                output += end;
            }
            output += ") " + functionType;
            return output;
        }
    }
}

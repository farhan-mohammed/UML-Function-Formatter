//Enter the first line of a function to get it returned in a UML formatin C# only

using System;
using System.Windows.Forms;

namespace UMLWriter
{
    public partial class UMLForm : Form
    {
        const int TYPES_OF_FUNCTION = 5;
        const int TYPES_OF_PARAMETERS = 18;
        string[,] typeParameter = new string[TYPES_OF_PARAMETERS, 2];
        string[,] typeFunction = new string[TYPES_OF_FUNCTION, 2];
        

        public UMLForm()
        {
            InitializeComponent();
            setup.SetupStrings(ref typeFunction,ref typeParameter);
        }
        
        private void btnUML_Click(object sender, EventArgs e)
        {
            //void RemoveEnemy(int index, ref Point[] enemyLocation, ref Size[] enemySize, ref Rectangle[] enemyBB, ref int[] enemyDirection, ref int[] enemySpeed, ref int[] enemyFrameCounter, ref int[] enemyHealth, ref int[] enemyMaxHealth, ref int[] enemyCurrent)

            string input = txtInput.Text.Trim();
            string fuction="", nameOfSubprogram="";
            string[] parameters = new string[0];
            int[] Nparameters = new int[0];
            //Chescks for the word static 
           if (input.Substring(0, "Static ".Length) == "static ")
                input = input.Remove(0, "Static ".Length);
           //checks for the word ref anywhere and removes it. 
            for (int i = 0; i < input.Length - "ref ".Length; i++)
                if (input.Substring(i, 4) == "ref ")
                { 
                    input = input.Remove(i, 4);
                    i = 0;
                }
            //It checks for the type of the function and stores it 
            for (int i = 0; i < typeFunction.GetLength(0); i++){
                if (input.Substring(0, typeFunction[i, 0].Length) == typeFunction[i, 0]) {
                    fuction = typeFunction[i, 1];
                    input = input.Remove(0, typeFunction[i, 0].Length).Trim();
                    break;
                }
                if (i == typeFunction.GetLength(0) - 1)
                    MessageBox.Show("Function does not have a type");
            }

            //It checks for the name of the function and stores it 
            for (int i = 0; i < input.Length; i++) {
                if (input.Substring(i, 1) == "("){
                    nameOfSubprogram = input.Substring(0, i);
                    input = input.Remove(0, i + 1);
                    break;
                }
                if (i == input.Length - 1)
                    Application.Restart();
            }
            //repeat becomes false at the final bracket
            bool repeat = true;
            int number = 0;
            string name = "";
            do {
                for (int i = 0; i < input.Length; i++)
                    if (input.Substring(i, 1) == " "){
                        for (int k = 0; k < typeParameter.GetLength(0); k++)
                            if (input.Substring(0, i).Trim() == typeParameter[k, 0]) {
                                number = k;
                                break;
                            }
                        input = input.Remove(0, i).Trim();
                        break;
                    }

                for (int i = 0; i < input.Length; i++) 
                    if (input.Substring(i, 1) == "," || input.Substring(i, 1) == ")"){
                        name = input.Substring(0, i);
                        if (input.Substring(i, 1) == ")")
                            repeat = false;
                        input = input.Remove(0, i + 1).Trim();
                        break;
                    }
                setup.AddParemeter(ref Nparameters, ref parameters, ref number, ref name);
            } while (repeat == true);
            string UMLed = setup.OutputFormat(ref Nparameters,ref parameters,ref nameOfSubprogram, ref fuction,ref typeParameter);
            txtOutput.Text = UMLed;
        }

        

        
    }
}

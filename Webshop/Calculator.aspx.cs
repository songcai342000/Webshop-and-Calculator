using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Text;
using System.IO;
using System.Xml;

public partial class _Calculator : Page
{

    string input;
    string[] factors;
    int Sum;

    protected void Page_Load(object sender, EventArgs e)
    {
        //load the input and result history
         history();
    }

    //show the last result
    protected void Output()
    {
        string result = "";
        //check if there is letter on the right side of the "="
        if (input != null && input != "" && input.Contains("="))
        {
            string[] theEquation = input.Trim().Split('=');
            //if the left side contains only one letter
            string variable = theEquation[0].Trim();
            string letterExpression = @"^[a-zA-Z]$";
            //check if the variable is an single letter
            if (Regex.IsMatch(variable, letterExpression))
            {
                //split the right side of the input equation
                factors = theEquation[1].Split('+');
                Sum = caculation(factors, input);
                //if the equation does not contain unkown variable, caculate and show the result
                if (Sum != -1)
                {
                    //show the result in the format
                    result = "   ===>" + theEquation[0].Trim() + " = " + Sum.ToString();
                    resultLab.Text = result;
                    resultLab.Visible = true;
                }
                else
                {
                    //clear the resultLab text
                    resultLab.Text = "";
                }
            }
        }
        
    }

    protected void history()
    {
        //load an exisiting xml file to store the input and output strings
        XmlDocument doc = new XmlDocument();
         doc.Load(Server.MapPath("/CalculatorXML.xml"));
        //store the input and caculation result in a output node
        XmlNodeList outputs = doc.GetElementsByTagName("output");
        if (outputs.Count > 0)
        {
            //define the formats and show the input and result with dynamic labels
            for (int i = outputs.Count - 1; i >= 0; i--)
            {
                Label newLab1 = new Label();
                newLab1.Text = "<br/>" + outputs[i].ChildNodes[0].InnerText;
                ctrlPanel.Controls.Add(newLab1);                  
                Label newLab2 = new Label();
                newLab2.Text = "<br/> ===>" + outputs[i].ChildNodes[1].InnerText;
                ctrlPanel.Controls.Add(newLab2);                  
            }
        }
    }

    protected void saveVariable(string variableName, string variableValue)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(Server.MapPath("/CalculatorXML.xml"));
        //check if the variable is new
        XmlNodeList names = doc.GetElementsByTagName("name");
        //the initial count of the variable in the xml file
        int count = 0;
        foreach (XmlNode name in names)
        {
            //update its value if it is an existing variable
            if (name.InnerText == variableName)
            {
                name.NextSibling.InnerText = variableValue;
                //the number of the variable becomes 1
                count++;
                //break the loop when the updating is finished
                break;
            }
        }
        //if it is a new variable, create a new variable node containing name node and value node
        if (count == 0)
        {
            //find the parent node of the new variable node
            XmlNode variables = doc.SelectSingleNode(@"operations/variables");
            //create the new nodes
            XmlElement variable = doc.CreateElement("variable");
            XmlElement name = doc.CreateElement("name");
            name.InnerText = variableName;
            XmlElement value = doc.CreateElement("value");
            value.InnerText = variableValue;
            //Add the new nodes
            variable.AppendChild(name);
            variable.AppendChild(value);
            variables.AppendChild(variable);
        }
        //save the variable and its value
        doc.Save(Server.MapPath("/CalculatorXML.xml"));
    }

    //save the new input and result to the xml file
    protected void saveInputResult(string inputString, string outputString)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(Server.MapPath("/CalculatorXML.xml"));
        //find the parent node to the new output node
        XmlNode outputs = doc.SelectSingleNode(@"operations/outputs");
        //create the new output node containing input node and result node
        XmlElement output = doc.CreateElement("output");
        XmlElement input = doc.CreateElement("inpput");
        input.InnerText = inputString;
        XmlElement result = doc.CreateElement("result");
        result.InnerText = outputString;
        //Add the new nodes
        output.AppendChild(input);
        output.AppendChild(result);
        outputs.AppendChild(output);
        //save the changes
        doc.Save(Server.MapPath("/CalculatorXML.xml"));

    }

    //get the value of a variable
     protected string getVariable(string variableName)
     {
         XmlDocument doc = new XmlDocument();
         doc.Load(Server.MapPath("/CalculatorXML.xml"));
         //find the variable
         //not the best construction, but it is for training to use childnodes
         XmlNodeList variables = doc.GetElementsByTagName("variable");
         string variableValue = "";
         //Get the value of the variable. If the variable exists, the variable is variables[0]
         if (variables.Count > 0)
         {
             foreach (XmlNode variable in variables)
             {
                 if (variable.ChildNodes[0].InnerText == variableName)
                 {
                     variableValue = variable.ChildNodes[1].InnerText;
                 }
             }
         }
         return variableValue;
    }

   /* protected string getVariable(string variableName)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(Server.MapPath("/CalculatorXML.xml"));
        //find the variable
        XmlNodeList names = doc.GetElementsByTagName("name");
        string variableValue = "";
        //Get the value of the variable. If the variable exists, the variable is variables[0]
        if (names.Count > 0)
        {
            foreach (XmlNode name in names)
            {
                if (name.InnerText == variableName)
                {
                    variableValue = name.NextSibling.InnerText;
                }
            }
        }
        return variableValue;
    }*/

     protected int caculation(string[] factors, string input)
     {
         //the initial value of the caculation result
         int sum = 0;
         //define a string to mark the different conditions
         //string mark = "";
         //regular expression pattern of a number
         string numberExression = @"^[0-9]+$";
         //split the input equation
         string[] theEquation = input.Split('=');
         //caculate the sum of the factors
         foreach (string factor in factors)
         {
             //if the factor is a number
             if (Regex.IsMatch(factor.Trim(), numberExression))
             {
                 sum = sum + Convert.ToInt32(factor);
             }
             //if the factor is not a number
             else
             {
                 //find its value
                 string variableValueStr = getVariable(factor.Trim());
                 //if it is an existing variable
                 if (variableValueStr != "")
                 {
                     sum = sum + Convert.ToInt32(variableValueStr);
                 }
                 //if it is an unkown variable
                 else
                 {
                    //stop the caculation
                    //mark = "Unknown variable";
                    sum = -1;
                    break;
                 }
             }
         }
         //if the variable exists in the xml file
        if (sum != -1)
        {
            //create the result equation
            string result = theEquation[0].ToString() + " = " + sum.ToString();
            //save the input equation and result equation
            saveInputResult(input, result);
            //save the variable 
            saveVariable(theEquation[0].Trim(), sum.ToString());
            //return the sum of the caculation
        }
        return sum;
    }


    protected void inputBox_TextChanged(object sender, EventArgs e)
     {
         input = inputBox.Text;
         //treat the input
         Output();
         //clean the textbox
         inputBox.Text = "";
     }
 }



 
 
 
 
 
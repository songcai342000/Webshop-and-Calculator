using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Collections;

public partial class algoritme_BinarySearch : System.Web.UI.Page
{
    /// <summary>
    /// /with the function, the user can type any number and find the positions of it in a predefined array.
    /// if the number doesn't exist in the array, the function shows the message that the number is not found 
    /// </summary>
    int[] array1;
    string position;
    List<int> duplicationIndexes = new List<int>();
    protected void Page_Load(object sender, EventArgs e)
    {
       //define the int array
        array1 = new int[]{ 1, 2, 2, 3, 4, 4, 4, 5, 6, 7, 7, 8, 8, 9, 10, 11, 24, 17, 17, 17, 18, 18, 19, 33, 33, 33, 36, 36};
        //sort the array
        Array.Sort(array1);
        //show the array on the label
        int i;
        for (i = 0; i < array1.Length - 1; i++)
        {
            arrayLbl.Text = arrayLbl.Text + array1[i].ToString() + ", ";
        }
        //no comma follows the last number
        arrayLbl.Text = arrayLbl.Text + array1[i].ToString();
    }

    //find the position
    protected void ShowWhere(int index, int input)
    {
        if (index == 0)
        {
            position = "Beginning of the array";
        }
        else if(index == array1.Length - 1)
        {
            position = "End of the array";
        }
        else if (index < 0)
        {
            index = ~index;
            position = "The input number is not found";
        }
        //the number is on other positions in the array
        else 
        {
            //put the indexes of the number in a list
            findDuplication(array1, index, input, duplicationIndexes);
            //reorder the list
            duplicationIndexes.Sort();
            //express the positions, a position is index + 1
            for (int i = 0; i < duplicationIndexes.Count; i++)
            {
                position = position + " " + (duplicationIndexes[i] + 1).ToString();
            }
            position = "Positions: " + position;
        }
        

    }

    protected void submitBtn_Click(object sender, EventArgs e)
    {
        int givennumber = Convert.ToInt32(numberBox.Text.ToString());
        //find one of the indexes of the number
        int index = Array.BinarySearch(array1, givennumber);
        //find the positions
        ShowWhere(index, givennumber);
        positionLbl.Text = position;
        positionLbl.Visible = true;
    }

   /// <summary>
   /// check if the number has several indexes
   /// </summary>
   /// <param name="baseArray"></param>
   /// <param name="index"></param>
   /// <param name="input"></param>
   /// <param name="indexList"></param>
   protected void findDuplication(Array baseArray, int index, int input, List<int> indexList)
   {
        //put the first found index in a list
        indexList.Add(index);
        int nextValue;
        //the count of the indexList
        int listCount = 0;
        //remember the index with a variable
        int startPoint = index;
        //the value of the previous number
        int previousValue = (int)(baseArray.GetValue(index - 1));
        //the value of next number
        nextValue = (int)(baseArray.GetValue(index + 1));
        //if the previous number has the same value 
        if (previousValue == input)
        {
            //if the list has got a new element, the while loop continues
            while (indexList.Count > listCount)
            {
                //update the listCount
                listCount = indexList.Count;
                //if it is not the first element in the array, check if it is same with the previous number
                if (index != 0)
                {
                    //find the value of the previous number
                    previousValue = (int)(baseArray.GetValue(index - 1));
                    if (previousValue == input)
                    {
                        index--;
                        indexList.Add(index);
                    }
                }

            }
        }
        //create the condition to start while loop
        listCount = indexList.Count - 1;
        //the index got by binary search
        index = startPoint;
        //if the next number has the same value
        nextValue = (int)(baseArray.GetValue(index + 1));
        if (nextValue == input)
        {
            //if the list has got a new member, the while loop continues
            while (indexList.Count > listCount)
            {
                //update the listCount
                listCount = indexList.Count;
                //if it is not the end of the array, check it is same with the next number
                if (index < baseArray.Length - 1)
                {
                    //find the value of the next number
                    nextValue = (int)(baseArray.GetValue(index + 1));
                    if (nextValue == input)
                    {
                        index++;
                        indexList.Add(index);
                    }
                }
            }
        }
        
               
    }
    
}
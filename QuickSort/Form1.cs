using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickSort
{
    public partial class Form1 : Form
    {
        // IMPLEMENT DATE 08-12-2015 
        // IMPLEMENT BY Patchamas Kakaew
        // Form INTRODUCTION TO ALGORITHMS <Thomas H.Corman> 
        /*
         * QUICKSORT(A,p,r)
         * if p < r
         *  q = PARTITION(A,p,r)
         *  QUICKSORT(A, p, q-1)
         *  QUICKSORT(A, q+1, r)
         * PARTITION(A, p, r)
         * x=A[r]
         * i=p-1
         * for j=p to r-1
         *  if A<=x
         *  i=i+1
         *  exchange A[i] with A[r]
         * exchange A[i+1] with A[r]
         * return i+1
         */

        public Form1()
        {
            InitializeComponent();
        }

        public void QuickSort(int[] input, int low, int high)
        {
            int pivot_loc = 0;

            if (low < high)
            {
                pivot_loc = partition(input, low, high);
                QuickSort(input, low, pivot_loc - 1);
                QuickSort(input, pivot_loc + 1, high);
            }

        }

        public int partition(int[] input, int low, int high)
        {
            int pivot = input[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (input[j] <= pivot)
                {
                    i++;
                    swap(input, i, j);
                }
            }
            swap(input, i + 1, high);
            return i + 1;
        
        }

        public void swap(int[] ar, int a, int b)
        {
            int temp = ar[a];
            ar[a] = ar[b];
            ar[b] = temp;
        }

        public void print(int[] output, TextBox tbOutput)
        {
            tbOutput.Clear();
            for (int a = 0; a < output.Length; a++)
            {
                tbOutput.Text += output[a] + " ";
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {      
            string[] arsInput = tbInput.Text.Split(' ');
            int[] arInput = new int[arsInput.Length];
            for (int i = 0; i < arsInput.Length; i++)
            {
                arInput[i] = Convert.ToInt16(arsInput[i]);              
            }
            QuickSort(arInput, 0, arsInput.Length-1);
            print(arInput, tbOutput);
        }

    }
}

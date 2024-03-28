using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConvertNumericToText1
{
    public partial class ConvertNumericToText : System.Web.UI.Page
    {
        bool beginsZero;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblConvertToText.Text = string.Empty;
        }

        protected void btnConvert_Click(object sender, EventArgs e)
        {
            double chkNumb = 0;
            lblErrorMsg.Visible = false;

            if (txtNumber.Text.Trim() != "")
            {
                //Allow numeric only
                if (Double.TryParse(txtNumber.Text, out chkNumb))
                {
                    string txtWholeNumber = txtNumber.Text;

                    string strNumbDecimal = "";
                    string strNumbWDecimal = "";
                    string strResultDecimal = "";
                    string strResultNumb = "";

                    bool beginsDec = txtWholeNumber.StartsWith(".");
                    if (beginsDec == true) txtWholeNumber = "0" + txtWholeNumber;
                    beginsZero = txtWholeNumber.StartsWith("0");

                    int chkDecimalExist = txtWholeNumber.IndexOf(".");

                    if (chkDecimalExist > 0)
                    {
                        strNumbWDecimal = txtWholeNumber.Substring(0, chkDecimalExist);
                        strResultNumb = ConvertNumberToText(strNumbWDecimal);

                        int chkDecLength = txtWholeNumber.Length - (chkDecimalExist + 1);
                        bool chkDecError = false;

                        //Allow 2 decimal places
                        if (chkDecLength > 2)
                        {
                            lblErrorMsg.Text = "Only allow 2 decimal places";
                            lblErrorMsg.Visible = true;
                            chkDecError = true;
                        }
                        else if (chkDecLength < 2)
                        {
                            strNumbDecimal = txtWholeNumber.Substring(chkDecimalExist + 1, chkDecLength) + "0";
                        }
                        else
                        {
                            strNumbDecimal = txtWholeNumber.Substring(chkDecimalExist + 1, chkDecLength);
                        }

                        if (chkDecError == false)
                        {
                            strResultDecimal = ConvertDecimal(strNumbDecimal);
                        }
                    }
                    else
                    {
                        strResultNumb = ConvertNumberToText(txtWholeNumber);
                    }

                    if (beginsZero == false)
                    {
                        lblConvertToText.Text = strResultNumb + " DOLLARS " + strResultDecimal;
                    }
                    else
                    {
                        lblConvertToText.Text = strResultDecimal;
                    }
                }
                else
                {
                    lblErrorMsg.Text = "Input is not a number.";
                    lblErrorMsg.Visible = true;
                }
            }
            else
            {
                lblErrorMsg.Text = "Please input a number.";
                lblErrorMsg.Visible = true;
            }
        }

        public string ConvertNumberToText (string strNumber)
        {
            string strConvert = "";
            long strDigit = Convert.ToInt64(strNumber);

            int strNumbLength = strNumber.Length;

            for (int i = 0; strDigit > 0; i++)
            {
                if (strDigit % 1000 != 0)
                {
                    strConvert = ConvertHundreds(strDigit % 1000) + " " + threeDigit[i] + " " + strConvert;
                }
                    
                strDigit /= 1000;
            }

            return strConvert;
        }

        private static string ConvertHundreds(long number)
        {
            string words = "";
            int chkNumbLength = number.ToString().Length;

            if (number >= 100)
            {
                words += singleDigit[number / 100] + " HUNDRED ";
                number %= 100;
                chkNumbLength = number.ToString().Length;
            }

            if (number >= 10 && number <= 19)
            {
                words += doubleDigit[number % 10] + " ";
            }
            else
            {
                words += doubleTenDigit[number / 10];
                if (number % 10 > 0)
                {
                    if (chkNumbLength > 1)
                    {
                        words += "-" + singleDigit[number % 10];
                    }
                    else
                    {
                        words += singleDigit[number % 10];
                    }
                    
                }
            }

            return words;
        }

        public string ConvertDecimal(string strDecimal)
        {
            string strConvertDec = "";

            if (strDecimal.Contains("00"))
            {
                strConvertDec = " AND ZERO CENTS";
            }
            else
            {
                if (beginsZero == false)
                {
                    strConvertDec = " AND " + ConvertNumberToText(strDecimal) + " CENTS";
                }
                else
                {
                    strConvertDec = ConvertNumberToText(strDecimal) + " CENTS";
                }
            }

            return strConvertDec;
        }

        private static string[] singleDigit = { "", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE" };
        private static string[] doubleDigit = { "TEN", "ELEVEN","TWELVE","THIRTEEN","FOURTEEN","FIFTEEN","SIXTEEN","SEVENTEEN","EIGHTEEN","NINETEEN"};
        private static string[] doubleTenDigit = { "", "TEN", "TWENTY","THIRTY","FORTY","FIFTY","SIXTY","SEVENTY","EIGHTY","NINETY"};
        private static string[] threeDigit = { "", "THOUSAND", "MILLION", "BILLION", "TRILLION","QUADRILLION" };

        
    }
}
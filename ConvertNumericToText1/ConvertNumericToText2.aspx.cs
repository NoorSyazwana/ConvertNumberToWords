using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConvertNumericToText1
{
    public partial class ConvertNumericToText2 : System.Web.UI.Page
    {
        bool beginsZero;

        protected void Page_Load(object sender, EventArgs e)
        {
            lblConvertToText.Text = string.Empty;
        }

        protected void btnConvert_Click(object sender, EventArgs e)
        {
            double chkNumb = 0;
            string strNumbWDecimal = "";
            string txtWholeNumber = "";
            lblErrorMsg.Visible = false;

            if (txtNumber.Text.Trim() != "")
            {
                //Allow numeric only
                if (Double.TryParse(txtNumber.Text, out chkNumb))
                {
                    if (chkNumb <= 0)
                    {
                        lblErrorMsg.Text = "Not allow input zero";
                        lblErrorMsg.Visible = true;
                        return;
                    }

                    txtWholeNumber = txtNumber.Text.Replace(",", "");

                    string strNumbDecimal = "";
                    string strResultDecimal = "";
                    string strResultNumb = "";

                    bool beginsDec = txtWholeNumber.StartsWith(".");
                    if (beginsDec == true) txtWholeNumber = "0" + txtWholeNumber;
                    beginsZero = txtWholeNumber.StartsWith("0");

                    int chkDecimalExist = txtWholeNumber.IndexOf(".");

                    if (chkDecimalExist > 0)
                    {
                        strNumbWDecimal = txtWholeNumber.Substring(0, chkDecimalExist);
                        //Not allow more than 36 digits
                        if (strNumbWDecimal.Length < 36)
                        {
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
                            lblErrorMsg.Text = "Input is not more than 36 digits.";
                            lblErrorMsg.Visible = true;
                            return;
                        }
                    }
                    else
                    {
                        if (txtWholeNumber.Length < 36)
                        {
                            strResultNumb = ConvertNumberToText(txtWholeNumber);
                        }
                        else
                        {
                            lblErrorMsg.Text = "Input is not more than 36 digits.";
                            lblErrorMsg.Visible = true;
                            return;
                        }
                    }

                    if (beginsZero == false)
                    {
                        lblConvertToText.Text = strResultNumb + " DOLLARS " + strResultDecimal;
                    }
                    else
                    {
                        if (beginsZero == true && Convert.ToInt16(strNumbWDecimal) > 0)
                        {
                            lblConvertToText.Text = strResultNumb + " DOLLARS " + strResultDecimal;
                        }
                        else
                        {
                            lblConvertToText.Text = strResultDecimal;
                        }
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

        public string ConvertNumberToText(string strNumber)
        {
            string strConvert = "";
            string strLargeConvert = "";
            string strOriNumb = strNumber;

            //maximum length of long are 18 char
            int chkLongDigit = strNumber.Length / 18;
            int chkNumbLength = strNumber.Length;

            if (chkNumbLength > 18)
            {
                string strSplitNumber = "";
                int pos = 0;

                for (int j = chkNumbLength; chkNumbLength > 0; j--)
                {
                    if (chkNumbLength > 18)
                    {
                        strSplitNumber = strNumber.Substring(j - 18, 18);
                        strConvert = ConvertNumberToText(strSplitNumber);
                    }
                    else
                    {
                        //switch (chkNumbLength)
                        //{
                        //    case 1:
                        //    case 2:
                        //    case 3:
                        //        pos = 0;
                        //        break;
                        //    case 4:
                        //    case 5:
                        //    case 6:
                        //        pos = 1;
                        //        break;
                        //    case 7:
                        //    case 8:
                        //    case 9:
                        //        pos = 2;
                        //        break;
                        //    case 10:
                        //    case 11:
                        //    case 12:
                        //        pos = 3;
                        //        break;
                        //    case 13:
                        //    case 14:
                        //    case 15:
                        //        pos = 4;
                        //        break;
                        //    case 16:
                        //    case 17:
                        //    case 18:
                        //        pos = 5;
                        //        break;
                        //}

                        strSplitNumber = strNumber.Substring(0, chkNumbLength);

                        int strLengthSplit = strSplitNumber.Length;
                        long strLargeNumber = Convert.ToInt64(strSplitNumber);

                        for (int i = 0; strLargeNumber > 0; i++)
                        {
                            if (strLargeNumber % 1000 != 0)
                            {
                                switch (strLengthSplit)
                                {
                                    case 1:
                                        strLengthSplit -= 1;
                                        pos = 0;
                                        break;
                                    case 2:
                                        strLengthSplit -= 2;
                                        pos = 0;
                                        break;
                                    case 3:
                                        strLengthSplit -= 3;
                                        pos = 0;
                                        break;
                                    case 4:
                                        strLengthSplit -= 1;
                                        pos = 1;
                                        break;
                                    case 5:
                                        strLengthSplit -= 2;
                                        pos = 1;
                                        break;
                                    case 6:
                                        strLengthSplit -= 3;
                                        pos = 1;
                                        break;
                                    case 7:
                                        strLengthSplit -= 1;
                                        pos = 2;
                                        break;
                                    case 8:
                                        strLengthSplit -= 2;
                                        pos = 2;
                                        break;
                                    case 9:
                                        strLengthSplit -= 3;
                                        pos = 2;
                                        break;
                                    case 10:
                                        pos = 3;
                                        strLengthSplit -= 1;
                                        break;
                                    case 11:
                                        pos = 3;
                                        strLengthSplit -= 2;
                                        break;
                                    case 12:
                                        pos = 3;
                                        strLengthSplit -= 3;
                                        break;
                                    case 13:
                                        strLengthSplit -= 1;
                                        pos = 4;
                                        break;
                                    case 14:
                                        strLengthSplit -= 2;
                                        pos = 4;
                                        break;
                                    case 15:
                                        strLengthSplit -= 3;
                                        pos = 4;
                                        break;
                                    case 16:
                                        strLengthSplit -= 1;
                                        pos = 5;
                                        break;
                                    case 17:
                                        strLengthSplit -= 2;
                                        pos = 5;
                                        break;
                                    case 18:
                                        strLengthSplit -= 3;
                                        pos = 5;
                                        break;
                                }

                                if (strLargeNumber % 1000 != 0)
                                {
                                    //strLargeConvert = ConvertHundreds(strLargeNumber % 1000) + " " + threeTenDigit[pos] + " " + strConvert;
                                    strLargeConvert = strLargeConvert + " " + ConvertHundreds(strLargeNumber % 1000) + " " + threeTenDigit[pos];
                                }
                            }
                                

                            strLargeNumber /= 1000;
                        }

                        //strLargeConvert = ConvertHundreds(Convert.ToInt64(strSplitNumber)) + " " + threeTenDigit[pos];
                    }

                    chkNumbLength -= 18;
                    j -= 18;
                }

                strConvert = strLargeConvert + " " + strConvert;
            }
            else
            {
                long strDigit = Convert.ToInt64(strNumber);

                for (int i = 0; strDigit > 0; i++)
                {
                    if (strDigit % 1000 != 0)
                    {
                        strConvert = ConvertHundreds(strDigit % 1000) + " " + threeDigit[i] + " " + strConvert;
                    }

                    strDigit /= 1000;
                }
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
        private static string[] doubleDigit = { "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
        private static string[] doubleTenDigit = { "", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };
        private static string[] threeDigit = { "", "THOUSAND", "MILLION", "BILLION", "TRILLION", "QUADRILLION"  };
        private static string[] threeTenDigit = { "QUINTILLION", "SEXTILLION", "SEPTILLION", "OCTILLION", "NONILLION", "DECILLION", "UNDECILLION" };
    }
}
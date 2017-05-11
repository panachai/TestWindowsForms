using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWindowsForms {
    public partial class Form1 : Form {
        MyCarlendar myCarlendar;
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            myCarlendar = new MyCarlendar();

            //------------------- fixed form
            // Define the border style of the form to a dialog box.
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            // Set the MaximizeBox to false to remove the maximize box.
            this.MaximizeBox = false;
            // Set the MinimizeBox to false to remove the minimize box.
            this.MinimizeBox = false;
            // Set the start position of the form to the center of the screen.
            this.StartPosition = FormStartPosition.CenterScreen;
            // Display the form as a modal dialog box. //this.ShowDialog();
            //-------------------

            //------------------- control combobox
            cbMonth.SelectedIndex = cbMonth.Items.IndexOf("มกราคม");
            cbMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            //-------------------
            tbYear.Text = "2017";

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            rtbResult.Text = ("Mo  Tu  We  Th  Fr  Sa  Su\n" + myCarlendar.OnCheck(cbMonth.Text, Int32.Parse(tbYear.Text)));    //+String เข้าเอา
            //System.Diagnostics.Debug.WriteLine("year : "+tbYear.Text);
            // Int32.Parse(tbYear.Text)
            //lbTest.Text = (string)cbMonth.SelectedItem;
        }

        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void lbTest_Click(object sender, EventArgs e) {

        }
    }


    class MyCarlendar {

        public String OnCheck(String month, int year) {
            int result;

            if (month.Equals("มกราคม")) {
                result = 01;
            } else if (month.Equals("กุมภาพันธ์")) {
                result = 02;
            } else if (month.Equals("มีนาคม")) {
                result = 03;
            } else if (month.Equals("เมษายน")) {
                result = 04;
            } else if (month.Equals("พฤษภาคม")) {
                result = 05;
            } else if (month.Equals("มิถุนายน")) {
                result = 06;
            } else if (month.Equals("กรกฎาคม")) {
                result = 07;
            } else if (month.Equals("สิงหาคม")) {
                result = 08;
            } else if (month.Equals("กันยายน")) {
                result = 09;
            } else if (month.Equals("ตุลาคม")) {
                result = 10;
            } else if (month.Equals("พฤศจิกายน")) {
                result = 11;
            } else if (month.Equals("ธันวาคม")) {
                result = 12;
            } else {
                result = 0;
            }

            return OnGetDayByMonth(year, result);
        }

        public String OnGetDayByMonth(int year, int indexMonth) {

            //เดือนหลัก
            int lastMonth = DateTime.DaysInMonth(year, indexMonth);
            int startWeek = (int)new DateTime(year, indexMonth, 1).DayOfWeek;

            //เก็บจำนวนสัปดาห์
            int weekCount = 0;

            if (startWeek == 0) {
                startWeek = 7;
            }

            //เก็บค่า
            string dayMonth = "";

            //ก่อนเดือนหลัก
            int lastMonthBeforeWeek = 0;

            int count = 1;

            if (startWeek > 1)//ทำค่าก่อนหน้า ของเดือนนี้
            {
                System.Diagnostics.Debug.WriteLine("in loop startweek");
                if (indexMonth > 1) {
                    lastMonthBeforeWeek = DateTime.DaysInMonth(year, indexMonth - 1);
                } else {
                    lastMonthBeforeWeek = DateTime.DaysInMonth(year - 1, 12);
                }

                int copyLMBW = lastMonthBeforeWeek;
                //int copySBFW = startBeforeWeek;
                int copySW = startWeek;

                while (copySW > 2) //เพราะมีแก้ไขเว้นวรรค เลยต้องใช้ 2
                {
                    dayMonth = "   " + copyLMBW + dayMonth;
                    copyLMBW--;
                    copySW--;
                }

                dayMonth = copyLMBW + dayMonth; //แก้ไข ไม่ให้มีเว้นวรรคด้านหน้า

                dayMonth += "   ";//เว้นก่อนลง ปฏิทินหลัก
                System.Diagnostics.Debug.WriteLine("end loop start week");
            }

            int checkfirstloop = 0;

            for (int i = 1; i <= lastMonth; i++) {
                if (i >= 1 && i <= 9) //เอาไว้จัดหน้าให้สวย
                {
                    dayMonth += "  " + i + "   ";
                } else {
                    dayMonth += i + "   ";
                }


                if (checkfirstloop == 0) {
                    //startBeforeWeek
                    if (count >= 8 - startWeek) //8 - 
                    {
                        System.Diagnostics.Debug.WriteLine("Startweek : " + startWeek);
                        System.Diagnostics.Debug.WriteLine("Count : " + count);
                        count = 1;
                        dayMonth += "\n";
                        checkfirstloop = 1;

                        System.Diagnostics.Debug.WriteLine("\nCount in loop day : " + i + " count : " + count);
                        weekCount++;
                        continue;
                    }
                } else {
                    if (count >= 7) {
                        count = 1;
                        dayMonth += "\n";

                        System.Diagnostics.Debug.WriteLine("\nCount in loop day : " + i + " count : " + count);
                        weekCount++;
                        continue;
                    }
                }

                System.Diagnostics.Debug.WriteLine("\nCount in loop day : " + i + " count : " + count);
                count++;


            }

            //เก็บเศษเดือนที่เหลือ
            Boolean loop = true;
            int dayLast = 1;
            while (loop) {
                //dayMonth += dayLast + "   ";

                if (dayLast >= 1 && dayLast <= 9) {//เอาไว้จัดหน้าให้สวย
                    dayMonth += "  " + dayLast + "   ";
                } else {
                    dayMonth += dayLast + "   ";
                }

                if (count >= 7) {
                    count = 1;
                    dayMonth += "\n";

                    weekCount++;
                    if (weekCount >= 6) {
                        loop = false;
                    }
                    dayLast++;
                    continue;
                }
                count++;
                dayLast++;

            }

            System.Diagnostics.Debug.WriteLine("end weekcount : " + weekCount);

            return dayMonth;
        }


    }
}

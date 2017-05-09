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
    }


    class MyCarlendar {

        public String OnCheck(String month, int year) {
            int result;

            if (month.Equals("มกราคม")) {
                result = 01;
            }
            else if (month.Equals("กุมภาพันธ์")) {
                result = 02;
            }
            else if (month.Equals("มีนาคม")) {
                result = 03;
            }
            else if (month.Equals("เมษายน")) {
                result = 04;
            }
            else if (month.Equals("พฤษภาคม")) {
                result = 05;
            }
            else if (month.Equals("มิถุนายน")) {
                result = 06;
            }
            else if (month.Equals("กรกฎาคม")) {
                result = 07;
            }
            else if (month.Equals("สิงหาคม")) {
                result = 08;
            }
            else if (month.Equals("กันยายน")) {
                result = 09;
            }
            else if (month.Equals("ตุลาคม")) {
                result = 10;
            }
            else if (month.Equals("พฤศจิกายน")) {
                result = 11;
            }
            else if (month.Equals("ธันวาคม")) {
                result = 12;
            }
            else {
                result = 0;
            }

            return OnGetDayByMonth(year, result);
        }

        private int startBeforeWeek;  //test วางไว้นอก class

        public String OnGetDayByMonth(int year, int indexMonth) {

            //เดือนหลัก
            int lastMonth = DateTime.DaysInMonth(year, indexMonth);
            int startWeek = (int)new DateTime(year, indexMonth, 1).DayOfWeek;

            //เก็บค่า
            string dayMonth = "";

            //ก่อนเดือนหลัก
            int lastMonthBeforeWeek = 0;
            

            int count = 1;
            if (startWeek != 1) {   //ทำค่าก่อนหน้า ของเดือนนี้


                if (indexMonth != 1) {
                    //Console.WriteLine("index month : " + indexMonth);
                    startBeforeWeek = (int)new DateTime(year, indexMonth - 1, 1).DayOfWeek;

                    lastMonthBeforeWeek = DateTime.DaysInMonth(year, indexMonth - 1);
                }
                else {
                    startBeforeWeek = (int)new DateTime(year - 1, 12, 1).DayOfWeek;

                    lastMonthBeforeWeek = DateTime.DaysInMonth(year - 1, 12);
                }

                Console.WriteLine("StartBefore : " + startBeforeWeek);

                int copyLMBW = lastMonthBeforeWeek;
                int copySBFW = startBeforeWeek;

                while (copySBFW != 1) {
                    dayMonth = "   " + copyLMBW + dayMonth;
                    copyLMBW--;
                    copySBFW--;
                }

                dayMonth += "   ";//เว้นก่อนลง ปฏิทินหลัก
                Console.WriteLine("before DayMonth : " + dayMonth);
            }

            int checkfirstloop = 0;
            
          

            for (int i = 1; i <= lastMonth; i++) {
                dayMonth += i + "   ";

                if (checkfirstloop == 0) {
                    //startBeforeWeek
                   

                    if (count == 7 - startBeforeWeek) {
                        count = 1;
                        dayMonth += "\n";
                        checkfirstloop = 1;
                    }
                }
                else {
                    if (count == 7) {
                        count = 1;
                        dayMonth += "\n";
                    }
                }
                count++;
            }

            //System.Diagnostics.Debug.WriteLine("test : " + startWeek);
            //System.Diagnostics.Debug.WriteLine("test weekname : " + new DateTime(year, indexMonth, 1).DayOfWeek);

            //System.Diagnostics.Debug.WriteLine(dayMonth);

            return dayMonth;
        }


    }
}

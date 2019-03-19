using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Timer101
{
    public partial class Form1 : Form

       

    {

        // This integer variable keeps track of the  
        // remaining time. 
        int timeLeft;
        int providedTime;
        int TimerMinutes,  MinutesLeft;
        int Minutes, Hourz,BalSecs;
           int Hours, TimerSeconds ,TimerHours, HoursLeft;


        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                // Display the new time left 
                // by updating the Time Left label.
                timeLeft = timeLeft - 1;
               Messagelabel1.Text = BalSecs + " Seconds  " + "Remaining";
              
                MinutesLeft = timeLeft / 60; //converts sec to minutes which are displayed
                int HoursLeft = timeLeft / 3600; //converts sec to hours,which are to be display
                BalSecs = timeLeft- (MinutesLeft * 60); // shows the seconds remaining
               LabelMinutesLeft.Text = HoursLeft + "  Hours" + " Remaining";

               txtMinutesLeft.Text = MinutesLeft + "  Minutes " + " Remaining";    // shows the mins remaining  
      


            }

        
            else
            {
                // If the user ran out of time, stop the timer, show 
                // perform another action
                timer1.Stop();

                Messagelabel1.Text = "Time's up!";
                BeepSound(); 
                
                MessageBox.Show("You run out of time.", "Sorry!");
                 Form2 reDirect = new Form2();
                reDirect.Show();
                this.Hide();
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Stop();
            btnSTOP.Visible = false;

        }

        private void StartCountDown()
        {
            // Start the timer.

            TimerSeconds = Int32.Parse(TimeTextBox1.Text);
            TimerHours = Int32.Parse(TimerTextBox2.Text);
            TimerMinutes=Int32.Parse(timerMins.Text);
            timeLeft = TimerSeconds + 3600 * TimerHours + TimerMinutes * 60;

        Messagelabel1.Text = Convert.ToString(timeLeft);
            timer1.Start();
            this.Visible = true;
            btnSTOP.Visible = true;

        
        }


        private void StartTheCounter()
        {

            // Start the timer2 counter.

         providedTime = Int32.Parse( CounterTimetextBox.Text);
            Messagelabel1.Text = Convert.ToString(providedTime);
            timer2.Start();
        
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
           
            TimerSeconds = Int32.Parse(TimeTextBox1.Text);
            TimerMinutes = Int32.Parse(timerMins.Text);
            TimerHours=  Int32.Parse(TimerTextBox2.Text);

            timeLeft = TimerSeconds + (3600 * TimerHours) + (TimerMinutes * 60);

      StartCountDown();
            timer1.Start();
            lblElapsedTimeSecs.Visible = false;
            timer2.Stop();
            
            this.Width = 572;
            this.Height = 341;

            btnSTOP.Visible = true;
            btnStart.Visible = false;

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            


            int currentMinutes;
          
           // 
            providedTime = providedTime + 1; // COUNTS UPWARDS
            //
            lblElapsedTimeSecs.Text = providedTime + " Seconds  " + "Spent";
          


            if(providedTime > 60)
            {
                int Minutes = providedTime/ 60;
                 Hours = providedTime / 3600;
                CounterTimetextBox.Text = Minutes.ToString();
                CounterHoursTextBox.Text = Hours.ToString();
                  BalSecs = timeLeft - (Minutes * 60);

            }

            if (providedTime > 3600)
            {
               
                currentMinutes = providedTime - 3600;
                CounterTimetextBox.Text = currentMinutes.ToString();
                this.BackColor = Color.Aquamarine;
               // MessageBox.Show("HELLO"); creates too many messages overpowering the sys
                //timer2.Stop();

            }
           
        
               
               

            
            
        }

        private void buttonCounter_Click(object sender, EventArgs e)
        {
            //providedTime = Int32.Parse(CounterTimetextBox.Text); useless
            StartTheCounter();
            timer2.Start();
            lblElapsedTimeSecs.Visible = true;
            Messagelabel1.Visible = false;
            timer1.Stop();
        }

        private void btnStopTimer2_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            lblElapsedTimeSecs.Visible = false;
        }

        private void ConditionsImplementor()
        {
            int MinutesSpent;
            int HoursSpent;
            
            MinutesSpent= Int32.Parse(CounterTimetextBox.Text);
            HoursSpent = Int32.Parse(CounterHoursTextBox.Text);

            if (MinutesSpent > 10)
            {
                MessageBox.Show("Half an Hour spent");
                this.BackColor = Color.Aquamarine;

            }
        
        }

        private void btnSTOP_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            btnStart.Visible = true;
            btnSTOP.Visible = false;

           this.Width=364;
           this.Height = 381;


        }

        public static void BeepSound()
        {
            //beeping at 1000 Hertz and for 3 seconds
            Console.Beep(1000, 3000);

        }


    }
}

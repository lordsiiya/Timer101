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
                // Decrement the time left by 1 second.
                timeLeft--;

                // Calculate hours, minutes, and seconds remaining.
                int HoursLeft = timeLeft / 3600;
                int MinutesLeft = (timeLeft % 3600) / 60;
                int BalSecs = timeLeft % 60;

                // Update the labels to display the remaining time.
                Messagelabel1.Text = $" {BalSecs:D2} Seconds Remaining";
                txtMinutesLeft.Text = $"{HoursLeft:D2} Hours {MinutesLeft:D2} Minutes Remaining";  // showing the summary of time remaining in the rich textbox - txtMinutesLeft



                lblElapsedTimeSecsA2.Visible = false;  // Hiding this label since it is associated with Timer 2

                // Update individual labels if needed.
                LabelMinutesLeft.Text = $"{HoursLeft:D2} Hours Remaining";
               // txtMinutesLeft.Text = $"{MinutesLeft:D2} Minutes Remaining";
            }
            else
            {
                // Stop the timer and show a notification.
                timer1.Stop();

                Messagelabel1.Text = txtNotifyMsg.Text;   //Show the Notification message set by the user as a reminder
                lblNotifyerMsg.Visible = true;
                lblNotifyerMsg.Text = txtNotifyMsg.Text;  // show in another label that will stay visible when the Messagelabel1 becomes hidden.

                BeepSound();                             // Generate a beep sound to alert the user that time is up

                // Uncomment the lines below if you want to show another form or display a message box.
                // MessageBox.Show("You run out of time.", "Sorry!");
                // Form2 reDirect = new Form2();
                // reDirect.Show();
                // this.Hide();
                buttonCounter.PerformClick();   // CLICK THE START COUNTER BUTTON SO THAT THAT IT CAN COUNT THE ELAPSED TIME


            
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Stop();
            btnSTOP.Visible = false;   // hIDING THE STOP BUTTON SINCE IT'S NOT NEEDED AT FORM LOAD
            lblNotifyerMsg.Visible = false;  // Hiding this label for showing that time is up, it will be required later on but not at form load.
            
            txtCurrentTime.Text = DateTime.Now.ToString("HH:mm tt"); // Display time in HH:MM:SS AM/PM format
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

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


            //Messagelabel1.Text = $"{HoursLeft:D2} Hours {MinutesLeft:D2} Minutes {BalSecs:D2} Seconds Remaining";
            txtMinutesLeft.Text = $"{HoursLeft:D2} Hours {MinutesLeft:D2} Minutes {BalSecs:D2} Seconds Remaining";


            StartCountDown();
            timer1.Start();
            Messagelabel1.Visible = true;       //Making the label for showing countdown seconds visible
            lblElapsedTimeSecs.Visible = false;
            txtNotifyMsg.Visible = false;     // Hiding the typed Notification message until when it's needed
            lblElapsedTimeSecsA2.Visible = false;

            timer2.Stop();
            
            this.Width = 598;
            this.Height = 375;

            btnSTOP.Visible = true;
            btnStart.Visible = false;

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TxtCurrentTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void Timer3_Tick(object sender, EventArgs e)
        {


        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            // Increment the providedTime by 1 second on each tick
            providedTime += 1;

            // Calculate hours, minutes, and remaining seconds
            int elapsedHours = providedTime / 3600;
            int elapsedMinutes = (providedTime % 3600) / 60;
            int elapsedSeconds = providedTime % 60;

            // Update the label to show the elapsed time in hours, minutes, and seconds
            lblElapsedTimeSecs.Text = $"{elapsedHours} Hours {elapsedMinutes} Minutes {elapsedSeconds} Seconds Spent";
            lblElapsedTimeSecsA2.Text= $"{elapsedSeconds} Seconds Spent";

            // Update the CounterTimetextBox and CounterHoursTextBox with the elapsed minutes and hours
            CounterTimetextBox.Text = elapsedMinutes.ToString();
            CounterHoursTextBox.Text = elapsedHours.ToString();

            // Optionally, implement color changes or other actions based on elapsed time
            if (elapsedMinutes > 10)
            {
                this.BackColor = Color.Aquamarine;
            }
        }



        private void buttonCounter_Click(object sender, EventArgs e)
        {
            //providedTime = Int32.Parse(CounterTimetextBox.Text); useless
            // ADJUST FORM SIZE
            this.Width = 376;
            this.Height = 406;

            txtNotifyMsg.Visible = false;

            StartTheCounter();
            timer2.Start();
            lblElapsedTimeSecs.Visible = false;  // HIDING THE LABEL WITH ALL THE COUNT UP DETAILS
            lblElapsedTimeSecsA2.Visible = true;
            Messagelabel1.Visible = false;
            timer1.Stop();
        }

        private void btnStopTimer2_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            lblElapsedTimeSecs.Visible = false;

            txtNotifyMsg.Visible = true;
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
            this.Opacity = 95;


            txtNotifyMsg.Visible = true;
            lblNotifyerMsg.Visible = false;

        }

        public static void BeepSound()
        {
            //beeping at 1000 Hertz and for 3 seconds
            Console.Beep(1000, 3000);

        }


    }
}

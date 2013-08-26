﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NEXP.Pages
{
    /// <summary>
    /// Interaction logic for BlockAndTrial.xaml
    /// </summary>
    public partial class BlockAndTrial : UserControl
    {
        private DateTime downTime;
        private object downSender;
        private Point downPosition;
        private int i = 1;
        public BlockAndTrial()
        {
            InitializeComponent();
        }

        private void OpaqueClickableImage_MouseDown_backButton(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.downSender = sender;
                this.downTime = DateTime.Now;
                this.downPosition = e.GetPosition(sender as Image);
            }
        }

        private void OpaqueClickableImage_MouseUp_backButton(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released && sender == this.downSender)
            {
                TimeSpan timeSinceDown = DateTime.Now - this.downTime;
                if (timeSinceDown.TotalMilliseconds < 500)
                {
                    //MessageBox.Show("Image Click: " + sender.ToString());
                    NEXP.Utils.OpaqueClickableImage tmp = sender as NEXP.Utils.OpaqueClickableImage;

                    if (tmp.Name == "BackButton")
                    {
                        NavigationCommands.GoToPage.Execute("/Pages/Home.xaml", this);   // http://mui.codeplex.com/discussions/434905
                    }
                }
            }
        }
        private void OpaqueClickableImage_MouseDown_NextButton(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.downSender = sender;
                this.downTime = DateTime.Now;
                this.downPosition = e.GetPosition(sender as Image);
            }
        }

        private void OpaqueClickableImage_MouseUp_NextButton(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released && sender == this.downSender)
            {
                TimeSpan timeSinceDown = DateTime.Now - this.downTime;
                if (timeSinceDown.TotalMilliseconds < 500)
                {
                    //MessageBox.Show("Image Click: " + sender.ToString());
                    NEXP.Utils.OpaqueClickableImage tmp = sender as NEXP.Utils.OpaqueClickableImage;

                    if (tmp.Name == "NextButton")
                    {
                        //Log.getLogInstance().writeLog(Frame.Content.ToString());
                        /*
                         if (Frame.Content.ToString() == "/Content/RQ_list2.xaml")
                         {
                             NavigationCommands.GoToPage.Execute("/Content/RQ_list1.xaml", Frame);
                         }
                         */
                        i++;
                        i = i % 3;
                        if (i == 1)
                        {
                            NavigationCommands.GoToPage.Execute("/Content/Estimate.xaml", Frame);
                        }
                        else if (i == 2)
                        {
                            NavigationCommands.GoToPage.Execute("/Content/Balance.xaml", Frame);
                        }
                        else if (i == 0)
                        {
                            NavigationCommands.GoToPage.Execute("/Content/Visualization.xaml",Frame);
                        }
                        else { }
                        //Log.getLogInstance().writeLog(Frame.Content.ToString());
                        //NavigationCommands.GoToPage.Execute("/Pages/Home.xaml", this);   // http://mui.codeplex.com/discussions/434905
                    }
                }
            }
        }
    }
}

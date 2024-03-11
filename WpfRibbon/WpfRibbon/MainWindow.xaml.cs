﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfRibbon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            //rtbText.Selection.ApplyPropertyValue(/*Beállítás neve*/, /*beállítás értéke*/)
        }

        private void RibbonButton_Click(object sender, RoutedEventArgs e)
        {
            rtbText.Selection.ApplyPropertyValue(FontWeightProperty, FontWeights.Bold);
            
        }
    }
}
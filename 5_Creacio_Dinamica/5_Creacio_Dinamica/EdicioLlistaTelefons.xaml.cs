﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _5_Creacio_Dinamica
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class EdicioLlistaTelefons : Page
    {
        private List<string> telefons;

        public EdicioLlistaTelefons()
        {
            this.InitializeComponent();

            List<int> numeros = new List<int>();
            for(int i=1;i<=10;i++)
            {
                numeros.Add(i);
            }
            cboQuantitatTelefons.ItemsSource = numeros;
            //----------------------------------------
        }

        private void cboQuantitatTelefons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int q = (int)cboQuantitatTelefons.SelectedItem;
            //<TextBox Text="646232232" Padding="10" Margin="10"> </TextBox>

            telefons.Clear();
            foreach (TextBox t in staTelefons.Children)
            {
                telefons.Add(t.Text);
            }
            staTelefons.Children.Clear();

            MostrarTextBoxes(q);


            /*
             * How to survice SelectedValue and SelectedItem
             * -------------------------------------------------
             * Si voleu agafar el valor d'UNA PROPIETAT de dins de l'element seleccionat
             * usem de forma combinada SelectedValuePath i selected value
            cboQuantitatTelefons.SelectedValuePath = "Matricula";
            cboQuantitatTelefons.SelectedValue // és la matrícula del vehicle seleccionat

            // Per contra, SelectedItem conté TOT el vehicle sencer
            ((Vehicle)cboQuantitatTelefons.SelectedItem).Matricula
            */


        }

        private void MostrarTextBoxes(int q)
        {
            for (int i = 0; i < q; i++)
            {
                TextBox t = new TextBox();
                if (i < telefons.Count)
                {
                    t.Text = telefons[i];
                }
                t.Padding = new Thickness(10);
                t.Margin = new Thickness(10);

                t.TextChanged += T_TextChanged;

                staTelefons.Children.Add(t);
            }
        }

        private void T_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            try
            {
                Int32.Parse(t.Text);
                t.Background = new SolidColorBrush(Colors.Transparent);
            }
            catch (Exception)
            {
                t.Background = new SolidColorBrush(Colors.Red);
            }

        }




        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            telefons = (List<string>)e.Parameter;
            if(telefons!=null)
            {
                MostrarTextBoxes(telefons.Count);
            }

        }
        // Aquest event salta quan estem a punt de marxar de la
        // pàgina per què estem navegant cap a una altra
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            telefons.Clear();
            foreach (TextBox t in staTelefons.Children)
            {
                telefons.Add(t.Text);
            }

        }



    }
}

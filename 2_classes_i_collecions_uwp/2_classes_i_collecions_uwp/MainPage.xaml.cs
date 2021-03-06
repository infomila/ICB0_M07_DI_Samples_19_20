﻿using _2_classes_i_collecions_uwp.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _2_classes_i_collecions_uwp
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<String> noms = new List<string>();
            noms.Add("Paco");
            noms.Add("Maria");
            noms.Add("Joan");
            noms.Add("Joan");


            noms.RemoveAt(0);
            noms.Insert(0, "El que s'ha colao !");

            int posicioMaria = noms.IndexOf("Maria");
            Boolean laMariaHiEs = noms.Contains("Maria");

            string sortida="";
            foreach(String nom in noms) {
                sortida += "\t " + nom + "\n";               
            }
            txbSortida.Text = sortida;
            //-----------------------------------------

            Dictionary<String, Int32> jugadors = new Dictionary<string, int>();
            jugadors.Add("Ter Stegen", 1);
            jugadors.Add("Pique", 3);
            jugadors.Add("Messi", 10);
            if (!jugadors.ContainsKey("Pique"))
            {
                jugadors.Add("Pique", 3);
            }
            //-----------------------------------------
            int d1 = jugadors["Messi"];
            //int d2 = jugadors["MessiXXXXX"];
            sortida = "";
            foreach(string nom in jugadors.Keys)
            {
                sortida += "\t " + nom +":"+ jugadors[nom] + "\n";
            }
            txbSortida.Text += sortida;
            sortida = "";
            foreach (Int32 d in jugadors.Values)
            {
                sortida += "\t " + d + "\n";
            }
            txbSortida.Text += sortida;

            //---------------------------------------------

            // Exemples amb classes pròpies
            Vehicle cotxe1 = new Vehicle(1,"7625TRR","Seat","Leon", "Cotxe");
            Vehicle cotxe2 = new Vehicle(2, "6543KJY", "Seat", "Tarraco", "Cotxe");
            Vehicle cotxe3 = new Vehicle(3, "6543KJY", "Audi", "A6", "Cotxe");

            cotxe1.Matricula = "234234";

            List<Vehicle> vehicles = new List<Vehicle>();
            vehicles.Add(cotxe1);
            vehicles.Add(cotxe2);
            vehicles.Add(cotxe3);
            
            vehicles.Contains(cotxe1);


            Vehicle cotxe1bis = new Vehicle(1, "7625TRR", "Seat", "Leon", "Cotxe");
            
            txbSortida.Text += "Trobat?"+ vehicles.Contains(cotxe1bis);


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore.Storage;
using PrTest2.Models;

namespace PrTest2;

public partial class SportNatinSportsmenWindow : Window
{
    public int rer;
    private int returnId;
    private string returnName;
    
    public SportNatinSportsmenWindow()
    {
        InitializeComponent();
        Sportsman();
        ReturnButton_OnClick.Click += BackClick;
    }
    public SportNatinSportsmenWindow(int a, string b, int d, string c)
    {
        InitializeComponent();
        returnId = a;
        returnName = b;
        rer = d;
        zxc.Text = c.ToString();
        wsx.Text = b.ToString();
        ReturnButton_OnClick.Click += BackClick;
        Sportsman();
    }

    private void BackClick (object? sender, RoutedEventArgs e)
    {
        Sport_NationWindow sport_NationWindow = new Sport_NationWindow(returnId, returnName);
        sport_NationWindow.Show();
        Close();
    }


    private void Sportsman()
    {
        List<Sportsman> sport = Helper.Database.Sportsmans.ToList();
        List<Nation> nation = Helper.Database.Nations.ToList();
        

        var a = sport
            .Where(s => s.Nationality == returnId && s.Nationality == rer)
           
            .Join(
                nation,  
                s => s.Id,
                n => n.Id,
                
                (s, n) => new
                {
                    
                    fullName = s.Name
                }).ToList();
        fullSportsmenNation.Items = a;


    }

}
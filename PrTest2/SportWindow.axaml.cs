using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using PrTest2.Context;
using PrTest2.Models;

namespace PrTest2;

public partial class SportWindow : Window
{
    public static string _nan;
    public SportWindow()
    {
        InitializeComponent();
        ButtonBack.Click += BackClick;
        Sports();
    }

    
    
    
    public void BackClick(object sender, EventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }

    private void Sports()
    {
        List<TypesOfSport> typesofsport = Helper.Database.TypesOfSports.ToList();;
        sport.Items = typesofsport.Select(x => new
        {
            x.Id,
            x.Title
        }).ToList();
        _nan = typesofsport.Select(x => x.Title).ToString();
    }


    

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        Sport_NationWindow sportNationWindow = new Sport_NationWindow(
            (int)(sender as Button).Tag,
            (string)(sender as Button).Content
            
        );
        sportNationWindow.Show();
        this.Close();
    }
}

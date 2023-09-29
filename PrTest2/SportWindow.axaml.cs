using System;
using System.Collections.Generic;
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
    public SportWindow()
    {
        InitializeComponent();
        ButtonBack.Click += BackClick;
        Sports();
    }

    private int qwe;
    
    
    
    public void BackClick(object sender, EventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }

    private void Sports()
    {
        List<TypesOfSport> typesofsport;
        typesofsport = Helper.Database.TypesOfSports.ToList();
        sport.Items = typesofsport.Select(x => new
        {
            x.Id,
            x.Title
        });
    }

    

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
      
        qwe = (int)(sender as Button).Tag;
        Sport_NationWindow sportNationWindow = new Sport_NationWindow(qwe);
        sportNationWindow.Show();
        Close();



    }
}

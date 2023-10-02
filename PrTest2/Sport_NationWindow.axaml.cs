using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Security.Cryptography;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Castle.Components.DictionaryAdapter.Xml;
using PrTest2.Models;

namespace PrTest2;

public partial class Sport_NationWindow : Window
{
    
    public Sport_NationWindow()
    {
        InitializeComponent();
        SportNation();
    }

    private void ReturnButton_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            SportWindow sportWindow = new SportWindow();
            sportWindow.Show();
            Close();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
    }

    public int rer;
    

    public Sport_NationWindow(int qwe)
    {
        InitializeComponent();
      
        wsx.Text = qwe.ToString();

        rer = qwe;
        SportNation();
    }




    
    

    public void SportNation()
    {
        
        List<Sportsman> sportsmen = Helper.Database.Sportsmans.ToList();
        List<Nation> nation = Helper.Database.Nations.ToList();

        var sportsmensAndNation = sportsmen
            
            
            
            // .Where(s => s.Nationality == rer)
            
            .Select(s => new
            {
                Nationality = s.Nationality,
                Id = s.Id
            }).ToList();
        
        
            /*from s in sportsmen
            join n in nation on n => n.Id == s equals s => s.Nationality == rer */

        SportNationList.Items = sportsmensAndNation;

    }

    
}
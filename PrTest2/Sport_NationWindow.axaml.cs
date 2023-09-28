using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Castle.Components.DictionaryAdapter.Xml;
using PrTest2.Models;

namespace PrTest2;

public partial class Sport_NationWindow : Window
{
    public  Nation nation;
    
    public Sport_NationWindow()
    {
        InitializeComponent();
        ReturnButton.Click += ReturnB;
    }
    
    public Sport_NationWindow(string Id)
    {
        InitializeComponent();
        ReturnButton.Click += ReturnB;
        wsx.Text = Id;
        
    }

    private void ReturnB(Object sender, EventArgs e)
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

    public void Sport_Nation()
    {
        List<Sportsman> sportsmen = Helper.Database.Sportsmans.ToList();
        Sport_Nation_List.Items = sportsmen.Select(x => new
        {
            
        });

    }

}
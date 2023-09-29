using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
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
        ReturnButton.Click += ReturnB;
        SportNation();
    }
    
    public Sport_NationWindow(int qwe)
    {
        InitializeComponent();
        ReturnButton.Click += ReturnB;
        wsx.Text = qwe.ToString();
        SportNation();
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


    
    

    public void SportNation()
    {
        List<Sportsman> sportsmen = Helper.Database.Sportsmans.ToList();

        var nan1 = sportsmen
            .Where(s => s.Name == wsx.Name)
            .Select(s => new
            {
                Id = s.Id,
                
                Name = s.Name,
                Surname = s.Surname,
                Sport = s.Sport,
             
                Age = s.Age
            }).ToList();


        Sport_Nation_List.Items = sportsmen;

    }

}
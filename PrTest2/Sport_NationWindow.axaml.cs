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
    public int rer;
    private int broadcastId;
    private string broadcastName;
    public Sport_NationWindow()
    {
        InitializeComponent();
        SportNation();
    }
    public Sport_NationWindow(int qwe, string asd)
    {
        InitializeComponent();
        broadcastId = qwe;
        broadcastName = asd;
        wsx.Text = asd.ToString();

        rer = qwe;
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

    







    public void SportNation()
    {

        List<Sportsman> sportsmen = Helper.Database.Sportsmans.ToList();
        List<Nation> nation = Helper.Database.Nations.ToList();

        var sportsmensAndNation = sportsmen
            .Where(s => s.Nationality == rer)
            .Join
            (
                nation,
                s => s.Sport,
                n => n.Id,
                (s, n) => new
                {
                    Title = n.Title,
                    Id = n.Id
                }

            );
        SportNationList.Items = sportsmensAndNation;
    }

    private void SportNationality(object? sender, RoutedEventArgs e)
    {
        SportNatinSportsmenWindow sportNatinSportsmenWindow = new SportNatinSportsmenWindow
            (
                broadcastId, 
                broadcastName.ToString(),
                (int)(sender as Button).Tag,
                (string)(sender as Button).Content
            );
        sportNatinSportsmenWindow.Show();
        this.Close();
    }
}
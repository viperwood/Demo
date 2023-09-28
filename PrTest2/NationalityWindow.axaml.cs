using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PrTest2.Models;

namespace PrTest2;

public partial class NationalityWindow : Window
{
    public NationalityWindow()
    {
        InitializeComponent();
        ButtonBack.Click += BackWindow;
        LoadNationality();
    }

    public void BackWindow(object sender, EventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }

    private void LoadNationality()
    {
        List<Nation> nations;
        nations = Helper.Database.Nations.ToList();
        NationListBox.Items = nations.Select(x => new
        {
            x.Title
        });
    }
}
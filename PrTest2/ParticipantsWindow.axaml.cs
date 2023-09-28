using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PrTest2.Models;

namespace PrTest2;

public partial class ParticipantsWindow : Window
{
    public List<Sportsman> Nan()
    {
        List<Sportsman> sportsmen = Helper.Database.Sportsmans.ToList();
        return sportsmen;
    } 
        
    public ParticipantsWindow()
    {
       
        ButtonBack.Click += BackClick;
        Sort.SelectionChanged += Sort_OnSelectionChanged;
        InitializeComponent();
        Nan();
    }

    public void BackClick(object sender, EventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }

    private void LoadParticipants()
    {
        List<Sportsman> sportsmen = Nan();

        switch (Sort.SelectedIndex)
        {
            case 1:
                sportsmen = sportsmen.OrderBy(x => x.Surname).ToList();
                break;
            case 2:
                sportsmen = sportsmen.OrderByDescending(x => x.Surname).ToList();
                Console.WriteLine(sportsmen);
                break;
            case 0:
                sportsmen = Nan();
                break;
        }
        
        PaticipantsList.Items = sportsmen.Select(x => new
        {
            fullName = x.Surname + " " + x.Name + " " + x.Patronymic,
            fullAge = "Возраст: " + x.Age,
            Id = x.Id,
            fullWeight = "Вес: " + x.Weight,
            fullHeight = "Рост: " + x.Height
        });
    }

    private void Sort_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        LoadParticipants();
    }
}
using System;
using Avalonia.Controls;

namespace PrTest2;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Nationality_button.Click += Nationality_Click;
        Participants_button.Click += Participants_Click;
        Sport_button.Click += Sport_Click;
    }

    public void Nationality_Click(object sender, EventArgs e)
    {
        NationalityWindow nationalityWindow = new NationalityWindow();
        nationalityWindow.Show();
        Close();
    }

    public void Participants_Click(object sender, EventArgs e)
    {
        try
        {
            ParticipantsWindow participantsWindow = new ParticipantsWindow();
            participantsWindow.Show();
            Close();
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
    }

    public void Sport_Click(object sender, EventArgs e)
    {
        SportWindow sportWindow = new SportWindow();
        sportWindow.Show();
        Close();
    }
}
using System.Windows;
using VendingDevices.Context;

namespace VendingDevices;

public partial class AuthWindow : Window
{
    public AuthWindow()
    {
        InitializeComponent();
        using (MyDbContext db=new MyDbContext())
        {
            
        }
    }
}
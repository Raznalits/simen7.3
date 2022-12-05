using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Турагенство
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Model.DA_1Entities context { get; } = new Model.DA_1Entities();
        public static Model.name userObj = null;
        public static bool IsGone;
    }
}

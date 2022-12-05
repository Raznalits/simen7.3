using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Благодать
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static model.DA_BlagodatEntities1 context { get; } = new model.DA_BlagodatEntities1();
        public static model.Employee CurrentEmployee = null;
        public static bool IsGone;
    }
}

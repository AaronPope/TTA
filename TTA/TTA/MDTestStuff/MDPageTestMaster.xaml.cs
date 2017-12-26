using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TTA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MDPageTestMaster : ContentPage
    {
        public ListView ListView;

        public MDPageTestMaster()
        {
            InitializeComponent();

            BindingContext = new MDPageTestMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MDPageTestMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MDPageTestMenuItem> MenuItems { get; set; }
            
            public MDPageTestMasterViewModel()
            {
                MenuItems = new ObservableCollection<MDPageTestMenuItem>(new[]
                {
                    new MDPageTestMenuItem { Id = 0, Title = "Page 1" },
                    new MDPageTestMenuItem { Id = 1, Title = "Page 2" },
                    new MDPageTestMenuItem { Id = 2, Title = "Page 3" },
                    new MDPageTestMenuItem { Id = 3, Title = "Page 4" },
                    new MDPageTestMenuItem { Id = 4, Title = "Page 5" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}
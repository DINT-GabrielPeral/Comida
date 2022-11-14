using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comida
{
    class ComidaVM : INotifyCollectionChanged, INotifyPropertyChanged
    {
        private ObservableCollection<Plato> platos;
        private Plato platoSeleccionado;
        

        public Plato PlatoSeleccionado
        {
            get { return platoSeleccionado; }
            set { 
                platoSeleccionado = value;
                NotifyPropertyChanged("PlatoSeleccionado");
            }
        }


        public ObservableCollection<Plato> Platos
        {
            get { return platos; }
            set { 
                platos = value;
                NotifyPropertyChanged("Platos");
            }
        }

        public ComidaVM()
        {
            Platos = new ObservableCollection<Plato>();
            Platos = Plato.GetSamples("recursos/");
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

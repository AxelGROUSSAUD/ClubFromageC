using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using ModelLayer.Business;
using ModelLayer.Data;
using WpfClubFromage.viewModel;

namespace WpfClubFromage.viewModel
{
    class viewModelFromage : viewModelBase
    {
        //déclaration des attributs ...à compléter
        private DaoPays vmDaoPays;
        private DaoFromage vmDaoFromage;
        private ICommand updateCommand;
        private ICommand addCommand;
        private ICommand deleteCommand;
        private ObservableCollection<Pays> listPays;
        private ObservableCollection<Fromage> listFromages;

        private Fromage selectedFromage = new Fromage();
        private Fromage activeFromage = new Fromage();

        //déclaration des listes...à compléter avec les fromages
        public ObservableCollection<Pays> ListPays { get => listPays; set => listPays = value; }
        public ObservableCollection<Fromage> ListFromages { get => listFromages; set => listFromages = value; }



        //déclaration des propriétés avec OnPropertyChanged("nom_propriété_bindée")
        //par exemple...
        public Fromage SelectedFromage
        {
            get => selectedFromage;

            set
            {
                if (selectedFromage != value)
                {
                    selectedFromage = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("SelectedFromage");
                    ActiveFromage = selectedFromage;

                }
            }
        }

        public Fromage ActiveFromage
        {
            get => activeFromage;
            set
            {
                if (activeFromage != value)
                {
                    activeFromage = value;
                    OnPropertyChanged("Name");
                    OnPropertyChanged("Creation");
                    OnPropertyChanged("Origin");
                }
            }
        }


        public string Name
        {
            get
            {
                if (activeFromage != null)
                {
                    return activeFromage.Name;
                }
                else
                {
                    activeFromage = ListFromages[0];
                    return activeFromage.Name;
                }
            }
            set
            {
                if (activeFromage.Name != value)
                {
                    activeFromage.Name = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("Name");
                }
            }
        }

        public DateTime Creation
        {
            get => activeFromage.Creation;
            set
            {
                if (activeFromage.Creation != value)
                {
                    activeFromage.Creation = value;
                    OnPropertyChanged("Creation");
                }
            }
        }

        public Pays Origin
        {
            get => activeFromage.Origin;
            set
            {
                if (activeFromage.Origin != value)
                {
                    activeFromage.Origin = value;
                    OnPropertyChanged("Origin");
                }

            }
        }



        //déclaration du contructeur de viewModelFromage
        public viewModelFromage(DaoPays thedaopays, DaoFromage thedaofromage)
        {
            vmDaoPays = thedaopays;
            vmDaoFromage = thedaofromage;
            listPays = new ObservableCollection<Pays>(thedaopays.SelectAll());
            listFromages = new ObservableCollection<Fromage>(thedaofromage.SelectAll());
            foreach (Fromage F in listFromages)
            {
                int n = 0;
                while (F.Origin.Name != listPays[n].Name)
                {
                    n = n + 1;
                }

                F.Origin = listPays[n];



            }

        }

        //Méthode appelée au click du bouton UpdateCommand
        public ICommand UpdateCommand
        {
            get
            {
                if (this.updateCommand == null)
                {
                    this.updateCommand = new RelayCommand(() => UpdateFromage(), () => true);
                }
                return this.updateCommand;

            }

        }
        public ICommand AddCommand
        {
            get
            {
                if (this.addCommand == null)
                {
                    this.addCommand = new RelayCommand(() => AddFromage(), () => true);
                }
                return this.addCommand;

            }

        }
        public ICommand DeleteCommand
        {
            get
            {
                if (this.deleteCommand == null)
                {
                    this.deleteCommand = new RelayCommand(() => DeleteFromage(), () => true);
                }
                return this.deleteCommand;

            }

        }

        private void UpdateFromage()
        {
            //code du bouton - à coder
            Fromage backup = new Fromage();
            backup = activeFromage;
            int position;
            vmDaoFromage.Update(activeFromage);
            position = listFromages.IndexOf(activeFromage);
            listFromages.Insert(position, activeFromage);
            listFromages.RemoveAt(position + 1);
            selectedFromage = backup;

        }
        private void AddFromage()
        {
            //List<int> listeId = new List<int>();
            //foreach(f)
            vmDaoFromage.Insert(activeFromage);
            listFromages.Add(activeFromage);

        }
        private void DeleteFromage()
        {
            vmDaoFromage.Delete(activeFromage);
            listFromages.Remove(activeFromage);

        }
    }
}

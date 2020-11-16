﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ModelLayer.Business;
using ModelLayer.Data;
using WpfClubFromage.viewModel;

namespace WpfClubFromage.viewModel
{
    class viewModelFromage : viewModelBase
    {
        //déclaration des attributs ...à compléter
        private DaoPays vmDaoPays;
        private ICommand updateCommand;
        private ObservableCollection<Pays> listPays;
        private Fromage monFromage = new Fromage(1,"Rebloch");
        private Fromage selectedFromage = new Fromage();
        private Fromage activeFromage = new Fromage();

        //déclaration des listes...à compléter avec les fromages
        public ObservableCollection<Pays> ListPays { get => listPays; set => listPays = value; }

        //déclaration des propriétés avec OnPropertyChanged("nom_propriété_bindée")
        //par exemple...
        public string SelectedFromage
        {
            get => selectedFromage.Name;
            set
            {
                if (selectedFromage.Name != value)
                {
                    selectedFromage.Name = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("Name");
                    selectedFromage = activeFromage;
                }
            }
        }
        public string ActiveFromage
        {
            get => activeFromage.Name;
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

        //déclaration du contructeur de viewModelFromage
        public viewModelFromage(DaoPays thedaopays)
        {
            vmDaoPays = thedaopays;

            listPays = new ObservableCollection<Pays>(thedaopays.SelectAll());

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

        private void UpdateFromage()
        {
            //code du bouton - à coder
            
        }
    }
}

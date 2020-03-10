using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using Velocidad_de_lectura.Models;
using Velocidad_de_lectura.Services;
using Velocidaddelectura.Models;

namespace Velocidad_de_lectura.ViewModels
{
    /// <summary>
    /// Clase BaseViewModel, genérica
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <value>Variable de instancia: DataStore. </value>
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        /// <value>Variable de instancia: isBusy. </value>
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        /// <value>Variable de instancia: icon. </value>
        private string icon = null;
        /// <summary>
        /// Gets or sets the "Icon" of the viewmodel
        /// </summary>
        public const string IconPropertyName = "Icon";
        public string Icon
        {
            get { return icon; }
            set { SetProperty(ref icon, value); }
        }

        /// <value>Variable de instancia: title. </value>
        string title = string.Empty;
        /// <summary>
        /// Gets or sets the "Title"
        /// </summary>
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        /// <summary>
        /// SetProperty
        /// </summary>
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
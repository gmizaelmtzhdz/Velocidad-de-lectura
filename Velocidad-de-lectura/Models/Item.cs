using System;
namespace Velocidaddelectura.Models
{
    /// <summary>
    /// Clase Item, utilizada por ViewModels.BaseViewModel.cs
    /// </summary>
    public class Item
    {
        /// <value>Variable de instancia ID</value>
        public string Id { get; set; }
        /// <value>Variable de instancia Text</value>
        public string Text { get; set; }
        /// <value>Variable de instancia Description</value>
        public string Description { get; set; }
    }
}

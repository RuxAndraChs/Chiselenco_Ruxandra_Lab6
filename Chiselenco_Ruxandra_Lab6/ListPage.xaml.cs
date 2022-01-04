using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chiselenco_Ruxandra_Lab6.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Chiselenco_Ruxandra_Lab6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }
        
        async void OnShopListAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListPage
            {
                BindingContext = new ShopList()
            });
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ListPage
                {
                    BindingContext = e.SelectedItem as ShopList
                });
            }
        }

        async void OnChooseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductPage((ShopList)this.BindingContext)
            {
                BindingContext = new Product()
            });
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var shopl = (ShopList)BindingContext;
            listView.ItemsSource = await App.Database.GetListProductsAsync(shopl.ID);
        }
    }
}

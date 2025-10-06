using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Minhas_ComprasMAUI.Models;

namespace MinhasComprasMaui.Views;

public partial class ListaProduto : ContentPage
{
	ObservableCollection<Produto> lista = new ObservableCollection<Produto>();
	public ListaProduto()
	{
		InitializeComponent();

		lst_Produto.ItemsSource = lista;
	}

    protected async override void OnAppearing() //toda vez q a tela aparecer, busca no sqlite a lista de prod
    {
		try
		{
			List<Produto> tmp = await App.Db.GettAll(); // buscar lista de produtos

			tmp.ForEach(i => lista.Add(i));
		}
		catch (Exception ex) 
		{
			await DisplayAlert("OPS", ex.Message, "OK");
		}
		
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		try
		{
			Navigation.PushAsync(new Views.NovoProduto());
		}
		catch (Exception ex)
		{
			DisplayAlert("opss", ex.Message, "OK"); 
		}
    }

    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
		try
		{
			string q = e.NewTextValue;

			lista.Clear();

			List<Produto> tmp = await App.Db.Search(q);

			tmp.ForEach(i => lista.Add(i));
		}
		catch (Exception ex)
		{
			await DisplayAlert("OPSS", ex.Message, "OK");
		}
		
    }

    private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
		double soma = lista.Sum(i => i.Total);

		string msg = $"o total é {soma:C}";

		DisplayAlert("Total dos Produtos", msg, "OK"); 
	}

    private async Task MenuItem_Clicked(object sender, EventArgs e)
    {
		try
		{
			MenuItem selecionado = sender as MenuItem; 

			Produto p = selecionado.BindingContext as Produto;

			bool confirm = await DisplayAlert("tem certeza?", "Remover produto?", "Sim", "Não");

			if (confirm)
			{
				await App.Db.Delete(p.Id); 
				lista.Remove(p);
			}


		}catch (Exception ex)
        {
           await DisplayAlert("OPSS", ex.Message, "OK");
        }
    }

    private void lst_Produto_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		try
		{
			Produto p = e.SelectedItem as Produto;

			Navigation.PushAsync(new Views.EditarProduto
				{
				BindingContext = p,
			});
		}
		catch(Exception ex)
		{
             DisplayAlert("OPSS", ex.Message, "OK");
        }
    }
}
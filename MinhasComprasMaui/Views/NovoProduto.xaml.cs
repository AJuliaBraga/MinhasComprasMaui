using Minhas_ComprasMAUI.Models;

namespace MinhasComprasMaui.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}


	private async void ToolbarItem_Clicked_1(object sender, EventArgs e)
	{
		try
		{
			Produto p = new Produto
			{
					Descricao = txt_descricao.Text,
					Quantidade = Convert.ToDouble(txt_qntdd.Text),
					Preco = Convert.ToDouble(txt_preco.Text)
			};

			await App.Db.Insert(p);
			await DisplayAlert("Sucesso!", "Registro Inserido", "OK"); 

		}
		catch (Exception ex)
		{
			DisplayAlert("OPSS", ex.Message, "OK");
		}

	}
}   
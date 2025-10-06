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
				Preco = Convert.ToDouble(txt_preco.Text),

				DataCadastro = dp_dataCompra.Date
			};

			await App.Db.Insert(p);
			await DisplayAlert("Sucesso!", "Registro Inserido", "OK");
			await Navigation.PopAsync();

		}
		catch (Exception ex)
		{
			DisplayAlert("OPSS", ex.Message, "OK");
		}

	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            
            Produto p = new Produto
            {
                
                Descricao = txt_descricao.Text,
                Quantidade = Convert.ToDouble(txt_qntdd.Text),
                Preco = Convert.ToDouble(txt_preco.Text),

               
                DataCadastro = dp_dataCompra.Date
            };

            
            await App.Db.Insert(p);

            
            await DisplayAlert("Sucesso!", "Registro Inserido", "OK");

            
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            
            await DisplayAlert("OPSS", ex.Message, "OK");
        }
    }
}
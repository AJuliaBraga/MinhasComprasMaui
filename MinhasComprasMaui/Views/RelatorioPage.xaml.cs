
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Maui.Controls;
using Minhas_ComprasMAUI.Models;

namespace MinhasComprasMaui.Views
{
    public partial class RelatorioPage : ContentPage
    {
     
        public DateTime DataInicial { get; set; } = DateTime.Today.AddMonths(-1);
        public DateTime DataFinal { get; set; } = DateTime.Today;

        
        public ObservableCollection<Produto> ProdutosFiltrados { get; set; } = new ObservableCollection<Produto>();

        public RelatorioPage()
        {
            InitializeComponent();


            this.BindingContext = this;

            dp_DataInicial.Date = DataInicial;
            dp_DataFinal.Date = DataFinal;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            OnFiltrarClicked(null, null);
        }

        
        private async void OnFiltrarClicked(object sender, EventArgs e)
        {
            try
            {

                var todosProdutos = await App.Db.GettAll();


                ProdutosFiltrados.Clear();

                
                DateTime dataFimComHora = DataFinal.Date.AddDays(1).AddSeconds(-1);

                var produtosNoPeriodo = todosProdutos
                    .Where(p =>
                        p.DataCadastro.Date >= DataInicial.Date &&
                        p.DataCadastro.Date <= dataFimComHora.Date)
                    .OrderByDescending(p => p.DataCadastro) 
                    .ToList();

                
                foreach (var produto in produtosNoPeriodo)
                {
                    ProdutosFiltrados.Add(produto);
                }

                
                decimal totalGeral = (decimal)ProdutosFiltrados.Sum(p => p.Total);
                lbl_Total.Text = $"R$ {totalGeral:F2}";
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro de Relatório", $"Falha ao carregar o relatório: {ex.Message}", "OK");
            }
        }
    }
}
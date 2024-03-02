using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppMySQL.Models;
using AppMySQL.Controller;
using AppMySQL.View;

namespace AppMySQL.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageUpDel : ContentPage
    {
        public Pessoa pessoa;
        public PageUpDel()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = this.pessoa;
        }

        private void btnAtualizar_Clicked(object sender, EventArgs e)
        {
            MySQLCon.AtualizarPessoa(pessoa);
            DisplayAlert("Edição", "Pessoa atualizada com sucesso!", "OK");
            Navigation.PopAsync();
        }

        private void btnExcluir_Clicked(object sender, EventArgs e)
        {
            if(pessoa.ID != 0)
            {
                MySQLCon.ExcluirPessoa(pessoa);
                DisplayAlert("Exclusão", "Pessoa excluida com sucesso!", "OK");
                Navigation.PopAsync();
            }
        }
    }
}
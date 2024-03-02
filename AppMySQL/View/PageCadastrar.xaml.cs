using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppMySQL.Controller; //add essa coisa aqui

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMySQL.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageCadastrar : ContentPage
    {
        public PageCadastrar()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            MySQLCon.InserirPessoa(txtNome.Text, txtIdade.Text, txtCidade.Text);
            DisplayAlert("Inserção", "Pessoa Cadastrada com sucesso!", "OK");
            Navigation.PushAsync(new PageListar());
        }
    }
}
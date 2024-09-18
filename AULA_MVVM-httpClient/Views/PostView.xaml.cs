using AULA_MVVM_httpClient.ViewModels;

namespace AULA_MVVM_httpClient.Views;

public partial class PostView : ContentPage
{
	public PostView()
	{
		BindingContext = new PostViewModel();
		InitializeComponent();
	}
}
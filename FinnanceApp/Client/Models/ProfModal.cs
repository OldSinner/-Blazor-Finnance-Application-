using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace FinnanceApp.Client.Models

{
    public class ProfModal : ComponentBase
    {
        protected bool show = false;
        [Parameter]
        public EventCallback<bool> ShowChanged { get; set; }
        public void showModal()
        {
            show = true;
            StateHasChanged();
        }

        protected async Task OnShowChanged(bool value)
        {
            show = false;
            await ShowChanged.InvokeAsync(value);
        }


    }
}
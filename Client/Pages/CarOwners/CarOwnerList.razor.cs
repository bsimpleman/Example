using Microsoft.AspNetCore.Components;

namespace BlazorApp1.WebClient.Pages.CarOwners
{
    public partial class CarOwnerList
    {
        [Parameter]
        public List<OwnerDetail> Owners { get; set; }
        public string css = "";
        public void DoStuff()
        {

        }
    }
}

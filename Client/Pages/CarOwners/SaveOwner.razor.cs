using Microsoft.AspNetCore.Components;

namespace BlazorApp1.WebClient.Pages.CarOwners
{
    public partial class SaveOwner
    {
        [Parameter]
        public Guid? OwnerId { get; set; }
        [Parameter]
        public Guid CarId { get; set; }

        private string title = "Add Owner";
        private OwnerDetail ownerDetail = new OwnerDetail();

        protected override async Task OnInitializedAsync()
        {

        }

        protected override async Task OnParametersSetAsync()
        {
            if (OwnerId is not null)
            {
                ownerDetail = await _IOwnerClient.GetCarOwner((Guid)OwnerId);
                title = "Edit Owner";
            }
        }

        protected async Task SaveCarOwner()
        {
            ownerDetail = await _IOwnerClient.SaveCarOwner(ownerDetail);

            if(ownerDetail != null)
            {
                var result = await _ICarClient.AddCarOwner(CarId, ownerDetail.OwnerId);

                if (result)
                {
                    NavigationManager.NavigateTo($"/Cars/Details/{CarId}");
                }
            }
            else
            {
                title = "Owner not added. Please try again.";
            }
        }
    }
}

using BlazorApp1.DTOs.DTOs;
using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace BlazorApp1.WebClient.Pages.Cars
{
    public partial class Details
    {
        [Parameter]
        public Guid? CarId { get; set; }

        [Parameter]
        public bool Delete { get; set; }

        [Parameter]
        public bool AddOwner { get; set; }

        private string title = "Car Details";

        private CarDetails car = new CarDetails();
        private List<OwnerDetail> owners = new List<OwnerDetail>();

        protected override async Task OnParametersSetAsync()
        {
            if (CarId is not null)
            {
                car = await _ICarClient.GetCarById((Guid)CarId);
                owners = await _IOwnerClient.GetCarOwnerList((Guid)CarId);
            }
                

            if (Delete)
                title = "Are you sure you want to delete this?";
        }

        protected void AddAnOwner()
        {
            AddOwner = true;
        }

        protected async void DeleteTheCar()
        {
            var deleted = await _ICarClient.DeleteCar(car.CarId);

            if (!deleted)
            {
                title = "An Error Occured. Please try again later";
            }
            else
            {
                NavigationManager.NavigateTo($"/Cars/Index");
            }
        }
    }
}

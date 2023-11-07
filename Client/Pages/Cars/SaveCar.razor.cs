using Microsoft.AspNetCore.Components;

namespace BlazorApp1.WebClient.Pages.Cars
{
    public partial class SaveCar
    {
        [Parameter]
        public Guid? CarId { get; set; }

        private string title = "";
        private CarDetails car = new CarDetails();
        private string errorMessage = "";

        protected override async Task OnInitializedAsync()
        {
            title = "Add Car";
        }

        protected override async Task OnParametersSetAsync()
        {
            if (CarId is not null)
            {
                car = await _ICarClient.GetCarById((Guid)CarId);
                title = "Update Car";
            }     
        }

        protected async Task SaveACar()
        {
            var response = await _ICarClient.SaveCar(car);

            if(response.Worked)
            {
                NavigationManager.NavigateTo($"/Cars/Details/{response.ReturnType.CarId}");
            }
            else
            {
                errorMessage = response.Message;
            }
        }
    }
}

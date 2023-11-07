using BlazorApp1.DTOs.DTOs;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.Metrics;

namespace BlazorApp1.WebClient.Pages.Cars
{
    public partial class Index
    {
        [Parameter]
        public int pageNum { get; set; }

        [Parameter]
        public string searchText { get; set; }

        [Parameter]
        public string searchCategory { get; set; }

        private CarPagedList Cars = new CarPagedList();
        private List<OwnerDetail> Owners = new List<OwnerDetail>();
        private AddOwnerModal AddOwnerModal { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            Cars = await _ICarClient.GetCars(pageNum,searchText,searchCategory);
            Owners = await _IOwnerClient.GetCarOwnerList(null);
        }



        private void CreateNew()
        {
            NavigationManager.NavigateTo($"/Cars/Create");
        }

        private void Details(Guid id)
        {
            NavigationManager.NavigateTo($"/Cars/Details/{id}");
        }

        private void Edit(Guid id)
        {
            NavigationManager.NavigateTo($"/Cars/Edit/{id}");
        }

        private void Delete(Guid id)
        {
            NavigationManager.NavigateTo($"/Cars/Delete/{id}/{true}");
        }

        private string HasPrevious()
        {
            var prevDisabled = !Cars.HasPrev ? "disabled" : "";
            return prevDisabled;
        }

        private string HasNext()
        {
            var nextDisabled = !Cars.HasNext ? "disabled" : "";
            return nextDisabled;
        }

        private void PreviousPage()
        {
            if (Cars.searchText is not null && Cars.searchCategory is not null)
            {
                NavigationManager.NavigateTo($"/Cars/Index/{Cars.pgNum - 1}/{Cars.searchText}/{Cars.searchCategory}");
            }
            else
            {
                NavigationManager.NavigateTo($"/Cars/Index/{Cars.pgNum - 1}");
            }
        }

        private void NextPage()
        {
            if (Cars.searchText is not null && Cars.searchCategory is not null)
            {
                NavigationManager.NavigateTo($"/Cars/Index/{Cars.pgNum + 1}/{Cars.searchText}/{Cars.searchCategory}");
            }
            else
            {
                NavigationManager.NavigateTo($"/Cars/Index/{Cars.pgNum + 1}");
            }
        }
    }
}

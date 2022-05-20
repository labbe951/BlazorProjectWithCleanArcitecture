using Blazorise.DataGrid;
using CentiroHomeAssignment.Shared.ResponseModels;
using CentiroHomeAssignment.UI.Data;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CentiroHomeAssignment.UI.Pages.Orders
{
    public partial class OrderPage
    {
        [Inject]
        public IOrderDataService OrderDataService { get; set; }
        [Parameter]
        public List<OrderResponse> OrderResponses { get; set; }

        protected override async Task OnInitializedAsync() 
        {
            OrderResponses = await OrderDataService.GetAllOrders();
        }

    }
}

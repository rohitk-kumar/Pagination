#pragma checksum "C:\RajProj\Views\AddMerchant.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b78c3bc74c3d47b4a13be54e2de2cf7cb2dd51ea"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace RajProj.Views
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\RajProj\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\RajProj\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\RajProj\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\RajProj\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\RajProj\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\RajProj\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\RajProj\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\RajProj\_Imports.razor"
using RajProj;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\RajProj\_Imports.razor"
using RajProj.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\RajProj\Views\AddMerchant.razor"
using RajProj.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\RajProj\Views\AddMerchant.razor"
using RajProj.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\RajProj\Views\AddMerchant.razor"
using RajProj.Models;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/createmerchant")]
    public partial class AddMerchant : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 40 "C:\RajProj\Views\AddMerchant.razor"
       

    protected override async Task OnInitializedAsync()
    {
        viewModel.EA.GetEvent<DbUpdatedEvent>().Subscribe(Update);
    }
    private void CreateMerchantAccount()
    {
        //Create only 1 Merchant in the db at a time.
        viewModel.CreateMerchant();
        //viewModel.CreateMerchantAccounts(103);
        viewModel.EA.GetEvent<DbUpdatedEvent>().Publish("Created Merchant");

    }
    private void ErrorCheck()
    {
        //viewModel.GetAccountList(viewModel.PageId, viewModel.RowCount);
        viewModel.GetAccountList();
        viewModel.EA.GetEvent<DbUpdatedEvent>().Publish("Created Merchant");
    }
    private void ErrorCheck1()
    {
        viewModel.UseExtMethod();
       
    }
    private async void Update(string message)
    {
        await InvokeAsync(() => StateHasChanged());
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private MerchantInfoViewModel viewModel { get; set; }
    }
}
#pragma warning restore 1591

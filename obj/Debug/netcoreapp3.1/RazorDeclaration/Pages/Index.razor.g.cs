#pragma checksum "C:\RajProj\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f154e9ff6bbb61eb75340d8ab9cd93344e4879d9"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace RajProj.Pages
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
#line 2 "C:\RajProj\Pages\Index.razor"
using RajProj.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\RajProj\Pages\Index.razor"
using RajProj.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\RajProj\Pages\Index.razor"
using RajProj.Models;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 47 "C:\RajProj\Pages\Index.razor"
 
    protected override async Task OnInitializedAsync()
    {
        await viewModel.GetMerchantsAsync(DateTime.Now);
        viewModel.RowCount = 10;
    }
    private void GetAllAccounts(string x)
    {
        viewModel.RowCount = Convert.ToInt32(x);
        viewModel.PageId = 1;
        viewModel.EA.GetEvent<DbUpdatedEvent>().Publish(x);// not sure if a UI should be publishing an event here.
        StateHasChanged();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private MerchantInfoViewModel viewModel { get; set; }
    }
}
#pragma warning restore 1591
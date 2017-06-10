/************************************
Maintains JQuey events when the main grid is reload through ASPNET AJAX
************************************/
Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequest);
function EndRequest(sender, args) 
{
    netAjaxEvents();
}

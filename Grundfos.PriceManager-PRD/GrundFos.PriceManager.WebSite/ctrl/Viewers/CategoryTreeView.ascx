<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryTreeView.ascx.cs" Inherits="GrundFos.PriceManager.WebSite.ctrl.Viewers.CategoryTreeView" %>
<script language="javascript" type="text/javascript">
jQuery(document).ready(function(){  
  $(":input").click(checkboxSelected);
  
  function checkboxSelected() 
  {
    if ($(this).is(":checked"))
        {
            $(':check', $(this).nextAll('ul')).attr("checked","checked");
            
//            var $parent_ul = $(this).parents('li.AspNet-TreeView-Parent');
//            
//            var $checked = false;
//            $parent_ul.nextAll('ul').each(
//                if($(this).find(':input:first').is(":checked"))
//                    {
//                        $checked = true;
//                        alert('verdadero');
//                    }
//                else
//                    {
//                        $cheked = false;
//                        alert('false');
//                        return;
//                    }
//            );
//            
//            if($checked == true)
//                $parent_ul.find(':input:first').attr("checked","checked");
            
            //alert($parent_ul.length);
            //alert($parent_ul.nextAll('li').is(":checked"));
            //alert($parent_ul.next('label'));
        }
    else
        {
            $(':check', $(this).nextAll('ul')).attr("checked","");
            
            var $parents_li = $(this).parents('li.AspNet-TreeView-Root,li.AspNet-TreeView-Parent');
            //$parents_li.each(function() { $(this).find(':input:first').attr("checked","") });
            $parents_li.find(':input:first').attr("checked","");
        }
  }  
})  
</script>
<div class="notes"> 
  <div ID="litNoItems" class="flash_notice" runat="server" visible="false">No se encontraron registros.</div>  
    <asp:TreeView ID="tvw" runat="server" ShowCheckBoxes="All"></asp:TreeView>
  <asp:Table runat="server" ID="tblCategorys" CssClass="hierarchy"></asp:Table>
</div>
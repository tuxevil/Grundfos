/**************
*
* MENU CREATION
*
**************/

var cssdropdown={
disappeardelay: 250, //set delay in miliseconds before menu disappears onmouseout
disablemenuclick: false, //when user clicks on a menu item with a drop down menu, disable menu item's link?
enableswipe: 1, //enable swipe effect? 1 for yes, 0 for no
enableiframeshim: 0, //enable "iframe shim" technique to get drop down menus to correctly appear on top of controls such as form objects in IE5.5/IE6? 1 for yes, 0 for no

//No need to edit beyond here////////////////////////
dropmenuobj: null, ie: document.all, firefox: document.getElementById&&!document.all, swipetimer: undefined, bottomclip:0,

getposOffset:function(what, offsettype){
var totaloffset=(offsettype=="left")? what.offsetLeft : what.offsetTop;
var parentEl=what.offsetParent;
while (parentEl!=null){
totaloffset=(offsettype=="left")? totaloffset+parentEl.offsetLeft : totaloffset+parentEl.offsetTop;
parentEl=parentEl.offsetParent;
}
return totaloffset;
},

swipeeffect:function(){
if (this.bottomclip<parseInt(this.dropmenuobj.offsetHeight)){
this.bottomclip+=10+(this.bottomclip/10) //unclip drop down menu visibility gradually
this.dropmenuobj.style.clip="rect(0 auto "+this.bottomclip+"px 0)"
}
else
return
this.swipetimer=setTimeout("cssdropdown.swipeeffect()", 10)
},

showhide:function(obj, e){
if (this.ie || this.firefox)
this.dropmenuobj.style.left=this.dropmenuobj.style.top="-500px"
if (e.type=="click" && obj.visibility==hidden || e.type=="mouseover"){
if (this.enableswipe==1){
if (typeof this.swipetimer!="undefined")
clearTimeout(this.swipetimer)
obj.clip="rect(0 auto 0 0)" //hide menu via clipping
this.bottomclip=0
this.swipeeffect()
}
obj.visibility="visible"
}
else if (e.type=="click")
obj.visibility="hidden"
},

iecompattest:function(){
return (document.compatMode && document.compatMode!="BackCompat")? document.documentElement : document.body
},

clearbrowseredge:function(obj, whichedge){
var edgeoffset=0
if (whichedge=="rightedge"){
var windowedge=this.ie && !window.opera? this.iecompattest().scrollLeft+this.iecompattest().clientWidth-15 : window.pageXOffset+window.innerWidth-15
this.dropmenuobj.contentmeasure=this.dropmenuobj.offsetWidth
if (windowedge-this.dropmenuobj.x < this.dropmenuobj.contentmeasure)  //move menu to the left?
edgeoffset=this.dropmenuobj.contentmeasure-obj.offsetWidth
}
else{
var topedge=this.ie && !window.opera? this.iecompattest().scrollTop : window.pageYOffset
var windowedge=this.ie && !window.opera? this.iecompattest().scrollTop+this.iecompattest().clientHeight-15 : window.pageYOffset+window.innerHeight-18
this.dropmenuobj.contentmeasure=this.dropmenuobj.offsetHeight
if (windowedge-this.dropmenuobj.y < this.dropmenuobj.contentmeasure){ //move up?
edgeoffset=this.dropmenuobj.contentmeasure+obj.offsetHeight
if ((this.dropmenuobj.y-topedge)<this.dropmenuobj.contentmeasure) //up no good either?
edgeoffset=this.dropmenuobj.y+obj.offsetHeight-topedge
}
}
return edgeoffset
},

dropit:function(obj, e, dropmenuID){
if (this.dropmenuobj!=null) //hide previous menu
this.dropmenuobj.style.visibility="hidden" //hide menu
this.clearhidemenu()
if (this.ie||this.firefox){
obj.onmouseout=function(){cssdropdown.delayhidemenu()}
obj.onclick=function(){return !cssdropdown.disablemenuclick} //disable main menu item link onclick?
this.dropmenuobj=document.getElementById(dropmenuID);
if (this.dropmenuobj!=null) {
    this.dropmenuobj.onmouseover=function(){cssdropdown.clearhidemenu()}
    this.dropmenuobj.onmouseout=function(e){cssdropdown.dynamichide(e)}
    this.dropmenuobj.onclick=function(){cssdropdown.delayhidemenu()}
    this.showhide(this.dropmenuobj.style, e)
    this.dropmenuobj.x=this.getposOffset(obj, "left")
    this.dropmenuobj.y=this.getposOffset(obj, "top")
    this.dropmenuobj.style.left=this.dropmenuobj.x-this.clearbrowseredge(obj, "rightedge")+"px"
    this.dropmenuobj.style.top=this.dropmenuobj.y-this.clearbrowseredge(obj, "bottomedge")+obj.offsetHeight+1+"px"
    this.positionshim() //call iframe shim function
}
}
},

positionshim:function(){ //display iframe shim function
if (this.enableiframeshim && typeof this.shimobject!="undefined"){
if (this.dropmenuobj.style.visibility=="visible"){
this.shimobject.style.width=this.dropmenuobj.offsetWidth+"px"
this.shimobject.style.height=this.dropmenuobj.offsetHeight+"px"
this.shimobject.style.left=this.dropmenuobj.style.left
this.shimobject.style.top=this.dropmenuobj.style.top
}
this.shimobject.style.display=(this.dropmenuobj.style.visibility=="visible")? "block" : "none"
}
},

hideshim:function(){
if (this.enableiframeshim && typeof this.shimobject!="undefined")
this.shimobject.style.display='none'
},

contains_firefox:function(a, b) {
while (b.parentNode)
if ((b = b.parentNode) == a)
return true;
return false;
},

dynamichide:function(e){
var evtobj=window.event? window.event : e
if (this.ie&&!this.dropmenuobj.contains(evtobj.toElement))
this.delayhidemenu()
else if (this.firefox&&e.currentTarget!= evtobj.relatedTarget&& !this.contains_firefox(evtobj.currentTarget, evtobj.relatedTarget))
this.delayhidemenu()
},

delayhidemenu:function(){
this.delayhide=setTimeout("cssdropdown.dropmenuobj.style.visibility='hidden'; cssdropdown.hideshim()",this.disappeardelay) //hide menu
},

clearhidemenu:function(){
if (this.delayhide!="undefined")
clearTimeout(this.delayhide)
},

startchrome:function(){
for (var ids=0; ids<arguments.length; ids++){
var menuitems=document.getElementById(arguments[ids]).getElementsByTagName("a")
for (var i=0; i<menuitems.length; i++){
if (menuitems[i].getAttribute("rel")){
var relvalue=menuitems[i].getAttribute("rel")
if (document.getElementById(relvalue) != null) {
    menuitems[i].onmouseover=function(e){
    var event=typeof e!="undefined"? e : window.event
    cssdropdown.dropit(this,event,this.getAttribute("rel"))
    }
}
}
}
}
if (window.createPopup && !window.XmlHttpRequest && this.enableiframeshim){ //if IE5.5 to IE6, create iframe for iframe shim technique
document.write('<IFRAME id="iframeshim"  src="" style="display: none; left: 0; top: 0; z-index: 90; position: absolute; filter: progid:DXImageTransform.Microsoft.Alpha(style=0,opacity=0)" frameBorder="0" scrolling="no"></IFRAME>')
this.shimobject=document.getElementById("iframeshim") //reference iframe object
}
}

}

/***********************
*
* Show message helpers
*
* Example of Usage:
*
*            showInfoMessage('<b>Oh my god!</b> This is the message sucker!');
*            showErrorMessage('<b>Oh my god!</b> This is the message sucker!');
*            showWarningMessage('<b>Oh my god!</b> This is the message sucker!');
*
************************/

function showMessage(htmlMessage, level, close, $container) 
{
    $div = $("<div>");
    
    if (level == 1)
        $div.addClass("flash_alert");
    else if (level == 2)
        $div.addClass("flash_warning");
    else
        $div.addClass("flash_notice");
    
    $div.html(htmlMessage).hide();
    
    if (close) {    
        $div.css("cursor", "pointer").click(function() { $(this).hide('slow'); });;
        $span = $("<span>").text("[x]").css("float", "right").click( function() {
            $(this).parent().fadeOut(1000, function() { $(this).remove(); });
        });
        $div.prepend($span);
    }
    
    if (typeof($container) != "undefined")
    {
        $container.before($div);
    }
    else {
        $container = $("div.content");
        $container.prepend($div);
        $("#hd").attr("tabindex","9999").focus();
    }
    
    // Show the div and focus on it (need to set the tabindex for focus to work)
    $div.corner().show('slow');
    
    // Move focus on top
           
    // Notice should disappear after a few seconds.        
    setTimeout
        (
            function()
            {
                    jQuery('div.flash_notice').fadeOut(2000, function() { $(this).remove(); });
            },
            5000
    );
}

function showErrorMessage(htmlMessage, close, $container) 
{
    showMessage(htmlMessage, 1, close, $container);
}

function showWarningMessage(htmlMessage, close, $container) 
{
    showMessage(htmlMessage, 2, close, $container);
}

function showInfoMessage(htmlMessage, close, $container) 
{
    showMessage(htmlMessage, 3, close, $container);
}

/***********************
*
* Button disable helpers
*
* Example of Usage From CodeBehind On Any WebPage:
*
*        b.OnClientClick = string.Format("if (longProcessClickWithMessage(this)) {0};", this.GetPostBackEventReference(b));
*        c.OnClientClick = string.Format("if (standardClick(this)) {0};", this.GetPostBackEventReference(c));
*        d.OnClientClick = string.Format("if (longProcessClick(this,'My custom message<br><br>Argh!Argh!<br>')) {0};", this.GetPostBackEventReference(d));
*
************************/

function standardClick(elem) 
{
    return longProcessClick(elem);
}

function longProcessClick(elem, message, confirmMessage) 
{
    $elem = $(elem);
    
    if (typeof(confirmMessage)!="undefined")
        if (!confirm(confirmMessage))
            return false;
            
    Page_ClientValidate();
    if (Page_IsValid) { 

        if ($elem.is(":input")) {
            $elem.disabled = true;
            $elem.attr("disabled","disabled");
            $elem.val("Procesando...");
            $elem.removeClass('button').addClass("buttonDisabled");
            __doPostBack(elem.name, "");
            return false;
        }
        else {
            if ($elem.parents(".gridactions").length > 0) 
            {
                $elem.parents(".gridactions").hide("slow");
                if (typeof(message) != "undefined")
                    showWarningMessage(message, false, $("#noitems"));
                
                return true;
            }
            else
                $elem.attr("onclick","javascript: return false;");
        }
        
        if (typeof(message) != "undefined")
            showWarningMessage(message, false);
            
        return true;
    }
    
    return false;
}

function longProcessClickWithConfirm(elem, confirmMessage) 
{
    return longProcessClick(elem, 'Se esta procesando su solicitud. Espere por favor...', confirmMessage);
}


function longProcessClickWithMessage(elem) 
{
    return longProcessClick(elem, 'Se esta procesando su solicitud. Espere por favor...');
}

/* Form Input & Output Formatting */
$(document).ready(function() {

    cssdropdown.startchrome("Tabs");
    $("#headerTitle").css("cursor", "pointer").click(function() {window.location.href = "/"; });

    $(".form input, .form select").blur(testValidators);
    $(".form input, .form select").change(testValidators);
    $(".form input[type='submit']").click(showValidators);

    // Make sure only numbers are accepted for integer
    $('.form .integer').keydown(function(e){
        if (!(e.keyCode == 27 || e.keyCode == 109 || e.keyCode == 189 || e.keyCode == 46 || e.keyCode == 8 || e.keyCode == 9 || e.keyCode == 13 || (e.keyCode >= 96 && e.keyCode <= 105) || (e.keyCode >= 48 && e.keyCode <= 57) || (e.keyCode >= 37 && e.keyCode <= 40)))
            return false;
    });
      
    // Make sure only numbers and puntuaction are accepted for currency
    $('.form .currency').keydown(function(e){
        if (e.keyCode == 190)
            return false;
        if (!(e.keyCode == 27 || e.keyCode == 109 || e.keyCode == 189 || e.keyCode == 110 || e.keyCode == 188 || e.keyCode == 46 || e.keyCode == 190 || e.keyCode == 8 || e.keyCode == 9 || e.keyCode == 13 || (e.keyCode >= 96 && e.keyCode <= 105) || (e.keyCode >= 48 && e.keyCode <= 57) || (e.keyCode >= 37 && e.keyCode <= 40)))
            return false;
    });
    
    // Make sure only , are included, this should be language dependant in the future.
    $('.form .currency').keyup(function(e){
        if (e.keyCode == 110)
            $(this).val($(this).val().replace(".",","));
    });
    
    $span = $("<span>").text("[x]").css("float", "right").css("cursor","pointer").click( function() {
        $(this).parent().fadeOut(1000);
    });

    $("#validator_summary").corner().prepend($span);
});
        
function showValidators() {
    if (typeof(Page_ClientValidate) != "undefined" &&
    !Page_ClientValidate('form'))
        $("#validator_summary").show('slow');
    else
        $("#validator_summary").hide('slow');
}
   
function testValidators() {
    if ($("#validator_summary").is(":visible") && typeof(Page_ClientValidate) != "undefined" && Page_ClientValidate('form'))
        $("#validator_summary").hide('slow');
}

tinyMCE.init({
    mode : "textareas",
 	editor_selector : "mceEditor",
    theme : "advanced",
    //editor_deselector : "excludeEditor",
	plugins : "imagemanager,paste",
	theme_advanced_buttons1_add_before : "insertimage,pastetext,pasteword,selectall",
	imagemanager_insert_template : '<img src="{$path}" width="{$custom.width}" height="{$custom.height}" border="0" /></a>',
	relative_urls : false,
	paste_create_paragraphs : false,
	paste_create_linebreaks : false,
	paste_use_dialog : true,
	paste_auto_cleanup_on_paste : true,
	paste_convert_middot_lists : false,
	paste_unindented_list_class : "unindentedList",
	paste_convert_headers_to_strong : true,
	paste_insert_word_content_callback : "convertWord"
});

tinyMCE.init({
    mode : "textareas",
 	editor_selector : "mceEditorReadOnly",
 	readonly : true,
    theme : "advanced",
    //editor_deselector : "excludeEditor",
	plugins : "imagemanager,paste",
	theme_advanced_buttons1_add_before : "insertimage,pastetext,pasteword,selectall",
	imagemanager_insert_template : '<img src="{$path}" width="{$custom.width}" height="{$custom.height}" border="0" /></a>',
	relative_urls : false,
	paste_create_paragraphs : false,
	paste_create_linebreaks : false,
	paste_use_dialog : true,
	paste_auto_cleanup_on_paste : true,
	paste_convert_middot_lists : false,
	paste_unindented_list_class : "unindentedList",
	paste_convert_headers_to_strong : true,
	paste_insert_word_content_callback : "convertWord"
});


function convertWord(type, content) {
	return content;
}    

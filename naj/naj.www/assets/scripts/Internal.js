jQuery(document).ready(function(){
	
	$('.srchTxtBox').each(function() {
		var default_value = this.value;
		jQuery(this).focus(function() {
			if(this.value == default_value) {
				this.value = '';
			}
		});
		$(this).blur(function() {
			if(this.value == '') {
				this.value = default_value;
			}
		});
		
	
	});

var url = window.location.href;
if (url.search("FAQ") > 0){
    $("#PageImage").attr("src","/images/FaqBanner.jpg");
} else if (url.search("Internal") > 0){
    $("#PageImage").attr("src","images/AboutNajran.jpg");
}else {
    $(".PageImage").css("display","none");
}



jQuery("#menuzord").menuzord({
						align: "right"
					});
					

var menuTrigger = "hover";
				function setScript(trigger){
					$("head").append(
						"<script type='text/javascript'>" +
						"jQuery(document).ready(function(){" +
							"jQuery('#menuzord').menuzord({" +
								"align: 'right'," +
								"trigger: '" + trigger + "'" +
							"});" +
						"});</" + "script>"
					);
					menuTrigger = trigger;
				}
				
				
				function setActive(element, btType){
					$(btType).removeClass("active");
					$(element).addClass("active");
					$(".showhide").first().remove();
					$(".menuzord-menu").children("li").children("a").each(function(){
						if($(this).siblings(".dropdown, .megamenu").length > 0){
							$(this).children(".indicator").first().remove();
						}
					});
					$(".menuzord-menu").find(".dropdown").children("li").children("a").each(function(){
						if($(this).siblings(".dropdown").length > 0){
							$(this).children(".indicator").first().remove();
						}
					});
				}	
	
});


$(document).ready(function () {
        $(".cf_onclick").hover(function () {
            $(this).children().children().closest(".cf2 img.top").toggleClass("transparent");
            $(this).closest(".ListItem").toggleClass("ListItemHover");

        });
    });
    

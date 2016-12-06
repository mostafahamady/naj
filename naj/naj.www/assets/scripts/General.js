jQuery(document).ready(function() {
    $('.srchTxtBox').each(function() {
        var default_value = this.value;
        jQuery(this).focus(function() {
            if (this.value == default_value) {
                this.value = '';
            }
        });
        $(this).blur(function() {
            if (this.value == '') {
                this.value = default_value;
            }
        });
    });

    $('.hideme').smoove({ offset: '20%' });
    $(window).fadeThis({
        speed: 1000,
    });

    jQuery("#menuzord").menuzord({
        align: "right"
    });

    var menuTrigger = "hover";

    function setScript(trigger) {
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

    function setActive(element, btType) {
        $(btType).removeClass("active");
        $(element).addClass("active");
        $(".showhide").first().remove();
        $(".menuzord-menu").children("li").children("a").each(function() {
            if ($(this).siblings(".dropdown, .megamenu").length > 0) {
                $(this).children(".indicator").first().remove();
            }
        });
        $(".menuzord-menu").find(".dropdown").children("li").children("a").each(function() {
            if ($(this).siblings(".dropdown").length > 0) {
                $(this).children(".indicator").first().remove();
            }
        });
    }
});

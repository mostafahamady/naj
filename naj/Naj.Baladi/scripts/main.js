require.config({
    paths: {
        jquery: 'http://UI.localhost/assets/global/plugins/jquery.min.js',
        bootstrap: 'http://UI.localhost/assets/global/plugins/bootstrap/js/bootstrap.min.js',
        cookie: 'http://UI.localhost/assets/global/plugins/js.cookie.min.js',
        slimscroll: 'http://UI.localhost/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js',
        blockui: 'http://UI.localhost/assets/global/plugins/jquery.blockui.min.js',
        bootstrap_switch: 'http://UI.localhost/assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js',
        bootstrap_datatables: 'http://UI.localhost/assets/global/plugins/datatables/plugins/bootstrap/datatables.bootstrap.js',
        bootstrap_datepicker: 'http://UI.localhost/assets/global/plugins/bootstrap-datepicker/js/bootstrap-datepicker.min.js',
        easypiechart: 'http://UI.localhost/assets/global/plugins/jquery-easypiechart/jquery.easypiechart.min.js',
        sparkline: 'http://UI.localhost/assets/global/plugins/jquery.sparkline.min.js',
        App: 'http://UI.localhost/assets/global/scripts/app.js',
        jquery_datatables: 'http://UI.localhost/assets/global/plugins/datatables/datatables.min.js',
        dataTable: 'http://UI.localhost/assets/global/scripts/datatable.js',
        layout: 'http://UI.localhost/assets/layouts/layout/scripts/layout.min.js',
        demo: 'http://UI.localhost/assets/layouts/layout/scripts/demo.min.js',
        quick_sidebar: 'http://UI.localhost/assets/layouts/global/scripts/quick-sidebar.min.js',
        quick_nav: 'http://UI.localhost/assets/layouts/global/scripts/quick-nav.min.js'
    },

    shim: {
        bootstrap: {
            deps: ["jquery"]
        },
        slimscroll: {
            deps: ["jquery"]
        },
        blockui: {
            deps: ["jquery"]
        },
        bootstrap_switch: {
            deps: ["jquery", "bootstrap"]
        },
        bootstrap_datatables: {
            deps: ["jquery", "bootstrap", "dataTable"]
        },
        bootstrap_datepicker: {
            deps: ["jquery", "bootstrap"]
        },
        easypiechart: {
            deps: ["jquery"]
        },
        sparkline: {
            deps: ["jquery"]
        },
        app: {
            deps: ["jquery", "bootstrap"],
            exports: "App"
        },
        jquery_datatables: {
            deps: ["jquery"]
        },
        datatable: {
            deps: ["jquery", "bootstrap", "App"]
        },
        layout: {
            deps: ["jquery", "bootstrap", "App"]
        },
        demo: {
            deps: ["jquery", "bootstrap", "App"]
        },
        quick_sidebar: {
            deps: ["jquery", "App"]
        },
        quick_nav: {
            deps: ["jquery"]
        },
    },
});
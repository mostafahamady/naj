var VocationalRequests = function () {
    return {
        initDashboard: function () {
            $('.easy-pie-chart .number.con').easyPieChart({
                animate: 5000,
                size: 150,
                lineWidth: 20,
                lineCap: 'square',
                trackColor: '#f1f1f1',
                barColor: App.getBrandColor('yellow'),
                scaleColor: App.getBrandColor('yellow'),
            });
            $('.easy-pie-chart .number.finish').easyPieChart({
                animate: 5000,
                size: 150,
                lineWidth: 20,
                lineCap: 'square',
                trackColor: '#f1f1f1',
                barColor: App.getBrandColor('green'),
                scaleColor: App.getBrandColor('green'),
            });
            $('.easy-pie-chart .number.new').easyPieChart({
                animate: 5000,
                size: 150,
                lineWidth: 20,
                lineCap: 'square',
                trackColor: '#f1f1f1',
                barColor: App.getBrandColor('blue'),
                scaleColor: App.getBrandColor('blue'),
            });
            $('.easy-pie-chart .number.reject').easyPieChart({
                animate: 5000,
                size: 150,
                lineWidth: 20,
                lineCap: 'square',
                trackColor: '#f1f1f1',
                barColor: App.getBrandColor('red'),
                scaleColor: App.getBrandColor('red'),
            });
            $('.easy-pie-chart-reload').click(function () {
                $('.easy-pie-chart .number').each(function () {
                    var newValue = Math.floor(100 * Math.random());
                    $(this).data('easyPieChart').update(newValue);
                    $('span', this).text(newValue);
                });
            });
        },
        initNewRequest: function () {
            $('#sample_1').dataTable({
                "language": {
                    "aria": {
                        "sortAscending": ": activate to sort column ascending",
                        "sortDescending": ": activate to sort column descending"
                    },
                    "emptyTable": "لا يوجد بيانات",
                    "info": "عرض <b>_START_</b> إلي <b>_END_</b> من مجموع <b>_TOTAL_</b> صفوف",
                    "infoEmpty": "لا يوجد بيانات",
                    "infoFiltered": "(تصفية من <b>_MAX_</b> صف)",
                    "lengthMenu": "عدد الصفوف _MENU_",
                    "search": " بحث:",
                    "zeroRecords": "لا يوجد بيانات مطابقة للبحث",
                    "paginate": {
                        "previous": "السابق",
                        "next": "التالي",
                        "last": "الأخير",
                        "first": "الأول"
                    }
                },
                buttons: [
                    { extend: 'print', className: 'btn dark btn-outline', text: '<span class="fa fa-print"> </span> طباعة', exportOptions: { columns: "thead th:not(.noExport)" } },
                    { extend: 'pdf', className: 'btn red btn-outline', text: '<span class="fa fa-file-pdf-o"> </span> تنزيل علي هيئة PDF', exportOptions: { columns: [1,2, 3, 4, 5, 6] } },
                    { extend: 'excel', className: 'btn green-jungle btn-outline ', text: '<span class="fa fa-file-excel-o"> </span> تنزيل علي هيئة Excel', exportOptions: { columns: [1,2, 3, 4, 5, 6] } }
                ],
                responsive: true,
                "order": [
                    [0, 'asc']
                ],
                "lengthMenu": [
                    [5, 10, 15, 20, -1],
                    [5, 10, 15, 20, "الكل"]
                ],
                "pageLength": 5,
                "dom": "<'row' <'col-md-12'B>><'row'<'col-md-6 col-sm-12'l><'col-md-6 col-sm-12'f>r><'table-scrollable't><'row'<'col-md-5 col-sm-12'i><'col-md-7 col-sm-12'p>>"
            });
        },
        init: function () {
            this.initDashboard();
            this.initNewRequest();
        }
    };
}();

$(window).load(function () {
    VocationalRequests.init();
});
var Dashboard = function () {
	return {
		initDashboardDaterange: function () {
			if (!jQuery().daterangepicker) {
				return;
			}

			$('#dashboard-report-range').daterangepicker({
				"ranges": {
					'اليوم': [moment(), moment()],
					'أمس': [moment().subtract('days', 1), moment().subtract('days', 1)],
					'أخر 7 أيام': [moment().subtract('days', 6), moment()],
					'أخر 30 يوم':[moment().subtract('days', 29), moment()],
					'الشهر الحالي': [moment().startOf('month'), moment().endOf('month')],
					'الشهر الماضي': [moment().subtract('month', 1).startOf('month'), moment().subtract('month', 1).endOf('month')]
				},
				"locale": {
					"format": "YYYY/M/D",
					"separator": " - ",
					"applyLabel": "موافق",
					"cancelLabel": "إلغاء",
					"fromLabel": "من",
					"toLabel": "إلي",
					"customRangeLabel": "تحديد فترة",
					"daysOfWeek": [
                        "الأحد",
                        "الأثنين",
                        "الثلاثاء",
                        "الأربعاء",
                        "الخميس",
                        "الجمعة",
                        "السبت"
					],
					"monthNames": [
                        "1-يناير",
                        "2-فبراير",
                        "3-مارس",
                        "4-أبريل",
                        "5-مايو",
                        "6-يونيو",
                        "7-يوليو",
                        "8-أغسطس",
                        "9-سبتمبر",
                        "10-أكتوبر",
                        "11-نوفمبر",
                        "12-ديسمبر"
					],
					"firstDay": 1
				},
				"startDate": "2015/11/01",
				"endDate": "2015/12/01",
				opens: (App.isRTL() ? 'right' : 'left'),
			}, function (start, end, label) {
				if ($('#dashboard-report-range').attr('data-display-range') != '0') {
					$('#dashboard-report-range span').html(start.format('YYYY/M/D') + ' - ' + end.format('YYYY/M/D'));
				}
			});
			if ($('#dashboard-report-range').attr('data-display-range') != '0') {
				$('#dashboard-report-range span').html(moment().subtract('days', 29).format('YYYY/M/D') + ' - ' + moment().format('YYYY/M/D'));
			}
			$('#dashboard-report-range').show();
		},
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

		init: function () {
			this.initDashboardDaterange();
			this.initDashboard();
		}
	};
}();

$(window).load(function () {
	Dashboard.init();
});
/*** LINE CHART  START ***/
/* Variables */
const ctx = document.getElementById('myChart');

var addsomeSales = parseInt(ctx.getAttribute('addSome'));
var aheadBizSale = parseInt(ctx.getAttribute('aheadBiz'));

// Initialize chart with initial data
var myChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'],
        datasets: [{
            label: 'Addsome Business Corporation',
            data: [addsomeSales], // Initial data, will be updated dynamically
            fill: false,
            borderColor: '#00008B',
            backgroundColor: '#00008B',
            borderWidth: 1,
            tension: 1
        }, {
            label: 'Ahead Biz Computers',
            data: [aheadBizSale],
            fill: false,
            borderColor: '#FFFF00',
            backgroundColor: '#FFFF00',
            borderWidth: 1,
            tension: 1
        }]
    },
    options: {
        scales: {
            y: {
                beginAtZero: true
            }
        }
    }
});

// Function to update chart data dynamically
function updateChartData(newSalesRev) {
    myChart.data.datasets[0].data = [newSalesRev];
    myChart.update();
}
/*** LINE CHART END ***/

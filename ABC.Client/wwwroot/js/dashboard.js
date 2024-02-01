/*** LINE CHART  START ***/
/* Variables */
const ctx = document.getElementById('myChart');
var salesRev = parseInt(ctx.getAttribute('salesrevenue'));
var totalcostprice = parseInt(ctx.getAttribute('costpricetotal'));


new Chart(ctx, {
    type: 'line',
    data: {
        labels: ['Mon', 'Tues', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'],
        datasets: [{
            label: 'Sales Revenue',
            data: [salesRev],
            /*data: [12, 19, 3, 5, 2, 3, 9],*/
            borderColor: 'rgb(75, 192, 192)',
            backgroundColor: 'rgb(75, 192, 192)',
            borderWidth: 1
        }, {
            label: 'Purchase Cost',
            data: [totalcostprice],
            /*data: [10, 1, 4, 5, 2, 3, 7],*/
            borderColor: 'rgb(255, 0, 0)',
            backgroundColor: 'rgb(255, 0, 0)',
            borderWidth: 1
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
/*** LINE CHART END ***/
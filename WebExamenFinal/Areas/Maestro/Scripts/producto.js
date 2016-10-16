var pageSize = 0;
var rowsByPage = 10;
var currentPage = 1;

$(function () {
    calculateNumberOfPages(rowsByPage);
});

function setPaginator() {
    $(".paginator").bootpag({
        total: pageSize,
        page: 1,
        maxVisible: 5,
        leaps: true,
        firstLastUse: true,
        first: '←',
        last: '→',
        wrapClass: 'pagination',
        activeClass: 'active',
        disabledClass: 'disabled',
        nextClass: 'next',
        prevClass: 'prev',
        lastClass: 'last',
        firstClass: 'first'
    }).on("page", function (event, num) {
        goToPage(num);
        $(this).bootpag({ total: pageSize });
    });
}

function goToPage(page) {
    fullUrl = listAction + "?page=" + page + "&size=" + rowsByPage;
    $.get(fullUrl, function (data) {
        $('#ContenidoProducto').html(data);
        currentPage = page;
    });
}

function changeSize() {
    rowsByPage = $("#rowsByPage").val();
    if (rowsByPage)
        calculateNumberOfPages(rowsByPage);
}

function calculateNumberOfPages(rowsByPage) {
    var url = pageSizeAction + '?pageSize=' + rowsByPage;
    $.get(url, function (data) {
        pageSize = data;
        setPaginator();
        goToPage(1);
    });    
}

function reloadPage() {
    goToPage(currentPage);
}

function refrescar(nom)
{   
    currentPage = 1;
    reloadPage();
    closeModal(nom);
}